using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsGrabber.Service
{
	using FSLib.Network.Http;

	using HtmlAgilityPack;

	abstract class GrabberBase
	{
		protected GrabberBase()
		{
			NetworkClient = new HttpClient();
		}

		/// <summary>
		/// 使用的网络客户端
		/// </summary>
		protected HttpClient NetworkClient { get; private set; }

		HashSet<string> _idlist=new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		protected bool CheckDuplicate(string id)
		{
			if (_idlist.Contains(id))
				return false;

			_idlist.Add(id);
			return true;
		}

		protected bool CheckKeyword(string[] keywords, string title)
		{
			if (keywords == null || keywords.Length == 0)
				return true;

			return keywords.Any(s => title.IndexOf(s, StringComparison.OrdinalIgnoreCase) != -1);
		}

		/// <summary>
		/// 请求指定地址并获得URL
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		protected string GetString(string url)
		{
			var ctx = NetworkClient.Create<string>(HttpMethod.Get, url).Send();
			if (!ctx.IsValid())
			{
				return null;
			}

			return ctx.Result;
		}

		/// <summary>
		/// 获得HTML文档
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		protected HtmlDocument GetDocument(string url)
		{
			var str = GetString(url);
			if (str.IsNullOrEmpty())
				return null;

			var doc = new HtmlDocument();
			doc.LoadHtml(str);

			return doc;
		}
	}
}
