
using System;
using AppLibrary.ReadExcel;
using AppLibrary.Biff.Formula;
namespace AppLibrary.Biff
{
	
	/// <summary> Interface which is used for copying formulas from a read only
	/// to a writable spreadsheet
	/// </summary>
	public interface FormulaData : Cell
		{
			/// <summary> Gets the raw bytes for the formula.  This will include the
			/// parsed tokens array EXCLUDING the standard cell information
			/// (row, column, xfindex)
			/// 
			/// </summary>
			/// <returns> the raw record data
			/// </returns>
			/// <exception cref=""> FormulaException
			/// </exception>
			sbyte[] getFormulaData();
		}
}
