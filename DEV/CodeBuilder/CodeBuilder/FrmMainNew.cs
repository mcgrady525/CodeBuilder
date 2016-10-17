using CodeBuilder.Service;
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
    public partial class FrmMainNew : Form
    {
        //数据库连接字符串
        public static string s_ConnectString = string.Empty;

        private static readonly CommonService commonService = new CommonService();

        public FrmMainNew()
        {
            InitializeComponent();

            //初始化

        }

        /// <summary>
        /// 主界面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMainNew_Load(object sender, EventArgs e)
        {
            List<string> tables = commonService.GetTableOrViewList(true);
            TreeNode tableNode = this.treeView1.Nodes.Add("用户表");
            foreach (string item in tables)
            {
                tableNode.Nodes.Add(item);
            }

            List<string> views = commonService.GetTableOrViewList(false);
            TreeNode viewNode = this.treeView1.Nodes.Add("视图");
            foreach (string item in views)
            {
                viewNode.Nodes.Add(item);
            }

            treeView1.ExpandAll();

        }

        /// <summary>
        /// treeView1选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "用户表" || e.Node.Text == "视图")
            {
                return;
            }

            var columns = commonService.GetTableSchemaInfo(this.treeView1.SelectedNode.Text);
            this.ShowColumnInfo(columns);
        }

        #region Private method

        private void ShowColumnInfo(List<ColumnInfo> columnList)
        {
            this.dataGridView1.Rows.Clear();

            foreach (ColumnInfo column in columnList)
            {
                int index = dataGridView1.Rows.Add(column.Name,
                                                 column.TypeName,
                                                 column.Length,
                                                 column.IsIdentity,
                                                 column.IsPrimaryKey,
                                                 column.IsNullalbe,
                                                 column.PublicPropertyName,
                                                 column.CodeTypeName,
                                                 column.Remark);

                dataGridView1.Rows[index].Tag = column;
            }
        }

        #endregion



    }
}
