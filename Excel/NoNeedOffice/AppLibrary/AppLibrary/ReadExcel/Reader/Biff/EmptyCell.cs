
using System;
using AppLibrary.ReadExcel;
using AppLibrary.Format;
using AppLibrary.Write;
namespace AppLibrary.Biff
{
	
	/// <summary> An empty cell.  Represents an empty, as opposed to a blank cell
	/// in the workbook
	/// </summary>
	public class EmptyCell : WritableCell
	{
		/// <summary> Returns the row number of this cell
		/// 
		/// </summary>
		/// <returns> the row number of this cell
		/// </returns>
		virtual public int Row
		{
			get
			{
				return row;
			}
			
		}
		/// <summary> Returns the column number of this cell
		/// 
		/// </summary>
		/// <returns> the column number of this cell
		/// </returns>
		virtual public int Column
		{
			get
			{
				return col;
			}
			
		}
		/// <summary> Returns the content type of this cell
		/// 
		/// </summary>
		/// <returns> the content type for this cell
		/// </returns>
		virtual public CellType Type
		{
			get
			{
				return CellType.EMPTY;
			}
			
		}
		/// <summary> Quick and dirty function to return the contents of this cell as a string.
		/// 
		/// </summary>
		/// <returns> an empty string ""
		/// </returns>
		virtual public string Contents
		{
			get
			{
				return "";
			}
			
		}

		/// <summary>
		/// Returns a empty string, "".
		/// </summary>
		virtual public object Value
		{
			get
			{
				return "";
			}
		}
		
		/// <summary> Indicates whether or not this cell is hidden, by virtue of either
		/// the entire row or column being collapsed
		/// 
		/// </summary>
		/// <returns> TRUE if this cell is hidden, FALSE otherwise
		/// </returns>
		/// <summary> Dummy override</summary>
		/// <param name="flag">the hidden flag
		/// </param>
		virtual public bool Hidden
		{
			get
			{
				return false;
			}
			
			set
			{
			}
			
		}
		/// <summary> Dummy override</summary>
		/// <param name="flag">dummy
		/// </param>
		virtual public bool Locked
		{
			set
			{
			}
			
		}
		/// <summary> Dummy override</summary>
		/// <param name="align">dummy
		/// </param>
		virtual public Alignment Alignment
		{
			set
			{
			}
			
		}
		/// <summary> Dummy override</summary>
		/// <param name="valign">dummy
		/// </param>
        virtual public AppLibrary.Write.VerticalAlignment VerticalAlignment
		{
			set
			{
			}
			
		}
		/// <summary> The row of this empty cell</summary>
		private int row;
		/// <summary> The column number of this empty cell</summary>
		private int col;
		
		/// <summary> Constructs an empty cell at the specified position
		/// 
		/// </summary>
		/// <param name="c">the zero based column
		/// </param>
		/// <param name="r">the zero based row
		/// </param>
		public EmptyCell(int c, int r)
		{
			row = r;
			col = c;
		}
		
		/// <summary> Accessor for the format which is applied to this cell
		/// 
		/// </summary>
		/// <returns> the format applied to this cell
		/// </returns>
        public virtual AppLibrary.Format.CellFormat CellFormat
		{
		get
		{
		return null;
		}
		}
		
		/// <summary> Dummy override</summary>
		/// <param name="line">dummy
		/// </param>
		/// <param name="border">dummy
		/// </param>
        public virtual void setBorder(AppLibrary.Write.Border border, AppLibrary.Write.BorderLineStyle line)
		{
		}
		
		/// <summary> Dummy override</summary>
		/// <param name="cf">dummy
		/// </param>
        public virtual void setCellFormat(AppLibrary.Format.CellFormat cf)
		{
		}
		
		/// <summary> Dummy override</summary>
		/// <param name="cf">dummy
		/// </param>
		/// <deprecated>
		/// </deprecated>
        public virtual void setCellFormat(AppLibrary.ReadExcel .CellFormat cf)
		{
		}
		
		/// <summary> Implementation of the deep copy function
		/// 
		/// </summary>
		/// <param name="c">the column which the new cell will occupy
		/// </param>
		/// <param name="r">the row which the new cell will occupy
		/// </param>
		/// <returns>  a copy of this cell, which can then be added to the sheet
		/// </returns>
		public virtual WritableCell copyTo(int c, int r)
		{
			return new EmptyCell(c, r);
		}
	}
}
