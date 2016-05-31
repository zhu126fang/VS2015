
using System;
namespace AppLibrary.Biff
{
	
	/// <summary> Interface which provides a method for transferring chunks of binary
	/// data from one Excel file (read in) to another (written out)
	/// </summary>
	public interface ByteData
		{
			/// <summary> Used when writing out records
			/// 
			/// </summary>
			/// <returns> the full data to be included in the final compound file
			/// </returns>
			sbyte[] getBytes();
		}
}
