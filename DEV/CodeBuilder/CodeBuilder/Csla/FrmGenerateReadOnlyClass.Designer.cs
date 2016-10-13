namespace CodeBuilder
{
    partial class FrmGenerateReadOnlyClass
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
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCopyAll = new System.Windows.Forms.Button();
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.chkUseBusinessConstants = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(6, 73);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(677, 430);
            this.txtCode.TabIndex = 9;
            this.txtCode.WordWrap = false;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(50, 37);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(430, 21);
            this.txtRemark.TabIndex = 10;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(50, 10);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(192, 21);
            this.txtClassName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "描述";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "类名";
            // 
            // btnCopyAll
            // 
            this.btnCopyAll.Location = new System.Drawing.Point(548, 38);
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Size = new System.Drawing.Size(130, 30);
            this.btnCopyAll.TabIndex = 4;
            this.btnCopyAll.Text = "拷贝到剪切板";
            this.btnCopyAll.UseVisualStyleBackColor = true;
            this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Location = new System.Drawing.Point(548, 6);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(130, 30);
            this.btnGenerateCode.TabIndex = 5;
            this.btnGenerateCode.Text = "生成只读类代码";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // chkUseBusinessConstants
            // 
            this.chkUseBusinessConstants.AutoSize = true;
            this.chkUseBusinessConstants.Location = new System.Drawing.Point(272, 11);
            this.chkUseBusinessConstants.Name = "chkUseBusinessConstants";
            this.chkUseBusinessConstants.Size = new System.Drawing.Size(168, 16);
            this.chkUseBusinessConstants.TabIndex = 11;
            this.chkUseBusinessConstants.Text = "使用业务主类中的常量定义";
            this.chkUseBusinessConstants.UseVisualStyleBackColor = true;
            // 
            // FrmGenerateReadOnlyClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 507);
            this.Controls.Add(this.chkUseBusinessConstants);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCopyAll);
            this.Controls.Add(this.btnGenerateCode);
            this.Name = "FrmGenerateReadOnlyClass";
            this.Text = "生成只读实体类";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopyAll;
        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.CheckBox chkUseBusinessConstants;
    }
}