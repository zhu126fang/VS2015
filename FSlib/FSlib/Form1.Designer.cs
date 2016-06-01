namespace FSlib
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGrabBdPage = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnGrabBdLogo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGrabBdPage
            // 
            this.btnGrabBdPage.Location = new System.Drawing.Point(45, 15);
            this.btnGrabBdPage.Name = "btnGrabBdPage";
            this.btnGrabBdPage.Size = new System.Drawing.Size(100, 40);
            this.btnGrabBdPage.TabIndex = 0;
            this.btnGrabBdPage.Text = "抓取百度首页";
            this.btnGrabBdPage.UseVisualStyleBackColor = true;
            this.btnGrabBdPage.Click += new System.EventHandler(this.btnGrabBdPage_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(28, 106);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(562, 294);
            this.txtResult.TabIndex = 1;
            // 
            // btnGrabBdLogo
            // 
            this.btnGrabBdLogo.Location = new System.Drawing.Point(170, 15);
            this.btnGrabBdLogo.Name = "btnGrabBdLogo";
            this.btnGrabBdLogo.Size = new System.Drawing.Size(100, 40);
            this.btnGrabBdLogo.TabIndex = 2;
            this.btnGrabBdLogo.Text = "抓取百度LOGO";
            this.btnGrabBdLogo.UseVisualStyleBackColor = true;
            this.btnGrabBdLogo.Click += new System.EventHandler(this.btnGrabBdLogo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 432);
            this.Controls.Add(this.btnGrabBdLogo);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGrabBdPage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGrabBdPage;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnGrabBdLogo;
    }
}

