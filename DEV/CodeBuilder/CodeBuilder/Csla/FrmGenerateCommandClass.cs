using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder
{
    public partial class FrmGenerateCommandClass : Form
    {
        public FrmGenerateCommandClass()
        {
            InitializeComponent();
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            if (txtClassName.Text.Trim().Length == 0)
            {
                MessageBox.Show("ClassName is null");
                return;
            }
            if (txtProcName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Proc Name is null");
                return;
            }

            List<CommandParameter> paraList = new List<CommandParameter>();
            foreach (DataGridViewRow  row in this.dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string typeName = row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : string.Empty;
                    string name = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : string.Empty;
                    if(string.IsNullOrEmpty(typeName))
                    {
                        MessageBox.Show("TypeName is null");
                        return;
                    }
                    if(string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Name is null");
                        return;
                    }

                    CommandParameter para = new CommandParameter(name, typeName);

                    paraList.Add(para);
                }
            }

            CommandClassGenerator gen = new CommandClassGenerator(
                                                txtClassName.Text.Trim(),
                                                txtProcName.Text.Trim(),
                                                paraList);

            string code = gen.GenerateCode();

            txtCode.Text = code;            
        }

        private void btnCopyAll_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCode.Text);
        }
    }
}
