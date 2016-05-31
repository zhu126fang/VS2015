 
using System;
namespace AppLibrary.ReadExcel
{


    //import AppLibrary.Write.WritableWorkbook;
	/// <summary> Exposes some cell reference helper methods to the public interface.
	/// This class merely delegates to the internally used reference helper
	/// </summary>
	public sealed class CellReferenceHelper
	{
		/// <summary> Hide the default constructor</summary>
		private CellReferenceHelper()
		{
		}
		
		/// <summary> Appends the cell reference for the column and row passed in to the string
		/// buffer
		/// 
		/// </summary>
		/// <param name="column">the column
		/// </param>
		/// <param name="row">the row
		/// </param>
		/// <param name="buf">the string buffer to append
		/// </param>
		public static void  getCellReference(int column, int row, System.Text.StringBuilder buf)
		{
            AppLibrary.Biff.CellReferenceHelper.getCellReference(column, row, buf);
		}
		
		/// <summary> Overloaded method which prepends $ for absolute reference
		/// 
		/// </summary>
		/// <param name="">column
		/// </param>
		/// <param name="colabs">TRUE if the column reference is absolute
		/// </param>
		/// <param name="">row
		/// </param>
		/// <param name="rowabs">TRUE if the row reference is absolute
		/// </param>
		/// <param name="">buf
		/// </param>
		public static void  getCellReference(int column, bool colabs, int row, bool rowabs, System.Text.StringBuilder buf)
		{
            AppLibrary.Biff.CellReferenceHelper.getCellReference(column, colabs, row, rowabs, buf);
		}
		
		
		/// <summary> Gets the cell reference for the specified column and row
		/// 
		/// </summary>
		/// <param name="column">the column
		/// </param>
		/// <param name="row">the row
		/// </param>
		/// <returns> the cell reference
		/// </returns>
		public static string getCellReference(int column, int row)
		{
            return AppLibrary.Biff.CellReferenceHelper.getCellReference(column, row);
		}
		
		/// <summary> Gets the columnn number of the string cell reference
		/// 
		/// </summary>
		/// <param name="s">the string to parse
		/// </param>
		/// <returns> the column portion of the cell reference
		/// </returns>
		public static int getColumn(string s)
		{
            return AppLibrary.Biff.CellReferenceHelper.getColumn(s);
		}
		
		/// <summary> Gets the column letter corresponding to the 0-based column number
		/// 
		/// </summary>
		/// <param name="c">the column number
		/// </param>
		/// <returns> the letter for that column number
		/// </returns>
		public static string getColumnReference(int c)
		{
            return AppLibrary.Biff.CellReferenceHelper.getColumnReference(c);
		}
		
		/// <summary> Gets the row number of the cell reference</summary>
		/// <param name="s">the cell reference
		/// </param>
		/// <returns> the row number
		/// </returns>
		public static int getRow(string s)
		{
            return AppLibrary.Biff.CellReferenceHelper.getRow(s);
		}
		
		/// <summary> Sees if the column component is relative or not
		/// 
		/// </summary>
		/// <param name="s">the cell
		/// </param>
		/// <returns> TRUE if the column is relative, FALSE otherwise
		/// </returns>
		public static bool isColumnRelative(string s)
		{
            return AppLibrary.Biff.CellReferenceHelper.isColumnRelative(s);
		}
		
		/// <summary> Sees if the row component is relative or not
		/// 
		/// </summary>
		/// <param name="s">the cell
		/// </param>
		/// <returns> TRUE if the row is relative, FALSE otherwise
		/// </returns>
		public static bool isRowRelative(string s)
		{
            return AppLibrary.Biff.CellReferenceHelper.isRowRelative(s);
		}
		
		/// <summary> Gets the fully qualified cell reference given the column, row
		/// external sheet reference etc
		/// 
		/// </summary>
		/// <param name="sheet">the sheet index
		/// </param>
		/// <param name="column">the column index
		/// </param>
		/// <param name="row">the row index
		/// </param>
		/// <param name="workbook">the workbook
		/// </param>
		/// <param name="buf">a string buffer
		/// </param>
		public static void  getCellReference(int sheet, int column, int row, Workbook workbook, System.Text.StringBuilder buf)
		{
            AppLibrary.Biff.CellReferenceHelper.getCellReference(sheet, column, row, (AppLibrary.Biff.Formula.ExternalSheet)workbook, buf);
		}
		
 
		//  /**
		//   * Gets the fully qualified cell reference given the column, row
		//   * external sheet reference etc
		//   *
		//   * @param sheet
		//   * @param column
		//   * @param row
		//   * @param workbook
		//   * @param buf
		//   */
		//  public static void getCellReference
		//    (int sheet, int column, int row,
		//     WritableWorkbook workbook, StringBuffer buf)
		//  {
        //    AppLibrary.Biff.CellReferenceHelper.getCellReference
        //      (sheet, column, row, (AppLibrary.Biff.Formula.ExternalSheet)workbook, buf);
		//  }
		
		/// <summary> Gets the fully qualified cell reference given the column, row
		/// external sheet reference etc
		/// 
		/// </summary>
		/// <param name="">sheet
		/// </param>
		/// <param name="">column
		/// </param>
		/// <param name="colabs">TRUE if the column is an absolute reference
		/// </param>
		/// <param name="">row
		/// </param>
		/// <param name="rowabs">TRUE if the row is an absolute reference
		/// </param>
		/// <param name="">workbook
		/// </param>
		/// <param name="">buf
		/// </param>
		public static void  getCellReference(int sheet, int column, bool colabs, int row, bool rowabs, Workbook workbook, System.Text.StringBuilder buf)
		{
            AppLibrary.Biff.CellReferenceHelper.getCellReference(sheet, column, colabs, row, rowabs, (AppLibrary.Biff.Formula.ExternalSheet)workbook, buf);
		}
		
		/// <summary> Gets the fully qualified cell reference given the column, row
		/// external sheet reference etc
		/// 
		/// </summary>
		/// <param name="">sheet
		/// </param>
		/// <param name="">column
		/// </param>
		/// <param name="">row
		/// </param>
		/// <param name="">workbook
		/// </param>
		/// <returns> the cell reference in the form 'Sheet 1'!A1
		/// </returns>
		public static string getCellReference(int sheet, int column, int row, Workbook workbook)
		{
            return AppLibrary.Biff.CellReferenceHelper.getCellReference(sheet, column, row, (AppLibrary.Biff.Formula.ExternalSheet)workbook);
		}
		
 
		//  /**
		//   * Gets the fully qualified cell reference given the column, row
		//   * external sheet reference etc
		//   *
		//   * @param sheet
		//   * @param column
		//   * @param row
		//   * @param workbook
		//   * @return the cell reference in the form 'Sheet 1'!A1
		//   */
		//  public static String getCellReference
		//    (int sheet, int column, int row,
		//     WritableWorkbook workbook)
		//  {
        //    return AppLibrary.Biff.CellReferenceHelper.getCellReference
        //      (sheet, column, row, (AppLibrary.Biff.Formula.ExternalSheet)workbook);
		//  }
	}
}
