using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CodeBuilder.DataAccess;
using CodeBuilder.Model.Domain;
using CodeBuilder.Model.Common;
using SSharing.Frameworks.Common.Extends;
using System.Data;
using CodeBuilder.Model.Template;
using CodeBuilder.Common;
using Microsoft.VisualStudio.TextTemplating;
using System.CodeDom.Compiler;

namespace CodeBuilder.Service
{
    public partial class CommonService
    {
        private static readonly CommonDao commonDao = new CommonDao();
        private static object lockObj = new object();
        private static object lockErrorLogObj = new object();

        /// <summary>
        /// 获取当前数据库中的所有用户表和视图列表
        /// isTable为true:表, false:视图
        /// </summary>
        public List<string> GetTableOrViewList(bool isTable)
        {
            var result = new List<string>();
            var schemaTables = commonDao.GetTableOrViewList(isTable);
            if (schemaTables.HasValue())
            {
                foreach (var item in schemaTables)
                {
                    result.Add(item.FullTableName);
                }
            }
            result.Sort();

            return result;
        }

        /// <summary>
        /// 获取当前表的列信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<ColumnInfo> GetTableSchemaBySqlDataReader(string tableName)
        {
            var result = new List<ColumnInfo>();

            var dt = commonDao.GetTableSchemaBySqlDataReader(tableName);
            foreach (DataRow row in dt.Rows)
            {
                var column = new ColumnInfo
                {
                    Name = row["ColumnName"].ToString(),
                    TypeName = row["DataTypeName"].ToString(),
                    Length = row["ColumnSize"].ToString().ToInt(),
                    IsIdentity = row["IsIdentity"].ToString().ToBool(),
                    NumericPrecision = row["NumericPrecision"].ToString().ToInt(),
                    NumericScale = row["NumericScale"].ToString().ToInt(),
                    IsPrimaryKey = row["IsIdentity"].ToString().ToBool(),//使用IsIdentity来判断?
                    IsNullalbe = row["AllowDBNull"].ToString().ToBool(),
                    CanSet = true
                };
                column.PublicPropertyName = CodeHelper.MakeFirstLetterUppercase(column.Name);
                column.CodeTypeName = CodeBuilderHelper.ConvertSqlServerTypeToCSharp(column.TypeName);

                result.Add(column);
            }

            //设置列的备注信息
            commonDao.SetColumnRemark(tableName, result);

            return result;
        }

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string CreateCode(CreateCodeRequest request)
        {
            //1，读取数据表元数据信息，并初始化EntityClassInfo
            //2，给T4模板传参
            //3，读取T4模板转换后的内容
            //4，返回生成后的代码文本(单表生成时返回代码文本，批量生成时写到输出目录)
            var result = string.Empty;
            var dt = commonDao.GetTableSchemaBySqlDataAdapter(request.TableName);
            var entityClassInfo = new EntityClassInfo(dt, request);

            //设置字段的备注信息
            commonDao.SetEntityClassPropertyRemark(entityClassInfo, request);

            var templatePath = string.Empty;
            if (request.CodeType == CodeType.POCOEntity)
            {
                templatePath = ConfigHelper.BASEDIRECTORY + ConfigHelper.GetAppSetting("POCOEntityTemplate");
            }
            if (request.CodeType == CodeType.DOEntity)
            {
                templatePath = ConfigHelper.BASEDIRECTORY + ConfigHelper.GetAppSetting("DOEntityTemplate");
            }
            if (request.CodeType == CodeType.DAL)
            {
                templatePath = ConfigHelper.BASEDIRECTORY + ConfigHelper.GetAppSetting("DALTemplate");
                throw new Exception(string.Format("模板:{0}的功能正在开发中...", "DAL"));
            }
            if (request.CodeType == CodeType.Service)
            {
                templatePath = ConfigHelper.BASEDIRECTORY + ConfigHelper.GetAppSetting("ServiceTemplate");
                throw new Exception(string.Format("模板:{0}的功能正在开发中...", "Service"));
            }
            if (!File.Exists(templatePath))
            {
                throw new Exception("找不到模板，请确认模板配置!");
            }

            CustomTextTemplatingEngineHost host = new CustomTextTemplatingEngineHost();
            host.TemplateFileValue = templatePath;
            host.Session = new TextTemplatingSession();
            host.Session.Add("entity", entityClassInfo);

            string input = File.ReadAllText(templatePath);
            result = new Engine().ProcessTemplate(input, host);

            #region 调试时使用
            StringBuilder errorWarn = new StringBuilder();
            foreach (CompilerError error in host.Errors)
            {
                errorWarn.Append(error.Line).Append(":").AppendLine(error.ErrorText);
            }

            if (!errorWarn.ToString().IsNullOrEmpty())//有错误
            {
                lock (lockErrorLogObj)
                {
                    if (!File.Exists("Error.log"))
                    {
                        File.Create("Error.log");
                    }
                    File.WriteAllText("Error.log", errorWarn.ToString()); 
                }
            }

            #endregion

            //批量生成时写到输出目录然后再返回文本
            if (request.GenerateType == GenerateType.MultiTable)
            {
                lock (lockObj)
                {
                    File.WriteAllText(string.Format("{0}\\{1}.cs", request.OutPutPath, entityClassInfo.ClassName), result, Encoding.UTF8); 
                }
            }

            return result;
        }

    }
}
