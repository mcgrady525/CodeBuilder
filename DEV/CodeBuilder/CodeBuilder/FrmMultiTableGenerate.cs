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
    }
}
