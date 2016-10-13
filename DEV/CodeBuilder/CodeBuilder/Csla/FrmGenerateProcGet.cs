using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder
{
    public partial class FrmGenerateProcGet : Form
    {
        public FrmGenerateProcGet()
        {
            InitializeComponent();
        }

        private string m_TableName;
        private string m_ProcNum;

        public void Init(string tableName, string procNum)
        {
            m_TableName = tableName;
            m_ProcNum = procNum;

            txtName.Text = String.Format("usp_A{0}0_Get{1}", m_ProcNum, m_TableName);
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            ProcGetGenerator gen = new ProcGetGenerator(txtName.Text.Trim(), m_TableName);

            string code = gen.GenerateCode();

            txtCode.Text = code;
        }

        private void btnCopyAll_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCode.Text);
        }
    }
}
