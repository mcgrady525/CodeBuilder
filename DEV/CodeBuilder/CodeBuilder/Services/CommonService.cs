using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeBuilder.DataAccess;
using Tracy.Frameworks.Common.Extends;
using System.Data;

namespace CodeBuilder.Service
{
    public partial class CommonService
    {
        private static readonly CommonDao commonDao= new CommonDao();

        /// <summary>
        /// 获取当前数据库中的所有用户表和视图列表
        /// isTable为true:表, false:视图
        /// </summary>
        public List<string> GetTableOrViewList(bool isTable)
        {
            var result = new List<string>();
            var schemaTables= commonDao.GetTableOrViewList(isTable);
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
                    CanSet= true
                };
                column.PublicPropertyName = CodeHelper.MakeFirstLetterUppercase(column.Name);
                column.CodeTypeName = CodeHelper.GetCodeTypeName(column.TypeName);

                result.Add(column);
            }

            //设置列的备注信息
            commonDao.SetColumnRemark(tableName, result);

            return result;
        }

    }
}
