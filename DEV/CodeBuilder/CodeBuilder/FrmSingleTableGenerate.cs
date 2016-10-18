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
    public partial class FrmSingleTableGenerate : Form
    {
        public FrmSingleTableGenerate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public void Init(string input)
        {
            this.txt_OutPut.Text = input;
        }

        /// <summary>
        /// 复制到剪贴板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CopyAll_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txt_OutPut.Text);
            MessageBox.Show("OK!");
        }

    }
}
