using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder
{
    public partial class FrmGenerateProcAdd : Form
    {
        public FrmGenerateProcAdd()
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

            txtName.Text = String.Format("usp_A{0}1_Add{1}", m_ProcNum, m_TableName);
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            ProcAddGenerator gen = new ProcAddGenerator(txtName.Text.Trim(), m_TableName, m_ColumnList);

            string code = gen.GenerateCode();

            txtCode.Text = code;    
        }

        private void btnCopyAll_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCode.Text);
        }
    }
}
