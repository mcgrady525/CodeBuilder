namespace CodeBuilder
{
    partial class FrmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeTables = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看所有行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.获取列信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.获取列详细信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumns = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column_PropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_PropertyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_PropertyRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnGenerateEntityClass = new System.Windows.Forms.Button();
            this.btnGenerateInsertStatements = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridColumns)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeTables);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridColumns);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(879, 556);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeTables
            // 
            this.treeTables.ContextMenuStrip = this.contextMenuStrip1;
            this.treeTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeTables.HideSelection = false;
            this.treeTables.Location = new System.Drawing.Point(0, 0);
            this.treeTables.Name = "treeTables";
            this.treeTables.Size = new System.Drawing.Size(195, 556);
            this.treeTables.TabIndex = 0;
            this.treeTables.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeTables_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看所有行ToolStripMenuItem,
            this.toolStripSeparator1,
            this.获取列信息ToolStripMenuItem,
            this.获取列详细信息ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 76);
            // 
            // 查看所有行ToolStripMenuItem
            // 
            this.查看所有行ToolStripMenuItem.Name = "查看所有行ToolStripMenuItem";
            this.查看所有行ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.查看所有行ToolStripMenuItem.Text = "查看所有行...";
            this.查看所有行ToolStripMenuItem.Click += new System.EventHandler(this.查看所有行ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // 获取列信息ToolStripMenuItem
            // 
            this.获取列信息ToolStripMenuItem.Name = "获取列信息ToolStripMenuItem";
            this.获取列信息ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.获取列信息ToolStripMenuItem.Text = "获取列信息";
            this.获取列信息ToolStripMenuItem.Click += new System.EventHandler(this.获取列信息ToolStripMenuItem_Click);
            // 
            // 获取列详细信息ToolStripMenuItem
            // 
            this.获取列详细信息ToolStripMenuItem.Name = "获取列详细信息ToolStripMenuItem";
            this.获取列详细信息ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.获取列详细信息ToolStripMenuItem.Text = "获取列详细信息...";
            this.获取列详细信息ToolStripMenuItem.Click += new System.EventHandler(this.获取列详细信息ToolStripMenuItem_Click);
            // 
            // gridColumns
            // 
            this.gridColumns.AllowUserToAddRows = false;
            this.gridColumns.AllowUserToDeleteRows = false;
            this.gridColumns.ColumnHeadersHeight = 20;
            this.gridColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column_PropertyName,
            this.Column_PropertyType,
            this.Column_PropertyRemark});
            this.gridColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridColumns.Location = new System.Drawing.Point(0, 34);
            this.gridColumns.Name = "gridColumns";
            this.gridColumns.RowHeadersWidth = 20;
            this.gridColumns.RowTemplate.Height = 25;
            this.gridColumns.Size = new System.Drawing.Size(680, 522);
            this.gridColumns.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "列名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 140;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "类型";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "长度";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 40;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "标识";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 40;
            // 
            // Column_PropertyName
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Column_PropertyName.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column_PropertyName.HeaderText = "属性名";
            this.Column_PropertyName.Name = "Column_PropertyName";
            this.Column_PropertyName.Width = 140;
            // 
            // Column_PropertyType
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Column_PropertyType.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column_PropertyType.HeaderText = "属性类型";
            this.Column_PropertyType.Name = "Column_PropertyType";
            this.Column_PropertyType.Width = 80;
            // 
            // Column_PropertyRemark
            // 
            this.Column_PropertyRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Column_PropertyRemark.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column_PropertyRemark.HeaderText = "描述";
            this.Column_PropertyRemark.Name = "Column_PropertyRemark";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfig);
            this.panel1.Controls.Add(this.btnGenerateInsertStatements);
            this.panel1.Controls.Add(this.btnGenerateEntityClass);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 34);
            this.panel1.TabIndex = 1;
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(7, 3);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(94, 25);
            this.btnConfig.TabIndex = 0;
            this.btnConfig.Text = "配置生成参数";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnGenerateEntityClass
            // 
            this.btnGenerateEntityClass.Location = new System.Drawing.Point(107, 3);
            this.btnGenerateEntityClass.Name = "btnGenerateEntityClass";
            this.btnGenerateEntityClass.Size = new System.Drawing.Size(98, 25);
            this.btnGenerateEntityClass.TabIndex = 0;
            this.btnGenerateEntityClass.Text = "生成实体类";
            this.btnGenerateEntityClass.UseVisualStyleBackColor = true;
            this.btnGenerateEntityClass.Click += new System.EventHandler(this.btnGenerateEntityClass_Click);
            // 
            // btnGenerateInsertStatements
            // 
            this.btnGenerateInsertStatements.Location = new System.Drawing.Point(211, 3);
            this.btnGenerateInsertStatements.Name = "btnGenerateInsertStatements";
            this.btnGenerateInsertStatements.Size = new System.Drawing.Size(98, 25);
            this.btnGenerateInsertStatements.TabIndex = 0;
            this.btnGenerateInsertStatements.Text = "生成Insert语句";
            this.btnGenerateInsertStatements.UseVisualStyleBackColor = true;
            this.btnGenerateInsertStatements.Click += new System.EventHandler(this.btnGenerateInsertStatements_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 556);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SqlServer代码生成器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridColumns)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeTables;
        private System.Windows.Forms.DataGridView gridColumns;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 获取列信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 获取列详细信息ToolStripMenuItem;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_PropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_PropertyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_PropertyRemark;
        private System.Windows.Forms.ToolStripMenuItem 查看所有行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnGenerateEntityClass;
        private System.Windows.Forms.Button btnGenerateInsertStatements;
    }
}