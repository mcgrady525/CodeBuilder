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

    }
}
