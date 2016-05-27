using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace NewsGrabber.Service
{
	using Entity;

	interface INewsGrabber
	{
		string Name { get; }

		/// <summary>
		/// 获得最新的记录
		/// </summary>
		/// <param name="keywords"></param>
		/// <returns></returns>
		NewsItem[] GetLatest(string[] keywords);
	}
}
