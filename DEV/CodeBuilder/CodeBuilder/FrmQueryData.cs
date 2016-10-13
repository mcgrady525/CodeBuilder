using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder
{
    public partial class FrmQueryData : Form
    {
        public FrmQueryData()
        {
            InitializeComponent();
        }

        public void Init(DataTable dataTable)
        {
            this.dataGridView1.DataSource = dataTable;
        }
    }
}
