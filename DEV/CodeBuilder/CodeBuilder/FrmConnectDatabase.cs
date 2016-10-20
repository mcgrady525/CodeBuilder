using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CodeBuilder.Common;
using Tracy.Frameworks.Common.Extends;

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

            //这里就不再检测数据库连接了
            FrmMainNew.s_ConnectString = connStr;
            FrmMainNew.s_CurrentServer = this.txtServer.Text.IsNullOrEmpty() ? "" : this.txtServer.Text.Trim();
            FrmMainNew.s_CurrentDB = this.txtDatabase.Text.IsNullOrEmpty() ? "" : this.txtDatabase.Text.Trim();

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
                MessageBox.Show("连接成功!!!", "连接成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(errorMsg, "连接失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
