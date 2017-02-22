using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tracy.Frameworks.Common.Extends;

namespace CodeBuilder.Common
{
    /// <summary>
    /// 代码生成器帮助类
    /// </summary>
    public sealed partial class CodeBuilderHelper
    {
        /// <summary>
        /// 创建数据库连接字符串
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="dataBase"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="isSqlVerify"></param>
        /// <returns></returns>
        public static string CreateConnectString(string dataSource, string dataBase, string userName, string password, bool isSqlVerify = true)
        {
            if (dataSource.IsNullOrEmpty())
            {
                throw new ArgumentNullException("dataSource", "dataSource不能为空!");
            }
            if (dataBase.IsNullOrEmpty())
            {
                throw new ArgumentNullException("dataBase", "dataBase不能为空!");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Data Source={0};", dataSource);
            sb.AppendFormat("Initial Catalog={0};", dataBase);
            if (isSqlVerify)
            {
                sb.AppendFormat("Persist Security Info=True;User ID={0};Password={1}", userName, password);
            }
            else
            {
                sb.Append("integrated security=True");
            }

            return sb.ToString();
        }

        /// <summary>
        /// 依据表或视图生成类名
        /// 自动去掉架构名和中间的'_'字符然后每个首字母大写
        /// </summary>
        /// <param name="tableName">dbo.t_sys_rights_user或t_sys_rights_user</param>
        /// <returns></returns>
        public static string GetClassNameByTableName(string tableName)
        {
            if (tableName.IsNullOrEmpty())
            {
                throw new ArgumentNullException("tableName", "tableName不能为空!");
            }

            var tempTableName = string.Empty;
            if (tableName.Contains("."))
            {
                tempTableName = tableName.Substring(tableName.IndexOf('.') + 1);
            }
            else
            {
                tempTableName = tableName;
            }

            return CodeHelper.MakeFirstLetterUppercase(tempTableName);
        }

        /// <summary>
        /// sql server数据类型转换为c#类型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ConvertSqlServerTypeToCSharp(string input)
        {
            input = input.ToLower();
            if (input == "char" || input == "nchar" || input == "varchar" || input == "nvarchar")
            {
                return "string";
            }
            if (input == "bit")
            {
                return "bool";
            }
            if (input == "tinyint")
            {
                return "byte";
            }
            if (input == "smallint")
            {
                return "short";
            }
            if (input == "int")
            {
                return "int";
            }
            if (input == "bigint")
            {
                return "long";
            }
            if (input == "float" || input == "double")
            {
                return "double";
            }
            if (input == "decimal")
            {
                return "decimal";
            }
            if (input == "smalldatetime" || input == "datetime")
            {
                return "datetime";
            }
            if (input == "binary" || input == "varbinary")
            {
                return "byte[]";
            }
            if (input == "uniqueidentifier")
            {
                return "Guid";
            }
            else
            {
                throw new Exception(string.Format("sql server数据类型转换为c#类型失败,不支持的数据库类型:{0}", input));
            }
        }

        /// <summary>
        /// 基元类型转换为c#别名
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ConvertUserTypeToKeyword(string input)
        {
            if (input == "System.String" || input == "System.Char")
            {
                return "string";
            }
            if (input == "System.Byte")
            {
                return "byte";
            }
            if (input == "System.Byte[]")
            {
                return "byte[]";
            }
            if (input == "System.Int16")
            {
                return "short";
            }
            if (input == "System.Int32")
            {
                return "int";
            }
            if (input == "System.Int64")
            {
                return "long";
            }
            if (input == "System.Single" || input == "System.Double")
            {
                return "double";
            }
            if (input == "System.Decimal")
            {
                return "decimal";
            }
            if (input == "System.DateTime")
            {
                return "DateTime";
            }
            if (input == "System.Boolean")
            {
                return "bool";
            }
            if (input == "System.Guid")
            {
                return "Guid";
            }
            else
            {
                throw new Exception(string.Format("基元类型转换为c#别名失败,不支持的基元类型:{0}", input));
            }

        }

    }
}
