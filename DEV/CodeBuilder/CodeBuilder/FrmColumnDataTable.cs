using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder
{
    public partial class FrmColumnDataTable : Form
    {
        public FrmColumnDataTable()
        {
            InitializeComponent();
        }

        public void Init(DataTable dt)
        {
            this.dataGridView1.DataSource = dt;
        }
    }
}
