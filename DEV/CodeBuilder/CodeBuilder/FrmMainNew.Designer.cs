namespace CodeBuilder
{
    partial class FrmMainNew
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.gpGenerateType = new System.Windows.Forms.GroupBox();
            this.rb_GenerateType_Batch = new System.Windows.Forms.RadioButton();
            this.rb_GenerateType_SingleTable = new System.Windows.Forms.RadioButton();
            this.gpParamConfig = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ParamConfig_SecondNameSpace = new System.Windows.Forms.TextBox();
            this.txt_ParamConfig_TopNameSpace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ParamConfig_ClassName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.gpCodeType = new System.Windows.Forms.GroupBox();
            this.rb_CodeType_Service = new System.Windows.Forms.RadioButton();
            this.rb_CodeType_DAL = new System.Windows.Forms.RadioButton();
            this.rb_CodeType_POCO = new System.Windows.Forms.RadioButton();
            this.gpOperation = new System.Windows.Forms.GroupBox();
            this.btn_Operation_Batch = new System.Windows.Forms.Button();
            this.btn_Operation_Single = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTemplatePath = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
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
            this.gpGenerateType.SuspendLayout();
            this.gpParamConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.gpCodeType.SuspendLayout();
            this.gpOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(964, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(964, 660);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(244, 660);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 280);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(716, 380);
            this.splitContainer2.SplitterDistance = 164;
            this.splitContainer2.TabIndex = 1;
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
            this.splitContainer3.Panel1.Controls.Add(this.gpGenerateType);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gpParamConfig);
            this.splitContainer3.Size = new System.Drawing.Size(716, 164);
            this.splitContainer3.SplitterDistance = 51;
            this.splitContainer3.TabIndex = 0;
            // 
            // gpGenerateType
            // 
            this.gpGenerateType.Controls.Add(this.rb_GenerateType_Batch);
            this.gpGenerateType.Controls.Add(this.rb_GenerateType_SingleTable);
            this.gpGenerateType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpGenerateType.Location = new System.Drawing.Point(0, 0);
            this.gpGenerateType.Name = "gpGenerateType";
            this.gpGenerateType.Size = new System.Drawing.Size(716, 51);
            this.gpGenerateType.TabIndex = 0;
            this.gpGenerateType.TabStop = false;
            this.gpGenerateType.Text = "生成类型";
            // 
            // rb_GenerateType_Batch
            // 
            this.rb_GenerateType_Batch.AutoSize = true;
            this.rb_GenerateType_Batch.Location = new System.Drawing.Point(107, 20);
            this.rb_GenerateType_Batch.Name = "rb_GenerateType_Batch";
            this.rb_GenerateType_Batch.Size = new System.Drawing.Size(71, 16);
            this.rb_GenerateType_Batch.TabIndex = 1;
            this.rb_GenerateType_Batch.TabStop = true;
            this.rb_GenerateType_Batch.Text = "批量生成";
            this.rb_GenerateType_Batch.UseVisualStyleBackColor = true;
            this.rb_GenerateType_Batch.CheckedChanged += new System.EventHandler(this.rb_GenerateType_CheckedChange);
            // 
            // rb_GenerateType_SingleTable
            // 
            this.rb_GenerateType_SingleTable.AutoSize = true;
            this.rb_GenerateType_SingleTable.Location = new System.Drawing.Point(18, 20);
            this.rb_GenerateType_SingleTable.Name = "rb_GenerateType_SingleTable";
            this.rb_GenerateType_SingleTable.Size = new System.Drawing.Size(71, 16);
            this.rb_GenerateType_SingleTable.TabIndex = 0;
            this.rb_GenerateType_SingleTable.TabStop = true;
            this.rb_GenerateType_SingleTable.Text = "单表生成";
            this.rb_GenerateType_SingleTable.UseVisualStyleBackColor = true;
            this.rb_GenerateType_SingleTable.CheckedChanged += new System.EventHandler(this.rb_GenerateType_CheckedChange);
            // 
            // gpParamConfig
            // 
            this.gpParamConfig.Controls.Add(this.label3);
            this.gpParamConfig.Controls.Add(this.txt_ParamConfig_SecondNameSpace);
            this.gpParamConfig.Controls.Add(this.txt_ParamConfig_TopNameSpace);
            this.gpParamConfig.Controls.Add(this.label2);
            this.gpParamConfig.Controls.Add(this.txt_ParamConfig_ClassName);
            this.gpParamConfig.Controls.Add(this.label1);
            this.gpParamConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpParamConfig.Location = new System.Drawing.Point(0, 0);
            this.gpParamConfig.Name = "gpParamConfig";
            this.gpParamConfig.Size = new System.Drawing.Size(716, 109);
            this.gpParamConfig.TabIndex = 0;
            this.gpParamConfig.TabStop = false;
            this.gpParamConfig.Text = "参数配置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "二级命名空间：";
            // 
            // txt_ParamConfig_SecondNameSpace
            // 
            this.txt_ParamConfig_SecondNameSpace.Location = new System.Drawing.Point(366, 63);
            this.txt_ParamConfig_SecondNameSpace.Name = "txt_ParamConfig_SecondNameSpace";
            this.txt_ParamConfig_SecondNameSpace.Size = new System.Drawing.Size(134, 21);
            this.txt_ParamConfig_SecondNameSpace.TabIndex = 1;
            // 
            // txt_ParamConfig_TopNameSpace
            // 
            this.txt_ParamConfig_TopNameSpace.Location = new System.Drawing.Point(111, 63);
            this.txt_ParamConfig_TopNameSpace.Name = "txt_ParamConfig_TopNameSpace";
            this.txt_ParamConfig_TopNameSpace.Size = new System.Drawing.Size(134, 21);
            this.txt_ParamConfig_TopNameSpace.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "顶级命名空间：";
            // 
            // txt_ParamConfig_ClassName
            // 
            this.txt_ParamConfig_ClassName.Location = new System.Drawing.Point(63, 24);
            this.txt_ParamConfig_ClassName.Name = "txt_ParamConfig_ClassName";
            this.txt_ParamConfig_ClassName.Size = new System.Drawing.Size(115, 21);
            this.txt_ParamConfig_ClassName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类名：";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.gpCodeType);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.gpOperation);
            this.splitContainer4.Size = new System.Drawing.Size(716, 212);
            this.splitContainer4.SplitterDistance = 114;
            this.splitContainer4.TabIndex = 0;
            // 
            // gpCodeType
            // 
            this.gpCodeType.Controls.Add(this.lblTemplatePath);
            this.gpCodeType.Controls.Add(this.label4);
            this.gpCodeType.Controls.Add(this.rb_CodeType_Service);
            this.gpCodeType.Controls.Add(this.rb_CodeType_DAL);
            this.gpCodeType.Controls.Add(this.rb_CodeType_POCO);
            this.gpCodeType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpCodeType.Location = new System.Drawing.Point(0, 0);
            this.gpCodeType.Name = "gpCodeType";
            this.gpCodeType.Size = new System.Drawing.Size(716, 114);
            this.gpCodeType.TabIndex = 0;
            this.gpCodeType.TabStop = false;
            this.gpCodeType.Text = "代码类型";
            // 
            // rb_CodeType_Service
            // 
            this.rb_CodeType_Service.AutoSize = true;
            this.rb_CodeType_Service.Location = new System.Drawing.Point(185, 37);
            this.rb_CodeType_Service.Name = "rb_CodeType_Service";
            this.rb_CodeType_Service.Size = new System.Drawing.Size(65, 16);
            this.rb_CodeType_Service.TabIndex = 2;
            this.rb_CodeType_Service.TabStop = true;
            this.rb_CodeType_Service.Text = "Service";
            this.rb_CodeType_Service.UseVisualStyleBackColor = true;
            this.rb_CodeType_Service.CheckedChanged += new System.EventHandler(this.rb_CodeType_CheckedChange);
            // 
            // rb_CodeType_DAL
            // 
            this.rb_CodeType_DAL.AutoSize = true;
            this.rb_CodeType_DAL.Location = new System.Drawing.Point(111, 37);
            this.rb_CodeType_DAL.Name = "rb_CodeType_DAL";
            this.rb_CodeType_DAL.Size = new System.Drawing.Size(41, 16);
            this.rb_CodeType_DAL.TabIndex = 1;
            this.rb_CodeType_DAL.TabStop = true;
            this.rb_CodeType_DAL.Text = "DAL";
            this.rb_CodeType_DAL.UseVisualStyleBackColor = true;
            this.rb_CodeType_DAL.CheckedChanged += new System.EventHandler(this.rb_CodeType_CheckedChange);
            // 
            // rb_CodeType_POCO
            // 
            this.rb_CodeType_POCO.AutoSize = true;
            this.rb_CodeType_POCO.Location = new System.Drawing.Point(18, 37);
            this.rb_CodeType_POCO.Name = "rb_CodeType_POCO";
            this.rb_CodeType_POCO.Size = new System.Drawing.Size(83, 16);
            this.rb_CodeType_POCO.TabIndex = 0;
            this.rb_CodeType_POCO.TabStop = true;
            this.rb_CodeType_POCO.Text = "数据库实体";
            this.rb_CodeType_POCO.UseVisualStyleBackColor = true;
            this.rb_CodeType_POCO.CheckedChanged += new System.EventHandler(this.rb_CodeType_CheckedChange);
            // 
            // gpOperation
            // 
            this.gpOperation.Controls.Add(this.btn_Operation_Batch);
            this.gpOperation.Controls.Add(this.btn_Operation_Single);
            this.gpOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpOperation.Location = new System.Drawing.Point(0, 0);
            this.gpOperation.Name = "gpOperation";
            this.gpOperation.Size = new System.Drawing.Size(716, 94);
            this.gpOperation.TabIndex = 0;
            this.gpOperation.TabStop = false;
            this.gpOperation.Text = "操作";
            // 
            // btn_Operation_Batch
            // 
            this.btn_Operation_Batch.Location = new System.Drawing.Point(120, 29);
            this.btn_Operation_Batch.Name = "btn_Operation_Batch";
            this.btn_Operation_Batch.Size = new System.Drawing.Size(75, 23);
            this.btn_Operation_Batch.TabIndex = 0;
            this.btn_Operation_Batch.Text = "批量生成";
            this.btn_Operation_Batch.UseVisualStyleBackColor = true;
            this.btn_Operation_Batch.Click += new System.EventHandler(this.btn_Operation_Batch_Click);
            // 
            // btn_Operation_Single
            // 
            this.btn_Operation_Single.Location = new System.Drawing.Point(19, 29);
            this.btn_Operation_Single.Name = "btn_Operation_Single";
            this.btn_Operation_Single.Size = new System.Drawing.Size(75, 23);
            this.btn_Operation_Single.TabIndex = 0;
            this.btn_Operation_Single.Text = "单表生成";
            this.btn_Operation_Single.UseVisualStyleBackColor = true;
            this.btn_Operation_Single.Click += new System.EventHandler(this.btn_Operation_Single_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeight = 20;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(716, 280);
            this.dataGridView1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "代码模板：";
            // 
            // lblTemplatePath
            // 
            this.lblTemplatePath.AutoSize = true;
            this.lblTemplatePath.Location = new System.Drawing.Point(91, 72);
            this.lblTemplatePath.Name = "lblTemplatePath";
            this.lblTemplatePath.Size = new System.Drawing.Size(0, 12);
            this.lblTemplatePath.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "列名";
            this.Column1.Name = "Column1";
            this.Column1.Width = 140;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "类型";
            this.Column2.Name = "Column2";
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "长度";
            this.Column3.Name = "Column3";
            this.Column3.Width = 40;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "标识";
            this.Column4.Name = "Column4";
            this.Column4.Width = 40;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "主键";
            this.Column5.Name = "Column5";
            this.Column5.Width = 40;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "允许空";
            this.Column6.Name = "Column6";
            this.Column6.Width = 50;
            // 
            // Column7
            // 
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Column7.DefaultCellStyle = dataGridViewCellStyle28;
            this.Column7.HeaderText = "属性名";
            this.Column7.Name = "Column7";
            this.Column7.Width = 140;
            // 
            // Column8
            // 
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Column8.DefaultCellStyle = dataGridViewCellStyle29;
            this.Column8.HeaderText = "属性类型";
            this.Column8.Name = "Column8";
            this.Column8.Width = 80;
            // 
            // Column9
            // 
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Column9.DefaultCellStyle = dataGridViewCellStyle30;
            this.Column9.HeaderText = "描述";
            this.Column9.Name = "Column9";
            this.Column9.Width = 200;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmMainNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 682);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmMainNew";
            this.Text = "CodeBuilder代码生成器";
            this.Load += new System.EventHandler(this.FrmMainNew_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
            this.gpGenerateType.ResumeLayout(false);
            this.gpGenerateType.PerformLayout();
            this.gpParamConfig.ResumeLayout(false);
            this.gpParamConfig.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.gpCodeType.ResumeLayout(false);
            this.gpCodeType.PerformLayout();
            this.gpOperation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox gpGenerateType;
        private System.Windows.Forms.GroupBox gpParamConfig;
        private System.Windows.Forms.GroupBox gpCodeType;
        private System.Windows.Forms.GroupBox gpOperation;
        private System.Windows.Forms.RadioButton rb_GenerateType_Batch;
        private System.Windows.Forms.RadioButton rb_GenerateType_SingleTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ParamConfig_SecondNameSpace;
        private System.Windows.Forms.TextBox txt_ParamConfig_TopNameSpace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ParamConfig_ClassName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_CodeType_POCO;
        private System.Windows.Forms.Button btn_Operation_Batch;
        private System.Windows.Forms.Button btn_Operation_Single;
        private System.Windows.Forms.RadioButton rb_CodeType_Service;
        private System.Windows.Forms.RadioButton rb_CodeType_DAL;
        private System.Windows.Forms.Label lblTemplatePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Timer timer1;


    }
}