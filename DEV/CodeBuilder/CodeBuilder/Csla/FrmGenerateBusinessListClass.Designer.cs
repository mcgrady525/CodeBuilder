namespace CodeBuilder
{
    partial class FrmGenerateBusinessListClass
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
            this.txtCollectionClassName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnCopyAll = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCollectionItemClassName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Location = new System.Drawing.Point(555, 8);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(130, 30);
            this.btnGenerateCode.TabIndex = 0;
            this.btnGenerateCode.Text = "生成业务集合类代码";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "集合类名";
            // 
            // txtCollectionClassName
            // 
            this.txtCollectionClassName.Location = new System.Drawing.Point(76, 5);
            this.txtCollectionClassName.Name = "txtCollectionClassName";
            this.txtCollectionClassName.Size = new System.Drawing.Size(228, 21);
            this.txtCollectionClassName.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(5, 80);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(682, 606);
            this.txtCode.TabIndex = 2;
            this.txtCode.WordWrap = false;
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
            this.txtRemark.Location = new System.Drawing.Point(76, 53);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(470, 21);
            this.txtRemark.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "描述";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "集合项名";
            // 
            // txtCollectionItemClassName
            // 
            this.txtCollectionItemClassName.Location = new System.Drawing.Point(76, 29);
            this.txtCollectionItemClassName.Name = "txtCollectionItemClassName";
            this.txtCollectionItemClassName.Size = new System.Drawing.Size(228, 21);
            this.txtCollectionItemClassName.TabIndex = 2;
            // 
            // FrmGenerateBusinessListClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 689);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtCollectionItemClassName);
            this.Controls.Add(this.txtCollectionClassName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCopyAll);
            this.Controls.Add(this.btnGenerateCode);
            this.Name = "FrmGenerateBusinessListClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成BusinessListClass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCollectionClassName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnCopyAll;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCollectionItemClassName;
    }
}