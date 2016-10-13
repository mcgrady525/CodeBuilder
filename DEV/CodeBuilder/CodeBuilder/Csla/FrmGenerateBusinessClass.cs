using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder
{
    public partial class FrmGenerateBusinessClass : Form
    {
        public FrmGenerateBusinessClass()
        {
            InitializeComponent();
        }

        private string m_TableName;
        private string m_ProcNum;
        private List<ColumnInfo> m_ColumnList;

        public void Init(string tableName, string procNum, List<ColumnInfo> columnList)
        {
            m_TableName = tableName;
            m_ProcNum = procNum;
            m_ColumnList = columnList;

            txtClassName.Text = tableName;
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            BusinessClassGenerator gen = new BusinessClassGenerator(txtClassName.Text.Trim(),
                                                                    txtRemark.Text.Trim(),
                                                                    m_TableName,
                                                                    m_ProcNum,
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
