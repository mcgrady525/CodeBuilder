namespace CodeBuilder
{
    partial class FrmGenerateBusinessClass
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
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.chkAsChildObject = new System.Windows.Forms.CheckBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.chkAsPrimaryObject = new System.Windows.Forms.CheckBox();
            this.btnCopyAll = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Location = new System.Drawing.Point(555, 8);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(130, 30);
            this.btnGenerateCode.TabIndex = 0;
            this.btnGenerateCode.Text = "生成业务类代码";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "类名";
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(43, 11);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(192, 21);
            this.txtClassName.TabIndex = 2;
            // 
            // chkAsChildObject
            // 
            this.chkAsChildObject.AutoSize = true;
            this.chkAsChildObject.Location = new System.Drawing.Point(176, 65);
            this.chkAsChildObject.Name = "chkAsChildObject";
            this.chkAsChildObject.Size = new System.Drawing.Size(132, 16);
            this.chkAsChildObject.TabIndex = 3;
            this.chkAsChildObject.Text = "是否作为子对象使用";
            this.chkAsChildObject.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(5, 87);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(682, 599);
            this.txtCode.TabIndex = 2;
            this.txtCode.WordWrap = false;
            // 
            // chkAsPrimaryObject
            // 
            this.chkAsPrimaryObject.AutoSize = true;
            this.chkAsPrimaryObject.Checked = true;
            this.chkAsPrimaryObject.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAsPrimaryObject.Location = new System.Drawing.Point(41, 65);
            this.chkAsPrimaryObject.Name = "chkAsPrimaryObject";
            this.chkAsPrimaryObject.Size = new System.Drawing.Size(132, 16);
            this.chkAsPrimaryObject.TabIndex = 3;
            this.chkAsPrimaryObject.Text = "是否作为主对象使用";
            this.chkAsPrimaryObject.UseVisualStyleBackColor = true;
            // 
            // btnCopyAll
            // 
            this.btnCopyAll.Location = new System.Drawing.Point(555, 44);
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Size = new System.Drawing.Size(130, 30);
            this.btnCopyAll.TabIndex = 0;
            this.btnCopyAll.Text = "拷贝到剪切板";
            this.btnCopyAll.UseVisualStyleBackColor = true;
            this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(43, 38);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(430, 21);
            this.txtRemark.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "描述";
            // 
            // FrmGenerateBusinessClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 689);
            this.Controls.Add(this.chkAsPrimaryObject);
            this.Controls.Add(this.chkAsChildObject);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCopyAll);
            this.Controls.Add(this.btnGenerateCode);
            this.Name = "FrmGenerateBusinessClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成BusinessClass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.CheckBox chkAsChildObject;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.CheckBox chkAsPrimaryObject;
        private System.Windows.Forms.Button btnCopyAll;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label2;
    }
}