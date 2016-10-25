using CodeBuilder.Common;
using CodeBuilder.Model.Common;
using CodeBuilder.Model.Domain;
using CodeBuilder.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tracy.Frameworks.Common.Extends;

namespace CodeBuilder
{
    public partial class FrmMultiTableGenerate : Form
    {
        private static readonly CommonService commonService = new CommonService();
        private List<string> tableViews = new List<string>();

        public FrmMultiTableGenerate()
        {
            InitializeComponent();

            //初始化
            InitControls();
        }

        /// <summary>
        /// 控件初始化
        /// </summary>
        private void InitControls()
        {
            //代码类型默认为数据库实体
            this.rb_CodeType_POCO.Checked = true;
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
        /// 初始化
        /// </summary>
        /// <param name="request"></param>
        public void Init(InitMultiTableRequest request)
        {
            this.lbl_SelectDB_CurrentServer.Text = request.CurrentServer;
            this.lbl_SelectDB_CurrentDB.Text = request.CurrentDB;

            if (request.TableViews.HasValue())
            {
                this.lb_SelectTable_Left.Items.AddRange(request.TableViews.ToArray());
            }

            //字段赋值
            tableViews = request.TableViews;
        }

        /// <summary>
        /// 选择输出目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutPut_Select_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            this.txt_OutPut_Path.Text = fbd.SelectedPath;
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Operation_OK_Click(object sender, EventArgs e)
        {
            var result = string.Empty;
            try
            {
                //校验
                if (!CheckInput())
                {
                    return;
                }

                var requests = new List<CreateCodeRequest>();
                for (int i = 0; i < this.lb_SelectTable_Right.Items.Count; i++)
                {
                    var tableName = (string)this.lb_SelectTable_Right.Items[i];
                    var request = new CreateCodeRequest
                    {
                        DBName = this.lbl_SelectDB_CurrentDB.Text,
                        TableName = tableName,
                        GenerateType = Model.Common.GenerateType.MultiTable,
                        TopNameSpace = this.txt_ParamConfig_TopNameSpace.Text.IsNullOrEmpty() ? "" : this.txt_ParamConfig_TopNameSpace.Text.Trim(),
                        SecondNameSpace = this.txt_ParamConfig_SecondNameSpace.Text.IsNullOrEmpty() ? "" : this.txt_ParamConfig_SecondNameSpace.Text.Trim(),
                        CodeType = this.rb_CodeType_POCO.Checked ? CodeType.POCOEntity : this.rb_CodeType_DAL.Checked ? CodeType.DAL : this.rb_CodeType_Service.Checked ? CodeType.Service : CodeType.POCOEntity,
                        OutPutPath = this.txt_OutPut_Path.Text.Trim()
                    };
                    requests.Add(request);
                }

                //使用并行
                //使用并行会有各种问题，先不使用多线程
                if (requests.HasValue())
                {
                    //按tableName排序
                    requests = requests.OrderBy(p => p.TableName).ToList();

                    foreach (var item in requests)
                    {
                        commonService.CreateCode(item);
                    }
                }

                result = "批量生成代码成功!";
            }
            catch (Exception ex)
            {
                result = string.Format("批量生成代码失败,失败原因:{0}", ex.ToString());
            }

            MessageBox.Show(result);
        }

        /// <summary>
        /// 输入校验
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            //选择表和视图
            //输入顶级和二级命名空间
            //选择输出目录
            if (this.lb_SelectTable_Right.Items.Count == 0)
            {
                MessageBox.Show("请选择表或视图!");
                return false;
            }
            if (this.txt_ParamConfig_TopNameSpace.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入顶级命名空间!");
                return false;
            }
            if (this.txt_ParamConfig_SecondNameSpace.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入二级命名空间!");
                return false;
            }
            if (this.txt_OutPut_Path.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请选择输出目录!");
                return false;
            }

            return true;
        }

        //关闭
        private void btn_Operation_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 选择表和视图

        //全选
        private void btn_SelectTable_All_Click(object sender, EventArgs e)
        {
            if (this.lb_SelectTable_Left.Items.Count > 0)
            {
                this.lb_SelectTable_Right.Items.AddRange(this.lb_SelectTable_Left.Items);
                this.lb_SelectTable_Left.Items.Clear();
            }
        }

        //全不选
        private void btn_SelectTable_UnAll_Click(object sender, EventArgs e)
        {
            if (this.lb_SelectTable_Right.Items.Count > 0)
            {
                this.lb_SelectTable_Left.Items.AddRange(this.lb_SelectTable_Right.Items);
                this.lb_SelectTable_Right.Items.Clear();
            }
        }

        //选择当前
        private void btn_SelectTable_SelectOne_Click(object sender, EventArgs e)
        {
            if (this.lb_SelectTable_Left.Items.Count > 0 && this.lb_SelectTable_Left.SelectedItems.Count > 0)
            {
                //右加左减
                var selectedItems = this.lb_SelectTable_Left.SelectedItems;
                for (int i = 0; i < selectedItems.Count; i++)
                {
                    this.lb_SelectTable_Right.Items.Add(selectedItems[i]);
                }

                for (int i = selectedItems.Count - 1; i >= 0; i--)
                {
                    this.lb_SelectTable_Left.Items.Remove(selectedItems[i]);
                }
            }
        }

        //取消当前
        private void btn_SelectTable_UnSelectOne_Click(object sender, EventArgs e)
        {
            if (this.lb_SelectTable_Right.Items.Count > 0 && this.lb_SelectTable_Right.SelectedItems.Count > 0)
            {
                //左加右减
                var selectedItems = this.lb_SelectTable_Right.SelectedItems;
                for (int i = 0; i < selectedItems.Count; i++)
                {
                    this.lb_SelectTable_Left.Items.Add(selectedItems[i]);
                }

                for (int i = selectedItems.Count - 1; i >= 0; i--)
                {
                    this.lb_SelectTable_Right.Items.Remove(selectedItems[i]);
                }
            }
        }
        #endregion
    }
}
