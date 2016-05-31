
using System;
namespace AppLibrary.Biff
{
	
	/// <summary> Represents a built in, rather than a user defined, style.
	/// This class is used by the FormattingRecords class when writing out the hard*
	/// coded styles
	/// </summary>
	class BuiltInStyle:WritableRecordData
	{
		/// <summary> The XF index of this style</summary>
		private int xfIndex;
		/// <summary> The reference number of this style</summary>
		private int styleNumber;
		
		/// <summary> Constructor
		/// 
		/// </summary>
		/// <param name="xfind">the xf index of this style
		/// </param>
		/// <param name="sn">the style number of this style
		/// </param>
        public BuiltInStyle(int xfind, int sn)
            : base(AppLibrary.Biff.Type.STYLE)
		{
			
			xfIndex = xfind;
			styleNumber = sn;
		}
		
		/// <summary> Abstract method implementation to get the raw byte data ready to write out
		/// 
		/// </summary>
		/// <returns> The byte data
		/// </returns>
		public override sbyte[] getData()
		{
			sbyte[] data = new sbyte[4];
			
			IntegerHelper.getTwoBytes(xfIndex, data, 0);
			
			// Set the built in bit
			data[1] |= (sbyte) -0x80;
			
			data[2] = (sbyte) styleNumber;
			
			// Set the outline level
			data[3] = (sbyte) -0x01;
			
			return data;
		}
	}
}
