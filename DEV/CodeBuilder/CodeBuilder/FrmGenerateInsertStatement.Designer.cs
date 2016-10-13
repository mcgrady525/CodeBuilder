namespace CodeBuilder
{
    partial class FrmGenerateInsertStatement
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
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtWhereString = new System.Windows.Forms.TextBox();
            this.txtSelectColumns = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCopyAll = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerateInsertSql = new System.Windows.Forms.Button();
            this.chkIncludeIdentity = new System.Windows.Forms.CheckBox();
            this.chkGenerateTransaction = new System.Windows.Forms.CheckBox();
            this.lblDataCount = new System.Windows.Forms.Label();
            this.lblInsertCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(0, 0);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(710, 200);
            this.txtCode.TabIndex = 24;
            this.txtCode.WordWrap = false;
            // 
            // txtWhereString
            // 
            this.txtWhereString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWhereString.Location = new System.Drawing.Point(53, 53);
            this.txtWhereString.Name = "txtWhereString";
            this.txtWhereString.Size = new System.Drawing.Size(496, 21);
            this.txtWhereString.TabIndex = 25;
            // 
            // txtSelectColumns
            // 
            this.txtSelectColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectColumns.Location = new System.Drawing.Point(53, 4);
            this.txtSelectColumns.Name = "txtSelectColumns";
            this.txtSelectColumns.Size = new System.Drawing.Size(496, 21);
            this.txtSelectColumns.TabIndex = 23;
            this.txtSelectColumns.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "Select ";
            // 
            // btnCopyAll
            // 
            this.btnCopyAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyAll.Location = new System.Drawing.Point(573, 58);
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Size = new System.Drawing.Size(119, 24);
            this.btnCopyAll.TabIndex = 19;
            this.btnCopyAll.Text = "拷贝到剪切板";
            this.btnCopyAll.UseVisualStyleBackColor = true;
            this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(573, 3);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(119, 24);
            this.btnExecute.TabIndex = 20;
            this.btnExecute.Text = "执行";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(710, 203);
            this.dataGridView1.TabIndex = 26;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 102);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtCode);
            this.splitContainer1.Size = new System.Drawing.Size(710, 407);
            this.splitContainer1.SplitterDistance = 203;
            this.splitContainer1.TabIndex = 27;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(53, 28);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(211, 21);
            this.txtTableName.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "Where ";
            // 
            // btnGenerateInsertSql
            // 
            this.btnGenerateInsertSql.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateInsertSql.Location = new System.Drawing.Point(573, 31);
            this.btnGenerateInsertSql.Name = "btnGenerateInsertSql";
            this.btnGenerateInsertSql.Size = new System.Drawing.Size(119, 24);
            this.btnGenerateInsertSql.TabIndex = 20;
            this.btnGenerateInsertSql.Text = "生成Insert语句";
            this.btnGenerateInsertSql.UseVisualStyleBackColor = true;
            this.btnGenerateInsertSql.Click += new System.EventHandler(this.btnGenerateInsertSql_Click);
            // 
            // chkIncludeIdentity
            // 
            this.chkIncludeIdentity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIncludeIdentity.AutoSize = true;
            this.chkIncludeIdentity.Location = new System.Drawing.Point(381, 82);
            this.chkIncludeIdentity.Name = "chkIncludeIdentity";
            this.chkIncludeIdentity.Size = new System.Drawing.Size(168, 16);
            this.chkIncludeIdentity.TabIndex = 28;
            this.chkIncludeIdentity.Text = "在生成的语句中包含自增列";
            this.chkIncludeIdentity.UseVisualStyleBackColor = true;
            // 
            // chkGenerateTransaction
            // 
            this.chkGenerateTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGenerateTransaction.AutoSize = true;
            this.chkGenerateTransaction.Checked = true;
            this.chkGenerateTransaction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGenerateTransaction.Location = new System.Drawing.Point(283, 82);
            this.chkGenerateTransaction.Name = "chkGenerateTransaction";
            this.chkGenerateTransaction.Size = new System.Drawing.Size(96, 16);
            this.chkGenerateTransaction.TabIndex = 29;
            this.chkGenerateTransaction.Text = "生成事务代码";
            this.chkGenerateTransaction.UseVisualStyleBackColor = true;
            // 
            // lblDataCount
            // 
            this.lblDataCount.AutoSize = true;
            this.lblDataCount.Location = new System.Drawing.Point(8, 84);
            this.lblDataCount.Name = "lblDataCount";
            this.lblDataCount.Size = new System.Drawing.Size(47, 12);
            this.lblDataCount.TabIndex = 30;
            this.lblDataCount.Text = "记录数:";
            // 
            // lblInsertCount
            // 
            this.lblInsertCount.AutoSize = true;
            this.lblInsertCount.Location = new System.Drawing.Point(121, 84);
            this.lblInsertCount.Name = "lblInsertCount";
            this.lblInsertCount.Size = new System.Drawing.Size(83, 12);
            this.lblInsertCount.TabIndex = 30;
            this.lblInsertCount.Text = "生成语句条数:";
            // 
            // FrmGenerateInsertStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 511);
            this.Controls.Add(this.lblInsertCount);
            this.Controls.Add(this.lblDataCount);
            this.Controls.Add(this.chkGenerateTransaction);
            this.Controls.Add(this.chkIncludeIdentity);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtWhereString);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.txtSelectColumns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCopyAll);
            this.Controls.Add(this.btnGenerateInsertSql);
            this.Controls.Add(this.btnExecute);
            this.Name = "FrmGenerateInsertStatement";
            this.Text = "根据Sql语句生成Insert脚本";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtWhereString;
        private System.Windows.Forms.TextBox txtSelectColumns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopyAll;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerateInsertSql;
        private System.Windows.Forms.CheckBox chkIncludeIdentity;
        private System.Windows.Forms.CheckBox chkGenerateTransaction;
        private System.Windows.Forms.Label lblDataCount;
        private System.Windows.Forms.Label lblInsertCount;

    }
}