using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CodeBuilder.DataAccess;
using CodeBuilder.Model.Domain;
using CodeBuilder.Model.Common;
using Tracy.Frameworks.Common.Extends;
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
        public List<ColumnInfo> GetTableSchemaInfo(string tableName)
        {
            var result = new List<ColumnInfo>();

            var dt = commonDao.GetTableSchemaInfo(tableName);
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
                column.CodeTypeName = CodeHelper.GetCodeTypeName(column.TypeName);

                result.Add(column);
            }

            //设置列的备注信息
            commonDao.SetColumnRemark(tableName, result);

            return result;
        }

        /// <summary>
        /// 获取表的元数据信息并返回DataTable
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetDataTableSchemaInfo(string tableName)
        {
            return commonDao.GetTableSchemaInfo(tableName);
        }

        /// <summary>
        /// 生成单表代码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string GenerateSingleTableCode(CreateCodeRequest request)
        {
            //1，读取数据表元数据信息，并初始化EntityClassInfo
            //2，给T4模板传参
            //3，读取T4模板转换后的内容
            //4，返回生成后的代码文本
            var result = string.Empty;
            var dt = commonDao.GetTableSchemaInfoByDataAdapter(request.TableName);
            var entityClassInfo = new EntityClassInfo(dt);

            var templatePath = string.Empty;
            if (request.CodeType == CodeType.POCOEntity)
            {
                templatePath = ConfigHelper.BASEDIRECTORY + ConfigHelper.GetAppSetting("POCOEntityTemplate");
            }
            if (request.CodeType == CodeType.DAL)
            {
                templatePath = ConfigHelper.BASEDIRECTORY + ConfigHelper.GetAppSetting("DALTemplate");
                return "开发中...";
            }
            if (request.CodeType == CodeType.Service)
            {
                templatePath = ConfigHelper.BASEDIRECTORY + ConfigHelper.GetAppSetting("ServiceTemplate");
                return "开发中...";
            }
            if (!File.Exists(templatePath))
            {
                return "找不到模板，请确认模板配置!";
            }

            CustomTextTemplatingEngineHost host = new CustomTextTemplatingEngineHost();
            host.TemplateFileValue = templatePath;
            host.Session = new TextTemplatingSession();
            host.Session.Add("entity", entityClassInfo);

            string input = File.ReadAllText(templatePath);
            result = new Engine().ProcessTemplate(input, host);

            #region 调试时使用
            //StringBuilder errorWarn = new StringBuilder();
            //foreach (CompilerError error in host.Errors)
            //{
            //    errorWarn.Append(error.Line).Append(":").AppendLine(error.ErrorText);
            //}
            //if (!File.Exists("Error.log"))
            //{
            //    File.Create("Error.log");
            //}
            //File.WriteAllText("Error.log", errorWarn.ToString());
            #endregion

            return result;
        }

    }
}
