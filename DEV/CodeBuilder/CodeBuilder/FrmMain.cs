using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CodeBuilder.Service;

namespace CodeBuilder
{
    public partial class FrmMain : Form
    {
        private static readonly CommonService commonService = new CommonService();

        public FrmMain()
        {
            InitializeComponent();
        }

        //数据库连接字符串
        public static string s_ConnectString = string.Empty;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            List<string> tables = commonService.GetTableOrViewList(true);
            TreeNode tableNode = this.treeTables.Nodes.Add("用户表");
            foreach (string item in tables)
            {
                tableNode.Nodes.Add(item);
            }

            List<string> views = commonService.GetTableOrViewList(false);
            TreeNode viewNode = this.treeTables.Nodes.Add("视图");
            foreach (string item in views)
            {
                viewNode.Nodes.Add(item);
            }

            treeTables.ExpandAll();
        }

        private void treeTables_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "用户表" || e.Node.Text == "视图")
            {
                return;
            }

            List<ColumnInfo> columnList = DatabaseHelper.GetColumnList(this.treeTables.SelectedNode.Text);

            this.ShowColumnInfo(columnList);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FrmConfigEdit frm = new FrmConfigEdit();
            frm.ShowDialog();
        }

        private void btnGenerateEntityClass_Click(object sender, EventArgs e)
        {
            if (AssertSelectOneTable())
            {
                FrmGenerateEntityClass frm = new FrmGenerateEntityClass();
                frm.Init(treeTables.SelectedNode.Text, this.GetColumnInfoList());
                frm.Show();
            }
        }

        private void btnGenerateInsertStatements_Click(object sender, EventArgs e)
        {
            if (AssertSelectOneTable())
            {
                FrmGenerateInsertStatement frm = new FrmGenerateInsertStatement();
                frm.Init(treeTables.SelectedNode.Text);
                frm.Show();
            }
        }

        #region 私有方法

        private void 获取列信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.treeTables.SelectedNode != null)
            {
                if (treeTables.SelectedNode.Text == "用户表" || treeTables.SelectedNode.Text == "视图") return;

                List<ColumnInfo> columnList = DatabaseHelper.GetColumnList(this.treeTables.SelectedNode.Text);

                this.ShowColumnInfo(columnList);
            }
        }
        
        private void ShowColumnInfo(List<ColumnInfo> columnList)
        {
            this.gridColumns.Rows.Clear();

            foreach (ColumnInfo column in columnList)
            {
                int index = gridColumns.Rows.Add(column.Name,
                                                 column.TypeName,
                                                 column.Length,
                                                 column.IsIdentity,
                                                 //column.PrivateFieldName,
                                                 column.PublicPropertyName,
                                                 column.CodeTypeName,
                                                 column.Remark
                                                 );

                gridColumns.Rows[index].Tag = column;
            }
        }

        private List<ColumnInfo> GetColumnInfoList()
        {
            List<ColumnInfo> columnList = new List<ColumnInfo>();

            foreach (DataGridViewRow row in this.gridColumns.Rows)
            {
                ColumnInfo columnInfo = row.Tag as ColumnInfo;

                columnInfo.PublicPropertyName = row.Cells["Column_PropertyName"].Value.ToString();
                columnInfo.CodeTypeName = row.Cells["Column_PropertyType"].Value.ToString();

                object obj = row.Cells["Column_PropertyRemark"].Value;

                columnInfo.Remark = obj != null ? obj.ToString() : string.Empty;

                columnList.Add(columnInfo);
            }
            return columnList;
        }

        private void 获取列详细信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.treeTables.SelectedNode != null)
            {
                if (treeTables.SelectedNode.Text == "用户表" || treeTables.SelectedNode.Text == "视图") return;

                DataTable dt = DatabaseHelper.GetColumnInfoDataTable(this.treeTables.SelectedNode.Text);
                FrmColumnDataTable frm = new FrmColumnDataTable();
                frm.Init(dt);
                frm.Show();
            }
        }

        private void 查看所有行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.treeTables.SelectedNode != null)
            {
                if (treeTables.SelectedNode.Text == "用户表" || treeTables.SelectedNode.Text == "视图") return;

                DataTable dt = DatabaseHelper.GetTableData(this.treeTables.SelectedNode.Text);
                FrmQueryData frm = new FrmQueryData();
                frm.Init(dt);
                frm.Show();
            }

        }

        private bool AssertSelectOneTable()
        {
            if (treeTables.SelectedNode == null || treeTables.SelectedNode.Text == "用户表" || treeTables.SelectedNode.Text == "视图")
            {
                MessageBox.Show("请选择一个表结点");
                return false;
            }

            return true;
        }

        #endregion

    }
}
