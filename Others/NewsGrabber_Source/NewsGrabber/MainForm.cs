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
	using System.Threading;
	using System.Threading.Tasks;

	using Entity;

	using Service;

	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			SizeChanged += MainForm_SizeChanged;
			ni.Click += (s, e) =>
			{
				Show();
				WindowState = FormWindowState.Normal;
			};
			FormClosing += (s, e) =>
			{
				if (btnStop.Enabled)
				{
					e.Cancel = true;
					WindowState = FormWindowState.Minimized;
				}
			};
			lvItems.MouseDoubleClick += (s, e) =>
			{
				if (lvItems.FocusedItem == null)
					return;

				Process.Start((lvItems.FocusedItem.Tag as NewsItem).Url);
			};
			ni.Icon = Icon;
			InitTask();
		}


		#region 界面操作

		private void MainForm_SizeChanged(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				if (chkMinOnStart.Checked)
				{
					ni.Visible = true;
					Hide();
				}
			}
			else
			{
				ni.Visible = false;
			}
		}


		private void btnStart_Click(object sender, EventArgs e)
		{
			if (_enabled)
				return;

			lvItems.Items.Clear();
			_enabled = true;
			if (chkMinOnStart.Checked)
			{
				WindowState = FormWindowState.Minimized;
			}
			btnStop.Enabled = true;
			btnStart.Enabled = false;
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			_enabled = false;
			btnStop.Enabled = false;
			btnStart.Enabled = true;
		}

		private void nudValue_ValueChanged(object sender, EventArgs e)
		{
			_sleepTime = (int)(nudValue.Value * 60);
		}

		#endregion

		#region 任务线程

		bool _enabled, _inited;
		int _sleepTime = 120;
		Dictionary<INewsGrabber, GrabberContext> _contexts;
		string[] _keywords;

		/// <summary>
		/// 初始化任务
		/// </summary>
		void InitTask()
		{
			_contexts = GrabberManager.Instance.Grabbers.ToDictionary(s =>
			{
				var group = new ListViewGroup("");
				group.Tag = s;
				lvItems.Groups.Add(group);

				return s;
			}, s => new GrabberContext(s));
			_keywords = txtKeyword.Text.Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
			txtKeyword.TextChanged += (s, e) =>
			{
				_keywords = txtKeyword.Text.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
			};

			Task.Factory.StartNew(TaskLoop, TaskCreationOptions.LongRunning);
		}

		void TaskLoop()
		{
			while (true)
			{
				//等待启用
				while (!_enabled)
				{
					Thread.Sleep(100);
				}
				//检测
				var newstItems = new List<NewsItem>();

				foreach (var data in _contexts)
				{
					var ctx = data.Value;
					var grabber = data.Key;

					var items = grabber.GetLatest(_keywords);

					if (items == null)
					{
						var index = 5;
						while (index-- > 0 && items == null)
						{
							//每隔1秒重试一次，最多重试三次
							items = grabber.GetLatest(_keywords);
						}
					}

					if (items == null)
					{
						ctx.LastSuccess = null;
						ctx.LastGrabberTime = null;

						Invoke(new Action(() => NotifyFailed(grabber)));
					}
					else
					{
						ctx.LastSuccess = true;
						ctx.LastGrabberTime = DateTime.Now;

						if (_inited)
							newstItems.AddRange(items);
					}

					Invoke(new Action(() =>
					{
						UpdateUI(grabber, ctx, items);
					}));
				}
				if (!_inited)
				{
					_inited = true;
					Invoke(new Action(NotifyInited));
				}
				else if (newstItems.Count > 0)
				{
					Invoke(new Action(() => NotifyItemsNew(newstItems)));
				}

				//延迟控制。在延迟周期内，如果检测到禁用，则退出
				var nextTime = DateTime.Now.AddSeconds(_sleepTime);
				while (DateTime.Now < nextTime)
				{
					if (!_enabled)
						break;
					Thread.Sleep(500);
				}
			}
		}

		static int _maxKeepItems = 100;

		void UpdateUI(INewsGrabber grabber, GrabberContext context, NewsItem[] items)
		{
			lvItems.BeginUpdate();

			var lvGroup = lvItems.Groups.Cast<ListViewGroup>().First(s => s.Tag == grabber);
			lvGroup.Header = context.GetStatusText();

			//移除过早的项
			if (lvGroup.Items.Count + items.Length >= _maxKeepItems)
			{
				//只保留一百条
				var removeItems = lvGroup.Items.Cast<ListViewItem>().Skip(_maxKeepItems - items.Length).ToArray();
				Array.ForEach(removeItems, s =>
				{
					lvGroup.Items.Remove(s);
					s.Remove();
				});
			}

			//刷新现有项
			foreach (ListViewItem s in lvGroup.Items)
			{
				var isnew = (s.Tag as NewsItem).IsNew;

				s.ForeColor = isnew ? Color.Red : ForeColor;
				s.BackColor = isnew ? Color.Pink : BackColor;

			}

			//添加现有项
			Array.ForEach(items, s =>
			{
				var lvitem = new ListViewItem(new[] { s.Title, s.Url })
				{
					Group = lvGroup,
					Tag = s,
					UseItemStyleForSubItems = true,
					ForeColor = Color.Red,
					BackColor = Color.Pink
				};
				lvItems.Items.Insert(0, lvitem);
			});

			lvItems.EndUpdate();
		}

		void NotifyItemsNew(List<NewsItem> items)
		{
			//有新的内容！
			System.Media.SystemSounds.Beep.Play();
			new NewItemsNotification(items).Show(this);
		}

		void NotifyInited()
		{
			ni.ShowBalloonTip(2000, "招标信息监控", "监控信息已经初始化。当下次有更新时会通知您。", ToolTipIcon.Info);
		}

		void NotifyFailed(INewsGrabber grabber)
		{
			ni.ShowBalloonTip(2000, "招标信息监控", "尝试读取【" + grabber.Name + "】更新时发生错误！", ToolTipIcon.Warning);
		}

		#endregion
	}
}
