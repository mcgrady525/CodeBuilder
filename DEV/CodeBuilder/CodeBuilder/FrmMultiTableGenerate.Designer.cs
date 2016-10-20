namespace CodeBuilder
{
    partial class FrmMultiTableGenerate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_SelectDB_CurrentServer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_SelectDB_CurrentDB = new System.Windows.Forms.Label();
            this.lb_SelectTable_Left = new System.Windows.Forms.ListBox();
            this.btn_SelectTable_All = new System.Windows.Forms.Button();
            this.btn_SelectTable_SelectOne = new System.Windows.Forms.Button();
            this.btn_SelectTable_UnSelectOne = new System.Windows.Forms.Button();
            this.btn_SelectTable_UnAll = new System.Windows.Forms.Button();
            this.lb_SelectTable_Right = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_OutPut_Path = new System.Windows.Forms.TextBox();
            this.btn_OutPut_Select = new System.Windows.Forms.Button();
            this.btn_Operation_OK = new System.Windows.Forms.Button();
            this.btn_Operation_Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(684, 562);
            this.splitContainer1.SplitterDistance = 467;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(684, 467);
            this.splitContainer2.SplitterDistance = 343;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer3.Size = new System.Drawing.Size(684, 343);
            this.splitContainer3.SplitterDistance = 76;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_SelectDB_CurrentDB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbl_SelectDB_CurrentServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择数据库";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_SelectTable_UnAll);
            this.groupBox2.Controls.Add(this.btn_SelectTable_UnSelectOne);
            this.groupBox2.Controls.Add(this.btn_SelectTable_SelectOne);
            this.groupBox2.Controls.Add(this.btn_SelectTable_All);
            this.groupBox2.Controls.Add(this.lb_SelectTable_Right);
            this.groupBox2.Controls.Add(this.lb_SelectTable_Left);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(684, 263);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择表和视图";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_OutPut_Select);
            this.groupBox3.Controls.Add(this.txt_OutPut_Path);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(684, 120);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "输出目录";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_Operation_Close);
            this.groupBox4.Controls.Add(this.btn_Operation_OK);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(684, 91);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "操作";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前服务器：";
            // 
            // lbl_SelectDB_CurrentServer
            // 
            this.lbl_SelectDB_CurrentServer.AutoSize = true;
            this.lbl_SelectDB_CurrentServer.Location = new System.Drawing.Point(120, 26);
            this.lbl_SelectDB_CurrentServer.Name = "lbl_SelectDB_CurrentServer";
            this.lbl_SelectDB_CurrentServer.Size = new System.Drawing.Size(41, 12);
            this.lbl_SelectDB_CurrentServer.TabIndex = 1;
            this.lbl_SelectDB_CurrentServer.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "当前数据库：";
            // 
            // lbl_SelectDB_CurrentDB
            // 
            this.lbl_SelectDB_CurrentDB.AutoSize = true;
            this.lbl_SelectDB_CurrentDB.Location = new System.Drawing.Point(552, 26);
            this.lbl_SelectDB_CurrentDB.Name = "lbl_SelectDB_CurrentDB";
            this.lbl_SelectDB_CurrentDB.Size = new System.Drawing.Size(41, 12);
            this.lbl_SelectDB_CurrentDB.TabIndex = 1;
            this.lbl_SelectDB_CurrentDB.Text = "label2";
            // 
            // lb_SelectTable_Left
            // 
            this.lb_SelectTable_Left.FormattingEnabled = true;
            this.lb_SelectTable_Left.ItemHeight = 12;
            this.lb_SelectTable_Left.Location = new System.Drawing.Point(22, 34);
            this.lb_SelectTable_Left.Name = "lb_SelectTable_Left";
            this.lb_SelectTable_Left.ScrollAlwaysVisible = true;
            this.lb_SelectTable_Left.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_SelectTable_Left.Size = new System.Drawing.Size(180, 196);
            this.lb_SelectTable_Left.TabIndex = 0;
            // 
            // btn_SelectTable_All
            // 
            this.btn_SelectTable_All.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectTable_All.Location = new System.Drawing.Point(221, 43);
            this.btn_SelectTable_All.Name = "btn_SelectTable_All";
            this.btn_SelectTable_All.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectTable_All.TabIndex = 1;
            this.btn_SelectTable_All.Text = ">>";
            this.btn_SelectTable_All.UseVisualStyleBackColor = true;
            this.btn_SelectTable_All.Click += new System.EventHandler(this.btn_SelectTable_All_Click);
            // 
            // btn_SelectTable_SelectOne
            // 
            this.btn_SelectTable_SelectOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectTable_SelectOne.Location = new System.Drawing.Point(221, 89);
            this.btn_SelectTable_SelectOne.Name = "btn_SelectTable_SelectOne";
            this.btn_SelectTable_SelectOne.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectTable_SelectOne.TabIndex = 1;
            this.btn_SelectTable_SelectOne.Text = ">";
            this.btn_SelectTable_SelectOne.UseVisualStyleBackColor = true;
            this.btn_SelectTable_SelectOne.Click += new System.EventHandler(this.btn_SelectTable_SelectOne_Click);
            // 
            // btn_SelectTable_UnSelectOne
            // 
            this.btn_SelectTable_UnSelectOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectTable_UnSelectOne.Location = new System.Drawing.Point(221, 132);
            this.btn_SelectTable_UnSelectOne.Name = "btn_SelectTable_UnSelectOne";
            this.btn_SelectTable_UnSelectOne.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectTable_UnSelectOne.TabIndex = 1;
            this.btn_SelectTable_UnSelectOne.Text = "<";
            this.btn_SelectTable_UnSelectOne.UseVisualStyleBackColor = true;
            this.btn_SelectTable_UnSelectOne.Click += new System.EventHandler(this.btn_SelectTable_UnSelectOne_Click);
            // 
            // btn_SelectTable_UnAll
            // 
            this.btn_SelectTable_UnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectTable_UnAll.Location = new System.Drawing.Point(221, 177);
            this.btn_SelectTable_UnAll.Name = "btn_SelectTable_UnAll";
            this.btn_SelectTable_UnAll.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectTable_UnAll.TabIndex = 1;
            this.btn_SelectTable_UnAll.Text = "<<";
            this.btn_SelectTable_UnAll.UseVisualStyleBackColor = true;
            this.btn_SelectTable_UnAll.Click += new System.EventHandler(this.btn_SelectTable_UnAll_Click);
            // 
            // lb_SelectTable_Right
            // 
            this.lb_SelectTable_Right.FormattingEnabled = true;
            this.lb_SelectTable_Right.ItemHeight = 12;
            this.lb_SelectTable_Right.Location = new System.Drawing.Point(329, 34);
            this.lb_SelectTable_Right.Name = "lb_SelectTable_Right";
            this.lb_SelectTable_Right.ScrollAlwaysVisible = true;
            this.lb_SelectTable_Right.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_SelectTable_Right.Size = new System.Drawing.Size(180, 196);
            this.lb_SelectTable_Right.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "输出目录：";
            // 
            // txt_OutPut_Path
            // 
            this.txt_OutPut_Path.Location = new System.Drawing.Point(109, 36);
            this.txt_OutPut_Path.Name = "txt_OutPut_Path";
            this.txt_OutPut_Path.Size = new System.Drawing.Size(370, 21);
            this.txt_OutPut_Path.TabIndex = 1;
            // 
            // btn_OutPut_Select
            // 
            this.btn_OutPut_Select.Location = new System.Drawing.Point(498, 34);
            this.btn_OutPut_Select.Name = "btn_OutPut_Select";
            this.btn_OutPut_Select.Size = new System.Drawing.Size(75, 23);
            this.btn_OutPut_Select.TabIndex = 2;
            this.btn_OutPut_Select.Text = "选择...";
            this.btn_OutPut_Select.UseVisualStyleBackColor = true;
            this.btn_OutPut_Select.Click += new System.EventHandler(this.btn_OutPut_Select_Click);
            // 
            // btn_Operation_OK
            // 
            this.btn_Operation_OK.Location = new System.Drawing.Point(22, 44);
            this.btn_Operation_OK.Name = "btn_Operation_OK";
            this.btn_Operation_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_Operation_OK.TabIndex = 0;
            this.btn_Operation_OK.Text = "确定";
            this.btn_Operation_OK.UseVisualStyleBackColor = true;
            this.btn_Operation_OK.Click += new System.EventHandler(this.btn_Operation_OK_Click);
            // 
            // btn_Operation_Close
            // 
            this.btn_Operation_Close.Location = new System.Drawing.Point(136, 44);
            this.btn_Operation_Close.Name = "btn_Operation_Close";
            this.btn_Operation_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Operation_Close.TabIndex = 0;
            this.btn_Operation_Close.Text = "关闭";
            this.btn_Operation_Close.UseVisualStyleBackColor = true;
            this.btn_Operation_Close.Click += new System.EventHandler(this.btn_Operation_Close_Click);
            // 
            // FrmMultiTableGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 562);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMultiTableGenerate";
            this.Text = "批量生成";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbl_SelectDB_CurrentDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_SelectDB_CurrentServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lb_SelectTable_Left;
        private System.Windows.Forms.Button btn_SelectTable_UnAll;
        private System.Windows.Forms.Button btn_SelectTable_UnSelectOne;
        private System.Windows.Forms.Button btn_SelectTable_SelectOne;
        private System.Windows.Forms.Button btn_SelectTable_All;
        private System.Windows.Forms.ListBox lb_SelectTable_Right;
        private System.Windows.Forms.Button btn_OutPut_Select;
        private System.Windows.Forms.TextBox txt_OutPut_Path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Operation_OK;
        private System.Windows.Forms.Button btn_Operation_Close;
    }
}