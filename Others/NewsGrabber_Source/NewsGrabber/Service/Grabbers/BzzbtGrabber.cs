using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsGrabber.Service
{
	using System.ComponentModel.Composition;
	using System.Text.RegularExpressions;

	using Entity;

	class BzzbtGrabber : GrabberBase, INewsGrabber
	{
		public string Name { get; protected set; }

		protected string Url { get; set; }

		/// <summary>
		/// 获得最新的记录
		/// </summary>
		/// <param name="keywords"></param>
		/// <returns></returns>
		public NewsItem[] GetLatest(string[] keywords)
		{
			var doc = GetDocument(Url);
			if (doc == null)
				return null;

			var nodes = doc.DocumentNode.SelectNodes(@"//div[@class='InfoLineMore']//a");
			if (nodes == null)
				return null;

			var items = nodes.Select(s =>
			{
				var title = s.InnerText;
				var link = "http://www.bzztb.gov.cn" + s.GetAttributeValue("href", "");
				//InfoID=8c150665-737c-4c45-94d4-ae32ff3d26bc&
				var id = Regex.Match(link, @"InfoID=([-\da-fA-F]+)").GetGroupValue(1);

				return new NewsItem(link, title, id, this);
			}).Where(s => CheckDuplicate(s.Id) && CheckKeyword(keywords, s.Title)).ToArray();

			return items;
		}
	}

	[Export(typeof(INewsGrabber))]
	class ZfzbBzzbtGrabber : BzzbtGrabber
	{
		public ZfzbBzzbtGrabber()
		{
			Url = "http://www.bzztb.gov.cn/BZWZ/zfcg/013001/";
			Name = "亳州公共资源交易网-政府招标";
		}
	}

	[Export(typeof(INewsGrabber))]
	class JsxmBzzbtGrabber : BzzbtGrabber
	{
		public JsxmBzzbtGrabber()
		{
			Url = "http://www.bzztb.gov.cn/BZWZ/gcjs/012001/";
			Name = "亳州公共资源交易网-建设招标";
		}
	}
}
