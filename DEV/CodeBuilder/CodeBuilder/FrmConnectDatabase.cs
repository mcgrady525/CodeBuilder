using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder
{
    public partial class FrmConnectDatabase : Form
    {
        public FrmConnectDatabase()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string sqlString;
            if (this.rbSql.Checked)
            {
                sqlString = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}",
                                                        txtServer.Text.Trim(),
                                                        txtDatabase.Text.Trim(),
                                                        txtUserName.Text.Trim(),
                                                        txtPassword.Text.Trim());
            }
            else
            {
                sqlString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True",
                                                        txtServer.Text.Trim(),
                                                        txtDatabase.Text.Trim());
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlString))
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "连接失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FrmMain.s_ConnectString = sqlString;

            this.DialogResult = DialogResult.OK;
        }
    }
}
