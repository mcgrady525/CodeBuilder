using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder
{
    public partial class FrmConfigEdit : Form
    {
        public FrmConfigEdit()
        {
            InitializeComponent();
        }

        private void FrmConfigEdit_Load(object sender, EventArgs e)
        {
            ConfigInfo config = ConfigManager.GetConfigInfo();

            txtConstantPrefix.Text  = config.ConstantPrefix;
            txtNamespace.Text       = config.NameSpaceForClass;
            txtUsingStatements.Text = config.UsingStatements;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ConfigInfo config = new ConfigInfo();

            config.ConstantPrefix = txtConstantPrefix.Text.Trim();
            config.NameSpaceForClass = txtNamespace.Text.Trim();
            config.UsingStatements = txtUsingStatements.Text;

            ConfigManager.SaveConfigInfo(config);

            MessageBox.Show("配置信息保存成功");
        }
    }
}
