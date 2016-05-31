 
using System;
namespace AppLibrary.ReadExcel
{
	
	/// <summary> This type represents the Microsoft concept of a Boolean.  Accordingly, this
	/// cell represents either TRUE, FALSE or an error condition.  This third
	/// state naturally makes handling BooleanCells quite tricky, and use of
	/// the specific access methods should be handled with care
	/// </summary>
	public interface BooleanCell : Cell
		{
			/// <summary> Gets the boolean value stored in this cell.  If this cell contains an
			/// error, then returns FALSE.  Always query this cell type using the
			/// accessor method isError() prior to calling this method
			/// 
			/// </summary>
			/// <returns> TRUE if this cell contains TRUE, FALSE if it contains FALSE or
			/// an error code
			/// </returns>
			bool BooleanValue
			{
				get;
			}
		}
}
