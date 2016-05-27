using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsGrabber.Service
{
	using System.ComponentModel.Composition;
	using System.Text.RegularExpressions;

	using Entity;

	[Export(typeof(INewsGrabber))]
	class AhtbaNewsGrabber : GrabberBase, INewsGrabber
	{
		public string Name
		{
			get { return "安徽招标投标信息网"; }
		}

		/// <summary>
		/// 获得最新的记录
		/// </summary>
		/// <returns></returns>
		/// <param name="keywords"></param>
		public NewsItem[] GetLatest(string[] keywords)
		{
			var doc = GetDocument("http://www.ahtba.org.cn/Notice/AnhuiNoticeSearch?spid=714&scid=597&srcode=&sttype=&stime=36500&stitle=&pageNum=1&pageSize=50");
			if (doc == null)
				return null;

			var nodes = doc.DocumentNode.SelectNodes("//div[@class='newsList']/ul/li");
			if (nodes == null)
				return null;

			var items = nodes.Select(s =>
			 {
				 var title = s.InnerText.Trim();
				 var link = "http://www.ahtba.org.cn" + s.SelectSingleNode("a").GetAttributeValue("href", "");
				 var id = Regex.Match(link, @"id=(\d+)").GetGroupValue(1);

				 return new NewsItem(link, title, id, this);
			 }).Where(s => CheckDuplicate(s.Id) && CheckKeyword(keywords, s.Title)).ToArray();

			return items;
		}
	}
}
