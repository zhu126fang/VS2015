
using System;
using AppLibrary.common;
using AppLibrary.Read.Biff;
namespace AppLibrary.Biff
{
	
	/// <summary> Extension of the standard RecordData which is used to support those
	/// records which, once read, may also be written
	/// </summary>
	public abstract class WritableRecordData:RecordData, ByteData
	{
		/// <summary> The maximum .Length allowed by Excel for any record .Length</summary>
		protected internal const int maxRecordLength = 8228;
		
		/// <summary> Constructor used by the writable records
		/// 
		/// </summary>
		/// <param name="t">the biff type of this record
		/// </param>
        protected internal WritableRecordData(AppLibrary.Biff.Type t)
            : base(t)
		{
		}
		
		/// <summary> Constructor used when reading a record
		/// 
		/// </summary>
		/// <param name="t">the raw data read from the biff file
		/// </param>
		protected internal WritableRecordData(Record t):base(t)
		{
		}
		
		/// <summary> Used when writing out records.  This portion of the method handles the
		/// biff code and the .Length of the record and appends on the data retrieved
		/// from the subclasses
		/// 
		/// </summary>
		/// <returns> the full record data to be written out to the compound file
		/// </returns>
		public sbyte[] getBytes()
		{
			sbyte[] data = getData();
			
			int dataLength = data.Length;
			
			// Don't the call the automatic continuation code for now
			//    Assert.verify(dataLength <= maxRecordLength - 4);
			// If the bytes .Length is greater than the max record .Length
			// then split out the data set into continue records
			if (data.Length > maxRecordLength - 4)
			{
				dataLength = maxRecordLength - 4;
				data = handleContinueRecords(data);
			}
			
			sbyte[] bytes = new sbyte[data.Length + 4];
			
			Array.Copy(data, 0, bytes, 4, data.Length);
			
			IntegerHelper.getTwoBytes(Code, bytes, 0);
			IntegerHelper.getTwoBytes(dataLength, bytes, 2);
			
			return bytes;
		}
		
		/// <summary> The number of bytes for this record exceeds the maximum record
		/// .Length, so a continue is required
		/// </summary>
		/// <param name="data">the raw data
		/// </param>
		/// <returns>  the continued data
		/// </returns>
		private sbyte[] handleContinueRecords(sbyte[] data)
		{
			// Deduce the number of continue records
			int continuedData = data.Length - maxRecordLength - 4;
			int numContinueRecords = continuedData / (maxRecordLength - 4) + 1;
			
			// Create the new byte array, allowing for the continue records
			// code and .Length
			sbyte[] newdata = new sbyte[data.Length + numContinueRecords * 4];
			
			// Copy the bona fide record data into the beginning of the super
			// record
			Array.Copy(data, 0, newdata, 0, maxRecordLength - 4);
			int oldarraypos = maxRecordLength - 4;
			int newarraypos = maxRecordLength - 4;
			
			// Now handle all the continue records
			for (int i = 0; i < numContinueRecords; i++)
			{
				// The number of bytes to add into the new array
				int length = System.Math.Min(data.Length - oldarraypos, maxRecordLength - 4);
				
				// Add in the continue record code
                IntegerHelper.getTwoBytes(AppLibrary.Biff.Type.CONTINUE.Value, newdata, newarraypos);
				IntegerHelper.getTwoBytes(length, newdata, newarraypos + 2);
				
				// Copy in as much as the new data as possible
				Array.Copy(data, oldarraypos, newdata, newarraypos + 4, length);
				
				// Update the position counters
				oldarraypos += length;
				newarraypos += length + 4;
			}
			
			return newdata;
		}
		
		/// <summary> Abstract method called by the getBytes method.  Subclasses implement
		/// this method to incorporate their specific binary data - excluding the
		/// biff code and record .Length, which is handled by this class
		/// 
		/// </summary>
		/// <returns> subclass specific biff data
		/// </returns>
		public abstract sbyte[] getData();
	}
}
