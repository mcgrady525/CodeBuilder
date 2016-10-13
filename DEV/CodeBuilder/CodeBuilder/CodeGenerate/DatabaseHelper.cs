using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder
{
    public static class DatabaseHelper
    {
        /// <summary>
        /// 获取库中的表或视图名字集合,isTable为true:表, false:视图
        /// </summary>
        public static List<string> GetTableOrViewList(bool isTable)
        {
            List<string> tableList = new List<string>();            
            
            using (SqlConnection conn = new SqlConnection(FrmMain.s_ConnectString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(String.Format("select * from INFORMATION_SCHEMA.TABLES where table_type='{0}' order by TABLE_SCHEMA, TABLE_NAME", isTable ? "BASE TABLE" : "VIEW"), conn))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tableList.Add(dr["TABLE_SCHEMA"].ToString() + "." + dr["TABLE_NAME"].ToString());
                        }
                    }
                }
            }

            tableList.Sort();

            return tableList;
        }

        public static DataTable GetColumnInfoDataTable(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(FrmMain.s_ConnectString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(String.Format("Select TOP 1 * From {0}", tableName), conn))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        return dr.GetSchemaTable();
                    }
                }
            }
        }

        public static List<ColumnInfo> GetColumnList(string tableName)
        {
            List<ColumnInfo> list = new List<ColumnInfo>();

            using (SqlConnection conn = new SqlConnection(FrmMain.s_ConnectString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(String.Format("Select TOP 1 * From {0}", tableName), conn))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dataTable = dr.GetSchemaTable();
                        
                        foreach (DataRow row in dataTable.Rows)
                        {
                            ColumnInfo column = new ColumnInfo();

                            column.Name = row["ColumnName"].ToString();
                            column.TypeName = row["DataTypeName"].ToString();
                            column.Length = Convert.ToInt32(row["ColumnSize"]);
                            column.IsIdentity = Convert.ToBoolean(row["IsIdentity"]);                            
                            column.NumericPrecision = Convert.ToInt32(row["NumericPrecision"]);
                            column.NumericScale = Convert.ToInt32(row["NumericScale"]);

                            list.Add(column);
                        }
                    }
                }
            }

            GetColumnRemark(tableName, list);

            foreach (ColumnInfo column in list)
            {
                column.SetDefultValue();
            }

            return list;
        }

        public static DataTable GetTableData(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(FrmMain.s_ConnectString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(String.Format("Select * From {0}", tableName), conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                 
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    List<DataColumn> removedCols = new List<DataColumn>();
                    foreach (DataColumn item in dt.Columns)
                    {
                        if (item.DataType == typeof(byte[]))
                        {
                            removedCols.Add(item);
                        }
                    }
                    foreach (DataColumn item in removedCols)
                    {
                        dt.Columns.Remove(item);
                    }

                    return dt;
                }
            }
        }

        private static void GetColumnRemark(string tableName, List<ColumnInfo> columnList)
        {
            string tableNameShort;
            string schema;
            GetTableNameInfo(tableName, out tableNameShort, out schema);

            using (SqlConnection conn = new SqlConnection(FrmMain.s_ConnectString))
            {
                conn.Open();

                foreach (ColumnInfo columnInfo in columnList)
                {
                    string sqlString = String.Format(
                        "Select value From ::fn_listextendedproperty (NULL, 'schema', '{0}', 'table', '{1}', 'column', '{2}')",
                        schema,
                        tableNameShort,
                        columnInfo.Name);

                    using (SqlCommand cmd = new SqlCommand(sqlString, conn))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            if(dr.Read())
                            {
                                columnInfo.Remark = dr[0].ToString();
                            }
                        }
                    }
                }
            }            
        }

        private static void GetTableNameInfo(string tableName, out string tableNameShort, out string schema)
        {
            int index= tableName.IndexOf('.');
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
    }
}
