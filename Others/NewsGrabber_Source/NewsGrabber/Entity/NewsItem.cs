using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsGrabber.Entity
{
	using System.Text.RegularExpressions;

	using Service;

	class NewsItem
	{
		string Clear(string str)
		{
			if (str.IsNullOrEmpty())
				return string.Empty;

			return Regex.Replace(str.Trim(), @"\s{2,}", " ");
		}

		/// <summary>
		/// 地址
		/// </summary>
		public string Url { get; private set; }

		/// <summary>
		/// 标题
		/// </summary>
		public string Title { get; private set; }

		/// <summary>
		/// 创建记录的时间
		/// </summary>
		public DateTime CreateTime { get; private set; }

		public bool IsNew
		{
			get { return (DateTime.Now - CreateTime).TotalMinutes <= 20; }
		}

		public INewsGrabber NewsGrabber { get; private set; }

		/// <summary>
		/// ID
		/// </summary>
		public string Id { get; private set; }

		/// <summary>
		/// 创建 <see cref="NewsItem" />  的新实例(NewsItem)
		/// </summary>
		/// <param name="url"></param>
		/// <param name="title"></param>
		public NewsItem(string url, string title, string id, INewsGrabber newsGrabber)
		{
			Url = Clear(url);
			Title = Clear(title);
			CreateTime = DateTime.Now;
			Id = id;
			NewsGrabber = newsGrabber;
		}
	}
}
