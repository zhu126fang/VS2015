
using System;
using AppLibrary.Read.Biff;
namespace AppLibrary.Biff
{
	
	/// <summary> A record detailing whether the sheet is protected</summary>
	public class WorkspaceInformationRecord:WritableRecordData
	{
		/// <summary> Gets the fit to pages flag
		/// 
		/// </summary>
		/// <returns> TRUE if fit to pages is set
		/// </returns>
		/// <summary> Sets the fit to page flag
		/// 
		/// </summary>
		/// <param name="b">fit to page indicator
		/// </param>
		virtual public bool FitToPages
		{
			get
			{
				return ((wsoptions & fitToPages) != 0);
			}
			
			set
			{
				wsoptions = value?wsoptions | fitToPages:wsoptions & ~ fitToPages;
			}
			
		}
		/// <summary> The options byte</summary>
		private int wsoptions;
		
		// the masks
		private const int fitToPages = 0x100;
		private const int defaultOptions = 0x4c1;
		
		/// <summary> Constructs this object from the raw data
		/// 
		/// </summary>
		/// <param name="t">the raw data
		/// </param>
		public WorkspaceInformationRecord(Record t):base(t)
		{
			sbyte[] data = getRecord().Data;
			
			wsoptions = IntegerHelper.getInt(data[0], data[1]);
		}
		
		/// <summary> Constructs this object from the raw data</summary>
        public WorkspaceInformationRecord()
            : base(AppLibrary.Biff.Type.WSBOOL)
		{
			wsoptions = defaultOptions;
		}
		
		/// <summary> Gets the binary data for output to file
		/// 
		/// </summary>
		/// <returns> the binary data
		/// </returns>
		public override sbyte[] getData()
		{
			sbyte[] data = new sbyte[2];
			
			// Hard code in the information for now
			IntegerHelper.getTwoBytes(wsoptions, data, 0);
			
			return data;
		}
	}
}
