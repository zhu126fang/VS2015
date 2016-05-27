using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewsGrabber
{
	using System.Diagnostics;

	using Entity;

	internal partial class NewItemsNotification : Form
	{
		public NewItemsNotification(List<NewsItem> items)
		{
			InitializeComponent();

			LoadItems(items);
			var primaryBounds = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
			Location = new Point(primaryBounds.Width - Width - 20, primaryBounds.Height - Height - 20);
		}

		void LoadItems(List<NewsItem> items)
		{
			SuspendLayout();

			var groups = items.GroupBy(s => s.NewsGrabber);

			foreach (var g in groups)
			{
				foreach (var newsItem in g.Reverse())
				{
					var linkLabel = new LinkLabel();
					linkLabel.Text = newsItem.Title;
					linkLabel.Tag = newsItem.Url;
					linkLabel.Click += LinkLabel_Click;
					linkLabel.AutoSize = false;
					linkLabel.TextAlign = ContentAlignment.MiddleLeft;
					linkLabel.Height = 20;
					linkLabel.Dock = DockStyle.Top;
					linkLabel.LinkBehavior = LinkBehavior.HoverUnderline;

					Controls.Add(linkLabel);
				}

				var label = new Label();
				label.Font = new Font(Font.FontFamily, 16.0F, FontStyle.Bold);
				label.Text = g.Key.Name;
				label.Dock = DockStyle.Top;
				label.AutoSize = false;
				label.Height = 36;
				label.TextAlign = ContentAlignment.MiddleLeft;
				Controls.Add(label);
			}

			ResumeLayout();
			AutoScroll = false;
			AutoScrollPosition = new Point(0, 0);
		}

		private void LinkLabel_Click(object sender, EventArgs e)
		{
			Process.Start((sender as LinkLabel).Tag as string);
		}
	}
}
