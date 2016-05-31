
using System;
namespace AppLibrary.Format
{
	
	/// <summary> Enumeration class which contains the various underline styles available 
	/// within the standard Excel UnderlineStyle palette
	/// 
	/// </summary>
	public sealed class UnderlineStyle
	{
		/// <summary> Gets the value of this style.  This is the value that is written to 
		/// the generated Excel file
		/// 
		/// </summary>
		/// <returns> the binary value
		/// </returns>
		public int Value
		{
			get
			{
				return value_Renamed;
			}
			
		}
		/// <summary> Gets the string description for display purposes
		/// 
		/// </summary>
		/// <returns> the string description
		/// </returns>
		public string Description
		{
			get
			{
				return string_Renamed;
			}
			
		}
		/// <summary> The internal numerical representation of the UnderlineStyle</summary>
		private int value_Renamed;
		
		/// <summary> The display string for the underline style.  Used when presenting the 
		/// format information
		/// </summary>
		private string string_Renamed;
		
		/// <summary> The list of UnderlineStyles</summary>
		private static UnderlineStyle[] styles;
		
		/// <summary> Private constructor
		/// 
		/// </summary>
		/// <param name="val">
		/// </param>
		/// <param name="s">the display string
		/// </param>
		protected internal UnderlineStyle(int val, string s)
		{
			value_Renamed = val;
			string_Renamed = s;
			
			UnderlineStyle[] oldstyles = styles;
			styles = new UnderlineStyle[oldstyles.Length + 1];
			Array.Copy((System.Array) oldstyles, 0, (System.Array) styles, 0, oldstyles.Length);
			styles[oldstyles.Length] = this;
		}
		
		/// <summary> Gets the UnderlineStyle from the value
		/// 
		/// </summary>
		/// <param name="val">
		/// </param>
		/// <returns> the UnderlineStyle with that value
		/// </returns>
		public static UnderlineStyle getStyle(int val)
		{
			for (int i = 0; i < styles.Length; i++)
			{
				if (styles[i].Value == val)
				{
					return styles[i];
				}
			}
			
			return NO_UNDERLINE;
		}
		
		// The underline styles
		public static readonly UnderlineStyle NO_UNDERLINE = new UnderlineStyle(0, "none");
		
		public static readonly UnderlineStyle SINGLE = new UnderlineStyle(1, "single");
		
		public static readonly UnderlineStyle DOUBLE = new UnderlineStyle(2, "double");
		
		public static readonly UnderlineStyle SINGLE_ACCOUNTING = new UnderlineStyle(0x21, "single accounting");
		
		public static readonly UnderlineStyle DOUBLE_ACCOUNTING = new UnderlineStyle(0x22, "double accounting");
		static UnderlineStyle()
		{
			styles = new UnderlineStyle[0];
		}
	}
}