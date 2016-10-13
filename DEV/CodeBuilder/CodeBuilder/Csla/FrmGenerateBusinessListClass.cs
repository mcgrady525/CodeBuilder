using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder
{
    public partial class FrmGenerateBusinessListClass : Form
    {
        public FrmGenerateBusinessListClass()
        {
            InitializeComponent();
        }

        private string m_TableName;

        public void Init(string tableName)
        {
            m_TableName = tableName;

            txtCollectionClassName.Text = tableName + "s";
            txtCollectionItemClassName.Text = tableName;
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            BusinessListClassGenerator gen = new BusinessListClassGenerator(m_TableName,
                                                                            txtCollectionItemClassName.Text.Trim(),
                                                                            txtCollectionClassName.Text.Trim(),
                                                                            txtRemark.Text.Trim());

            string code = gen.GenerateCode();

            txtCode.Text = code;            
        }

        private void btnCopyAll_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCode.Text);
        }
    }
}
