
using System;
namespace AppLibrary.ReadExcel
{
	
	/// <summary> Base exception class for JExcelAPI  exceptions</summary>
	public class JXLException:System.Exception
	{
		/// <summary> Constructor
		/// 
		/// </summary>
		/// <param name="message">the exception message
		/// </param>
		protected internal JXLException(string message):base(message)
		{
		}
	}
}
