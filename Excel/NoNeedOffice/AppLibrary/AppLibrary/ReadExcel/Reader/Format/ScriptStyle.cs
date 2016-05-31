
using System;
namespace AppLibrary.Format
{
	
	/// <summary> Enumeration class which contains the various script styles available 
	/// within the standard Excel ScriptStyle palette
	/// 
	/// </summary>
	public sealed class ScriptStyle
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
		/// <summary> The internal numerical representation of the ScriptStyle</summary>
		private int value_Renamed;
		
		/// <summary> The display string for the script style.  Used when presenting the 
		/// format information
		/// </summary>
		private string string_Renamed;
		
		/// <summary> The list of ScriptStyles</summary>
		private static ScriptStyle[] styles;
		
		
		/// <summary> Private constructor
		/// 
		/// </summary>
		/// <param name="val">
		/// </param>
		/// <param name="s">the display string
		/// </param>
		protected internal ScriptStyle(int val, string s)
		{
			value_Renamed = val;
			string_Renamed = s;
			
			ScriptStyle[] oldstyles = styles;
			styles = new ScriptStyle[oldstyles.Length + 1];
			Array.Copy((System.Array) oldstyles, 0, (System.Array) styles, 0, oldstyles.Length);
			styles[oldstyles.Length] = this;
		}
		
		/// <summary> Gets the ScriptStyle from the value
		/// 
		/// </summary>
		/// <param name="val">
		/// </param>
		/// <returns> the ScriptStyle with that value
		/// </returns>
		public static ScriptStyle getStyle(int val)
		{
			for (int i = 0; i < styles.Length; i++)
			{
				if (styles[i].Value == val)
				{
					return styles[i];
				}
			}
			
			return NORMAL_SCRIPT;
		}
		
		// The script styles
		public static readonly ScriptStyle NORMAL_SCRIPT = new ScriptStyle(0, "normal");
		public static readonly ScriptStyle SUPERSCRIPT = new ScriptStyle(1, "super");
		public static readonly ScriptStyle SUBSCRIPT = new ScriptStyle(2, "sub");
		static ScriptStyle()
		{
			styles = new ScriptStyle[0];
		}
	}
}