
using System;
namespace AppLibrary.Format
{
	
	/// <summary> The location of a border</summary>
	public class Border
	{
		/// <summary> Gets the description</summary>
		virtual public string Description
		{
			get
			{
				return string_Renamed;
			}
			
		}
		/// <summary> The string description</summary>
		private string string_Renamed;
		
		/// <summary> Constructor</summary>
		protected internal Border(string s)
		{
			string_Renamed = s;
		}
		
		public static readonly Border NONE = new Border("none");
		public static readonly Border ALL = new Border("all");
		public static readonly Border TOP = new Border("top");
		public static readonly Border BOTTOM = new Border("bottom");
		public static readonly Border LEFT = new Border("left");
		public static readonly Border RIGHT = new Border("right");
	}
}