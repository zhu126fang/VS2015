
using System;
namespace AppLibrary.Biff
{
	
	/// <summary> Excel places a constraint on the number of format records that
	/// are allowed.  This exception is thrown when that number is exceeded
	/// This is a static exception and  should be handled internally
	/// </summary>
	public class NumFormatRecordsException:System.Exception
	{
		/// <summary> Constructor</summary>
		public NumFormatRecordsException():base("Internal error:  max number of FORMAT records exceeded")
		{
		}
	}
}
