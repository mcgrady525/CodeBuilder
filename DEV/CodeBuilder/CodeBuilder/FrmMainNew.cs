using CodeBuilder.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeBuilder.Common;
using CodeBuilder.Model.Template;
using CodeBuilder.Model.Domain;
using CodeBuilder.Model.Common;
using Tracy.Frameworks.Common.Extends;

namespace CodeBuilder
{
    public partial class FrmMainNew : Form
    {
        //数据库连接字符串
        public static string s_ConnectString = string.Empty;
        public static string s_CurrentDB = string.Empty;

        private static readonly CommonService commonService = new CommonService();

        public FrmMainNew()
        {
            InitializeComponent();

            //初始化
            InitControls();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitControls()
        {
            //生成类型默认为单表生成
            //代码类型默认为数据库实体，并展示代码模板路径
            //操作中默认只启用单表生成按钮，禁用批量生成按钮
            this.rb_GenerateType_SingleTable.Checked = true;
            this.rb_CodeType_POCO.Checked = true;
            this.btn_Operation_Batch.Enabled = false;

            //状态栏
            this.toolStripStatusLabel1.Alignment = ToolStripItemAlignment.Left;
            this.toolStripStatusLabel1.Text = "当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            this.toolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
            this.toolStripStatusLabel2.Text = "当前数据库：" + s_CurrentDB;

            this.timer1.Interval = 1000;//1秒更新一次
            this.timer1.Start();
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

            //显示类名
            this.txt_ParamConfig_ClassName.Text = CodeBuilderHelper.GetClassNameByTableName(this.treeView1.SelectedNode.Text);
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

        /// <summary>
        /// 生成类型单选按钮选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_GenerateType_CheckedChange(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }

            switch (((RadioButton)sender).Text.ToString())
            {
                case "单表生成":
                    this.btn_Operation_Single.Enabled = true;
                    this.btn_Operation_Batch.Enabled = false;
                    break;
                case "批量生成":
                    this.btn_Operation_Single.Enabled = false;
                    this.btn_Operation_Batch.Enabled = true;
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// 代码类型单选按钮选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_CodeType_CheckedChange(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }

            var templatePath = string.Empty;
            switch (((RadioButton)sender).Text.ToString())
            {
                case "数据库实体":
                    templatePath = ConfigHelper.GetAppSetting("POCOEntityTemplate");
                    break;
                case "DAL":
                    templatePath = ConfigHelper.GetAppSetting("DALTemplate");
                    break;
                case "Service":
                    templatePath = ConfigHelper.GetAppSetting("ServiceTemplate");
                    break;
                default:
                    break;
            }

            this.lblTemplatePath.Text = ConfigHelper.BASEDIRECTORY + templatePath;
        }

        /// <summary>
        /// 单表生成代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Operation_Single_Click(object sender, EventArgs e)
        {
            //验证
            if (!CheckSingleTableInput())
            {
                return;
            }

            var request = new CreateCodeRequest
            {
                DBName = s_CurrentDB,
                TableName = this.treeView1.SelectedNode.Text,
                GenerateType = this.rb_GenerateType_SingleTable.Checked ? GenerateType.SingleTable : this.rb_GenerateType_Batch.Checked ? GenerateType.MultiTable : GenerateType.SingleTable,
                ClassName= CodeBuilderHelper.GetClassNameByTableName(this.treeView1.SelectedNode.Text),
                TopNameSpace= this.txt_ParamConfig_TopNameSpace.Text,
                SecondNameSpace= this.txt_ParamConfig_SecondNameSpace.Text,
                CodeType= this.rb_CodeType_POCO.Checked? CodeType.POCOEntity: this.rb_CodeType_DAL.Checked? CodeType.DAL: this.rb_CodeType_Service.Checked? CodeType.Service: CodeType.POCOEntity
            };
            var result = commonService.GenerateSingleTableCode(request);

            FrmSingleTableGenerate frmSingleTable = new FrmSingleTableGenerate();
            frmSingleTable.Init(result);
            frmSingleTable.Show();
        }

        private bool CheckSingleTableInput()
        {
            if (this.treeView1.SelectedNode.Text.IsNullOrEmpty() || this.treeView1.SelectedNode.Text.Equals("用户表") || this.treeView1.SelectedNode.Text.Equals("视图"))
            {
                MessageBox.Show("请选择要生成的表或视图!");
                return false;
            }

            if (this.txt_ParamConfig_TopNameSpace.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入顶级命名空间");
                return false;
            }

            if (this.txt_ParamConfig_SecondNameSpace.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入二级命名空间");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 批量生成代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Operation_Batch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("批量生成!");
        }

        /// <summary>
        /// 计时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

    }
}
