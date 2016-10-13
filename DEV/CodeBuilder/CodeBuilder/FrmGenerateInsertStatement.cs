using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CodeBuilder
{
    public partial class FrmGenerateInsertStatement : Form
    {
        public FrmGenerateInsertStatement()
        {
            InitializeComponent();
        }

        public void Init(string tableName)
        {
            this.txtTableName.Text = tableName;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DataTable dt = GetDataFromDb(GetSelectString());
            
            this.dataGridView1.DataSource = dt;
            this.lblDataCount.Text = "记录数:" + dt.Rows.Count;
        }        
 
        private void btnGenerateInsertSql_Click(object sender, EventArgs e)
        {
            List<ColumnInfo> columns = GetColumnList(GetSelectSchemaString());

            DataTable dt = GetDataFromDb(GetSelectString());

            StringBuilder sb = GetInsertString(dt, columns, this.txtTableName.Text.Trim());

            this.txtCode.Text = sb.ToString();
            this.lblInsertCount.Text = "生成语句条数:" + dt.Rows.Count;
        }

        private StringBuilder GetInsertString(DataTable dt, List<ColumnInfo> columns, string tableName)
        {
            //是否将标识列包含在Insert语句中
            bool includeIdentityColumn = this.chkIncludeIdentity.Checked;
            //列中是否存在标识列
            bool hasIdeitityColumn = columns.Exists(x => x.IsIdentity);
            bool generateTran = this.chkGenerateTransaction.Checked;
            
            StringBuilder sb = new StringBuilder();
            if (hasIdeitityColumn && includeIdentityColumn)
            {
                sb.AppendFormat("SET IDENTITY_INSERT {0} ON ", tableName);
                sb.AppendLine();
            }

            if (generateTran)
            {
                sb.AppendLine("BEGIN TRAN");
            }

            foreach (DataRow row in dt.Rows)
            {
                string oneRowSql = GetOneRowSql(columns, row, tableName, includeIdentityColumn);
                sb.AppendLine(oneRowSql);
                sb.AppendLine("GO");
            }
            if (generateTran)
            {
                sb.AppendLine("COMMIT TRAN");
            }
            sb.AppendLine("GO");

            if (hasIdeitityColumn && includeIdentityColumn)
            {
                sb.AppendFormat("SET IDENTITY_INSERT {0} OFF ", tableName);
                sb.AppendLine();
                sb.AppendLine("GO");
            }            
            return sb;
        }
        
        private string GetOneRowSql(List<ColumnInfo> columns, DataRow row, string tableName, bool includeIdentityColumn)
        {
            StringBuilder insertString = new StringBuilder();

            insertString.AppendFormat("INSERT INTO {0} (", tableName);
            int i = 0;
            foreach (ColumnInfo col in columns)
            {
                if (col.IsIdentity && !includeIdentityColumn) continue;

                if (i == 0)
                {
                    insertString.AppendFormat("[{0}]", col.Name);
                }
                else
                {
                    insertString.AppendFormat(", [{0}]", col.Name);
                }
                i++;
            }

            insertString.Append(") VALUES(");
            i = 0;
            foreach (ColumnInfo col in columns)
            {
                if (col.IsIdentity && !includeIdentityColumn) continue;

                string value;
                if (row[col.Name] == DBNull.Value)
                {
                    value = "NULL";
                }
                else
                {
                    if (col.CodeTypeName == "string")
                    {
                        value = "'" + row[col.Name].ToString().Replace("'", "''") + "'";
                    }
                    else if (col.CodeTypeName == "DateTime")
                    {
                        value = "'" + ((DateTime)row[col.Name]).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    }
                    else if (col.CodeTypeName == "bool")
                    {
                        value = (bool)row[col.Name] ? "1" : "0";
                    }
                    else
                    {
                        value = row[col.Name].ToString();
                    }
                }
                if (i == 0)
                {
                    insertString.AppendFormat("{0}", value);
                }
                else
                {
                    insertString.AppendFormat(", {0}", value);
                }
                i++;
            }

            insertString.Append(");");
            return insertString.ToString();
        }

        private static List<ColumnInfo> GetColumnList(string selectSchemaString)
        {
            List<ColumnInfo> list = new List<ColumnInfo>();

            using (SqlConnection conn = new SqlConnection(FrmMain.s_ConnectString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(selectSchemaString, conn))
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

                            column.SetDefultValue();

                            list.Add(column);
                        }
                    }
                }
            }
            return list;
        }

        private static DataTable GetDataFromDb(string selectString)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(FrmMain.s_ConnectString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(selectString, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);
                }
            }
            return dt;
        }

        private string GetSelectString()
        {
            string selectString = string.Format("Select {0} From {1}", txtSelectColumns.Text.Trim(), txtTableName.Text.Trim());

            if (txtWhereString.Text.Trim().Length > 0)
            {
                selectString += " Where " + txtWhereString.Text.Trim();
            }

            return selectString;
        }

        private string GetSelectSchemaString()
        {
            return  string.Format("Select TOP 1 {0} From {1}", txtSelectColumns.Text.Trim(), txtTableName.Text.Trim());                   
        }

        private void btnCopyAll_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCode.Text);
        }
    }
}
