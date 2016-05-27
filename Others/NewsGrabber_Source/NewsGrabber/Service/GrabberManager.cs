using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsGrabber.Service
{
	using System.ComponentModel.Composition;
	using System.ComponentModel.Composition.Hosting;
	using System.Reflection;

	class GrabberManager
	{
		static GrabberManager()
		{
			var container = new AssemblyCatalog(Assembly.GetEntryAssembly());
			var compsition = new CompositionContainer(container);

			compsition.ComposeParts(Instance);
		}

		#region 单例模式

		static GrabberManager _instance;
		static readonly object _lockObject = new object();

		public static GrabberManager Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (_lockObject)
					{
						if (_instance == null)
						{
							_instance = new GrabberManager();
						}
					}
				}

				return _instance;
			}
		}

		#endregion

		/// <summary>
		/// 所有的抓取器
		/// </summary>
		[ImportMany]
		public INewsGrabber[] Grabbers { get; private set; }
	}
}
