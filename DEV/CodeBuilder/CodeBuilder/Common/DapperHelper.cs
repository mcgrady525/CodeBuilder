using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CodeBuilder.Common
{
    /// <summary>
    /// Dapper帮助类
    /// </summary>
    public sealed partial class DapperHelper
    {
        /// <summary>
        /// 创建数据库连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateConnection()
        {
            IDbConnection conn = new SqlConnection(FrmMain.s_ConnectString);
            return conn;
        }
    }
}
