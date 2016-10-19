namespace CodeBuilder
{
    partial class FrmSingleTableGenerate
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
            this.txt_OutPut = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_CopyAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.txt_OutPut);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(684, 562);
            this.splitContainer1.SplitterDistance = 462;
            this.splitContainer1.TabIndex = 0;
            // 
            // txt_OutPut
            // 
            this.txt_OutPut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_OutPut.Location = new System.Drawing.Point(0, 0);
            this.txt_OutPut.Multiline = true;
            this.txt_OutPut.Name = "txt_OutPut";
            this.txt_OutPut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_OutPut.Size = new System.Drawing.Size(684, 462);
            this.txt_OutPut.TabIndex = 0;
            this.txt_OutPut.TabStop = false;
            this.txt_OutPut.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_CopyAll);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // btn_CopyAll
            // 
            this.btn_CopyAll.Location = new System.Drawing.Point(26, 36);
            this.btn_CopyAll.Name = "btn_CopyAll";
            this.btn_CopyAll.Size = new System.Drawing.Size(100, 50);
            this.btn_CopyAll.TabIndex = 0;
            this.btn_CopyAll.Text = "复制到剪贴板";
            this.btn_CopyAll.UseVisualStyleBackColor = true;
            this.btn_CopyAll.Click += new System.EventHandler(this.btn_CopyAll_Click);
            // 
            // FrmSingleTableGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 562);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmSingleTableGenerate";
            this.Text = "单表生成";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_OutPut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_CopyAll;
    }
}