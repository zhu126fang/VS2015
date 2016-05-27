namespace NewsGrabber
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.lvItems = new System.Windows.Forms.ListView();
			this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ilCtx = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.nudValue = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.chkMinOnStart = new System.Windows.Forms.CheckBox();
			this.ni = new System.Windows.Forms.NotifyIcon(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtKeyword = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
			this.SuspendLayout();
			// 
			// lvItems
			// 
			this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitle,
            this.colUrl});
			this.lvItems.FullRowSelect = true;
			this.lvItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvItems.HideSelection = false;
			this.lvItems.Location = new System.Drawing.Point(12, 12);
			this.lvItems.Name = "lvItems";
			this.lvItems.Size = new System.Drawing.Size(922, 517);
			this.lvItems.SmallImageList = this.ilCtx;
			this.lvItems.TabIndex = 0;
			this.lvItems.UseCompatibleStateImageBehavior = false;
			this.lvItems.View = System.Windows.Forms.View.Details;
			// 
			// colTitle
			// 
			this.colTitle.Text = "标题";
			this.colTitle.Width = 533;
			// 
			// colUrl
			// 
			this.colUrl.Text = "网址";
			this.colUrl.Width = 348;
			// 
			// ilCtx
			// 
			this.ilCtx.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.ilCtx.ImageSize = new System.Drawing.Size(1, 20);
			this.ilCtx.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtKeyword);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.btnStop);
			this.panel1.Controls.Add(this.btnStart);
			this.panel1.Controls.Add(this.nudValue);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.chkMinOnStart);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.panel1.Location = new System.Drawing.Point(0, 535);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(946, 85);
			this.panel1.TabIndex = 1;
			// 
			// btnStop
			// 
			this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStop.Enabled = false;
			this.btnStop.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnStop.Image = global::NewsGrabber.Properties.Resources._142;
			this.btnStop.Location = new System.Drawing.Point(845, 36);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(88, 35);
			this.btnStop.TabIndex = 9;
			this.btnStop.Text = "停止监控";
			this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStart.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnStart.Image = global::NewsGrabber.Properties.Resources._131;
			this.btnStart.Location = new System.Drawing.Point(753, 36);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(88, 35);
			this.btnStart.TabIndex = 10;
			this.btnStart.Text = "开始监控";
			this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// nudValue
			// 
			this.nudValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.nudValue.Location = new System.Drawing.Point(178, 42);
			this.nudValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudValue.Name = "nudValue";
			this.nudValue.Size = new System.Drawing.Size(62, 23);
			this.nudValue.TabIndex = 8;
			this.nudValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.nudValue.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nudValue.ValueChanged += new System.EventHandler(this.nudValue_ValueChanged);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(250, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 17);
			this.label2.TabIndex = 6;
			this.label2.Text = "分钟";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(124, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 7;
			this.label1.Text = "刷新周期";
			// 
			// chkMinOnStart
			// 
			this.chkMinOnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkMinOnStart.AutoSize = true;
			this.chkMinOnStart.Checked = true;
			this.chkMinOnStart.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkMinOnStart.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.chkMinOnStart.Location = new System.Drawing.Point(13, 45);
			this.chkMinOnStart.Name = "chkMinOnStart";
			this.chkMinOnStart.Size = new System.Drawing.Size(99, 21);
			this.chkMinOnStart.TabIndex = 5;
			this.chkMinOnStart.Text = "开始后最小化";
			this.chkMinOnStart.UseVisualStyleBackColor = true;
			// 
			// ni
			// 
			this.ni.Text = "招投标信息监控";
			this.ni.Visible = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(12, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 17);
			this.label3.TabIndex = 11;
			this.label3.Text = "监控关键词";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label4.Location = new System.Drawing.Point(630, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(304, 17);
			this.label4.TabIndex = 11;
			this.label4.Text = "(多个关键词用空格隔开，将会过滤不包含关键词的信息)";
			// 
			// txtKeyword
			// 
			this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtKeyword.Location = new System.Drawing.Point(87, 10);
			this.txtKeyword.Name = "txtKeyword";
			this.txtKeyword.Size = new System.Drawing.Size(537, 23);
			this.txtKeyword.TabIndex = 12;
			this.txtKeyword.Text = "规划";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(946, 620);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lvItems);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "招投标信息监控";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lvItems;
		private System.Windows.Forms.ColumnHeader colTitle;
		private System.Windows.Forms.ColumnHeader colUrl;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.NumericUpDown nudValue;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkMinOnStart;
		private System.Windows.Forms.NotifyIcon ni;
		private System.Windows.Forms.ImageList ilCtx;
		private System.Windows.Forms.TextBox txtKeyword;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
	}
}

