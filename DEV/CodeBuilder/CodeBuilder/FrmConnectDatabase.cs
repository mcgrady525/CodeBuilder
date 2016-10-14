using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CodeBuilder.Common;

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
            var connStr = CodeBuilderHelper.CreateConnectString(this.txtServer.Text.Trim(), this.txtDatabase.Text.Trim(),
                                this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim(), this.rbSql.Checked);
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "连接失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FrmMain.s_ConnectString = connStr;

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 测试数据库连接是否正常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            //创建一个数据库连接，看是否能正常打开
            var flag = false;
            var errorMsg = string.Empty;
            var connStr = CodeBuilderHelper.CreateConnectString(this.txtServer.Text.Trim(), this.txtDatabase.Text.Trim(),
                                this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim(), this.rbSql.Checked);
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.ToString();
            }

            if (flag)
            {
                MessageBox.Show("连接成功!");
            }
            else
            {
                MessageBox.Show("连接失败,错误信息:" + errorMsg);
            }

        }
    }
}
