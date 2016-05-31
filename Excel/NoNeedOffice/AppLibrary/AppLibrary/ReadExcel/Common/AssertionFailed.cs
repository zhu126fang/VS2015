
using System;
namespace AppLibrary.common
{
	
	/// <summary> An exception thrown when an assert (from the Assert class) fails</summary>
	public class AssertionFailed:System.SystemException
	{
		/// <summary> Default constructor
		/// Prints the stack trace
		/// </summary>
		public AssertionFailed():base()
		{
			//    printStackTrace();
		}
		
		/// <summary> Constructor with message
		/// Prints the stack trace
		/// 
		/// </summary>
		/// <param name="s">Message thrown with the assertion
		/// </param>
		public AssertionFailed(string s):base(s)
		{
		}
	}
}