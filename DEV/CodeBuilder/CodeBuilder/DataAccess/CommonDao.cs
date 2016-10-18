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

            var tableType = isTable ? "BASE TABLE" : "VIEW";
            using (var conn = DapperHelper.CreateConnection())
            {
                result = conn.Query<TSysInfoSchemaTable>("select * from INFORMATION_SCHEMA.TABLES where table_type=@TableType order by TABLE_SCHEMA, TABLE_NAME", new { TableType = tableType }).ToList();
            }

            return result;
        }

        /// <summary>
        /// 获取当前数据表的架构信息(DataGridView展示表元数据用)
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetTableSchemaInfo(string tableName)
        {
            DataTable dt = new DataTable();

            using (var conn = new SqlConnection(FrmMainNew.s_ConnectString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }
                using (var cmd = new SqlCommand(String.Format("Select TOP 1 * From {0}", tableName), conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        dt = dr.GetSchemaTable();
                    }
                }
            }

            return dt;
        }

        /// <summary>
        /// 获取当前数据表的架构信息(生成代码用)
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetTableSchemaInfoByDataAdapter(string tableName)
        {
            DataTable dt = new DataTable();

            using (var conn = new SqlConnection(FrmMainNew.s_ConnectString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }
                using (var cmd = new SqlCommand(String.Format("Select TOP 1 * From {0}", tableName), conn))
                {
                    using (var adapter= new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        adapter.FillSchema(dt, SchemaType.Source);
                    }
                }
            }

            return dt;
        }

        /// <summary>
        /// 设置当前数据表列的备注信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columns"></param>
        public void SetColumnRemark(string tableName, List<ColumnInfo> columns)
        {
            string tableNameShort;
            string schema;
            GetTableNameInfo(tableName, out tableNameShort, out schema);

            using (SqlConnection conn = new SqlConnection(FrmMainNew.s_ConnectString))
            {
                if (conn.State!= ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }

                foreach (ColumnInfo column in columns)
                {
                    string sql = String.Format(
                        "Select value From ::fn_listextendedproperty (NULL, 'schema', '{0}', 'table', '{1}', 'column', '{2}')",
                        schema,
                        tableNameShort,
                        column.Name);

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                column.Remark = dr[0].ToString();
                            }
                        }
                    }
                }
            }
        }

        #region Private method

        private static void GetTableNameInfo(string tableName, out string tableNameShort, out string schema)
        {
            int index = tableName.IndexOf('.');
            if (index >= 0)
            {
                schema = tableName.Substring(0, index);
                tableNameShort = tableName.Substring(index + 1);
            }
            else
            {
                tableNameShort = tableName;
                schema = "dbo";
            }
        }

        #endregion


    }
}
