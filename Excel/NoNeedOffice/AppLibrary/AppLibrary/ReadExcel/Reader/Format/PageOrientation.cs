
using System;
namespace AppLibrary.Format
{
	
	/// <summary> Enumeration type which describes the page orientation</summary>
	public sealed class PageOrientation
	{
		/// <summary> Constructor</summary>
		private PageOrientation()
		{
		}
		
		
		/// <summary> Portrait orientation</summary>
		public static PageOrientation PORTRAIT;
		/// <summary> Landscape orientation</summary>
		public static PageOrientation LANDSCAPE;
		static PageOrientation()
		{
			PORTRAIT = new PageOrientation();
			LANDSCAPE = new PageOrientation();
		}
	}
}