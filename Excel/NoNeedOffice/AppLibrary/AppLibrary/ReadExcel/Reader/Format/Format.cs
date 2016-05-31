
using System;
namespace AppLibrary.Format
{
	
	/// <summary> Exposes the cell formatting information</summary>
	public interface Format
		{
			/// <summary> Accesses the excel format string which is applied to the cell
			/// Note that this is the string that excel uses, and not the java 
			/// equivalent
			/// 
			/// </summary>
			/// <returns> the cell format string
			/// </returns>
			string FormatString{get;}

		}
}