using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder
{
    public partial class FrmGenerateEntityClass : Form
    {
        public FrmGenerateEntityClass()
        {
            InitializeComponent();
        }

        private string m_TableName;
        private List<ColumnInfo> m_ColumnList;

        public void Init(string tableName, List<ColumnInfo> columnList)
        {
            m_TableName = tableName;
            m_ColumnList = columnList;

            if (tableName.Contains("."))
            {
                txtClassName.Text = tableName.Substring(tableName.IndexOf('.') + 1);
            }
            else
            {
                txtClassName.Text = tableName;
            }
            txtClassName.Text = CodeHelper.MakeFirstLetterUppercase(txtClassName.Text);
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            EntityClassGenerator gen = new EntityClassGenerator(m_TableName,
                                                                txtClassName.Text.Trim(),
                                                                txtRemark.Text.Trim(),
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
