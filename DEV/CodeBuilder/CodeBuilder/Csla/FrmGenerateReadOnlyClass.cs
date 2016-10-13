using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder
{
    public partial class FrmGenerateReadOnlyClass : Form
    {
        public FrmGenerateReadOnlyClass()
        {
            InitializeComponent();
        }

        private string m_TableName;
        private List<ColumnInfo> m_ColumnList;

        public void Init(string tableName, List<ColumnInfo> columnList)
        {
            m_TableName = tableName;
            m_ColumnList = columnList;

            txtClassName.Text = tableName + "Info";
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            ReadOnlyClassGenerator gen = new ReadOnlyClassGenerator(txtClassName.Text.Trim(),
                                                                    txtRemark.Text.Trim(),
                                                                    chkUseBusinessConstants.Checked,
                                                                    m_ColumnList);

            string code = gen.GenerateCode();

            txtCode.Text = code;
        }

        private void btnCopyAll_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCode.Text);
        }
    }
}
