using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeBuilder.Common;
using CodeBuilder.Model.Sys;
using Dapper;
using Tracy.Frameworks.Common.Extends;
using System.Data;
using System.Data.SqlClient;

namespace CodeBuilder.DataAccess
{
    /// <summary>
    /// 通用数据访问
    /// </summary>
    public class CommonDao
    {
        /// <summary>
        /// 获取当前数据库中的所有用户表和视图列表
        /// isTable为true:表, false:视图
        /// </summary>
        public List<TSysInfoSchemaTable> GetTableOrViewList(bool isTable)
        {
            var result = new List<TSysInfoSchemaTable>();

            using (var conn = DapperHelper.CreateConnection())
            {
                result = conn.Query<TSysInfoSchemaTable>(String.Format("select * from INFORMATION_SCHEMA.TABLES where table_type='{0}' order by TABLE_SCHEMA, TABLE_NAME", isTable ? "BASE TABLE" : "VIEW")).ToList();
            }

            return result;
        }

        /// <summary>
        /// 获取当前数据表的架构信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetTableSchemaInfo(string tableName)
        {
            DataTable dt = null;
            using (var conn = new SqlConnection(FrmMain.s_ConnectString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }
                using (var cmd = new SqlCommand(String.Format("Select TOP 1 * From {0}", tableName), conn))
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        adapter.FillSchema(dt, SchemaType.Source);
                    }
                }
            }

            return dt;
        }


    }
}
