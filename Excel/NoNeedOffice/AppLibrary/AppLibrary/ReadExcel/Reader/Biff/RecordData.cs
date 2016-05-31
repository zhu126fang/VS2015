
using System;
using AppLibrary.Read.Biff;
namespace AppLibrary.Biff
{
	
	/// <summary> The record data within a record</summary>
	public abstract class RecordData 
	{
		/// <summary> Accessor for the code
		/// 
		/// </summary>
		/// <returns> the code
		/// </returns>
		virtual protected internal int Code
		{
			get
			{
				return code;
			}
			
		}
		/// <summary> The raw data</summary>
		private Record record;
		
		/// <summary> The Biff code for this record.  This is set up when the record is
		/// used for writing
		/// </summary>
		private int code;
		
		/// <summary> Constructs this object from the raw data
		/// 
		/// </summary>
		/// <param name="r">the raw data
		/// </param>
		protected internal RecordData(Record r)
		{
			record = r;
			code = r.Code;
		}
		
		/// <summary> Constructor used by the writable records
		/// 
		/// </summary>
		/// <param name="t">the type
		/// </param>
        protected internal RecordData(AppLibrary.Biff.Type t)
		{
			code = t.Value;
		}
		
		/// <summary> Returns the raw data to its subclasses
		/// 
		/// </summary>
		/// <returns> the raw data
		/// </returns>
		public virtual Record getRecord()
		{
			return record;
		}
	}
}
