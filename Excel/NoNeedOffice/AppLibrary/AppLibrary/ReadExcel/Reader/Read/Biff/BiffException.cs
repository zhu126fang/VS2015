 
using System;
using AppLibrary.ReadExcel;
namespace AppLibrary.Read.Biff
{
	
	/// <summary> Exception thrown when reading a biff file</summary>
	public class BiffException:JXLException
	{
		/// <summary> Inner class containing the various error messages</summary>
		public class BiffMessage
		{
			/// <summary> The formatted message</summary>
			public string message;
			/// <summary> Constructs this exception with the specified message
			/// 
			/// </summary>
			/// <param name="m">the messageA
			/// </param>
			internal BiffMessage(string m)
			{
				message = m;
			}
		}
		
		
		internal static readonly BiffMessage unrecognizedBiffVersion = new BiffMessage("Unrecognized biff version");
		
		
		internal static readonly BiffMessage expectedGlobals = new BiffMessage("Expected globals");
		
		
		internal static readonly BiffMessage excelFileTooBig = new BiffMessage("Warning:  not all of the excel file could be read");
		
		
		internal static readonly BiffMessage excelFileNotFound = new BiffMessage("The input file was not found");
		
		
		internal static readonly BiffMessage unrecognizedOLEFile = new BiffMessage("Unable to recognize OLE stream");
		
		
		internal static readonly BiffMessage streamNotFound = new BiffMessage("Compound file does not contain the specified stream");
		
		
		internal static readonly BiffMessage passwordProtected = new BiffMessage("The workbook is password protected");
		
		/// <summary> Constructs this exception with the specified message
		/// 
		/// </summary>
		/// <param name="m">the message
		/// </param>
		public BiffException(BiffMessage m):base(m.message)
		{
		}
	}
}
