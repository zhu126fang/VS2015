
using System;
namespace AppLibrary.Biff
{
	
	/// <summary> The interface implemented by the various number and date format styles.
	/// The methods on this interface are called internally when generating a
	/// spreadsheet
	/// </summary>
	public interface DisplayFormat
		{
			/// <summary> Accessor for the index style of this format
			/// 
			/// </summary>
			/// <returns> the index for this format
			/// </returns>
			int FormatIndex
			{
				get;
				
			}
			/// <summary> Accessor to see whether this format has been initialized
			/// 
			/// </summary>
			/// <returns> TRUE if initialized, FALSE otherwise
			/// </returns>
			bool isInitialized();

			/// <summary> Accessor to determine whether or not this format is built in
			/// 
			/// </summary>
			/// <returns> TRUE if this format is a built in format, FALSE otherwise
			/// </returns>
			bool isBuiltIn();
			
			/// <summary> Initializes this format with the specified index number
			/// 
			/// </summary>
			/// <param name="pos">the position of this format record in the workbook
			/// </param>
			void  initialize(int pos);
		}
}
