using CodeBuilder.Model.Common;
using CodeBuilder.Model.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tracy.Frameworks.Common.Extends;

namespace CodeBuilder
{
    public partial class FrmMultiTableGenerate : Form
    {
        private string topNameSpace = string.Empty;
        private string secondNameSpace = string.Empty;
        private CodeType codeType = CodeType.POCOEntity;
        private List<string> tableViews = new List<string>();

        public FrmMultiTableGenerate()
        {
            InitializeComponent();
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
            topNameSpace = request.TopNameSpace;
            secondNameSpace = request.SecondNameSpace;
            codeType = request.CodeType;
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
            //批量生成代码



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
