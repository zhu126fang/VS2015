using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsGrabber.Service
{
	class GrabberContext
	{
		/// <summary>
		/// 获得或设置上次抓取时间
		/// </summary>
		public DateTime? LastGrabberTime { get; set; }

		/// <summary>
		/// 获得或设置上次是否成功
		/// </summary>
		public bool? LastSuccess { get; set; }

		/// <summary>
		/// 获得抓取器
		/// </summary>
		public INewsGrabber NewsGrabber { get; set; }

		/// <summary>
		/// 创建 <see cref="GrabberContext" />  的新实例(GrabberContext)
		/// </summary>
		/// <param name="newsGrabber"></param>
		public GrabberContext(INewsGrabber newsGrabber)
		{
			NewsGrabber = newsGrabber;
			LastGrabberTime = null;
			LastSuccess = null;
		}

		/// <summary>
		/// 获得状态显示文字
		/// </summary>
		/// <returns></returns>
		public string GetStatusText()
		{
			if (LastSuccess == null)
				return NewsGrabber.Name + " (未开始抓取)";

			return string.Format("{0} / 上次抓取时间：{1} ({2})", NewsGrabber.Name, LastGrabberTime.Value.ToShortTimeString(), LastSuccess == true ? "成功" : "失败");
		}
	}
}
