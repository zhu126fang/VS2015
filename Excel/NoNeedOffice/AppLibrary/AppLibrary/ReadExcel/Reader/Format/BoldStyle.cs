
using System;

namespace AppLibrary.Format
{
	
	/// <summary> Enumeration class containing the various bold styles for data</summary>
	public class BoldStyle
	{
		/// <summary> Gets the value of the bold weight.  This is the value that will be
		/// written to the generated Excel file.
		/// 
		/// </summary>
		/// <returns> the bold weight
		/// </returns>
		virtual public int Value
		{
			get
			{
				return value_Renamed;
			}
			
		}
		/// <summary> Gets the string description of the bold style</summary>
		virtual public string Description
		{
			get
			{
				return string_Renamed;
			}
			
		}
		/// <summary> The bold weight</summary>
		private int value_Renamed;
		
		/// <summary> The description</summary>
		private string string_Renamed;
		
		/// <summary> Constructor
		/// 
		/// </summary>
		/// <param name="val">
		/// </param>
		protected internal BoldStyle(int val, string s)
		{
			value_Renamed = val;
			string_Renamed = s;
		}
		
		/// <summary> Normal style</summary>
		public static readonly BoldStyle NORMAL = new BoldStyle(0x190, "Normal");
		/// <summary> Emboldened style</summary>
		public static readonly BoldStyle BOLD = new BoldStyle(0x2bc, "Bold");
	}
}