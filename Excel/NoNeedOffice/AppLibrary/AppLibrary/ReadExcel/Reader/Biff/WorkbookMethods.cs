
using System;
using AppLibrary.ReadExcel;
namespace AppLibrary.Biff
{
	/// <summary> An interface containing some common workbook methods.  This so that
	/// objects which are re-used for both readable and writable workbooks
	/// can still make the same method calls on a workbook
	/// </summary>
	public interface WorkbookMethods
		{
			/// <summary> Gets the specified sheet within this workbook
			/// 
			/// </summary>
			/// <param name="index">the zero based index of the required sheet
			/// </param>
			/// <returns> The sheet specified by the index
			/// </returns>
			Sheet getReadSheet(int index);
			
			/// <summary> Gets the name at the specified index
			/// 
			/// </summary>
			/// <param name="index">the index into the name table
			/// </param>
			/// <returns> the name of the cell
			/// </returns>
			string getName(int index);
			
			/// <summary> Gets the index of the name record for the name
			/// 
			/// </summary>
			/// <param name="name">the name
			/// </param>
			/// <returns> the index in the name table
			/// </returns>
			int getNameIndex(string name);
		}
}
