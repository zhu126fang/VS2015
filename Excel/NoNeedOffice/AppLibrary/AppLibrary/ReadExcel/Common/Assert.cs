
using System;
namespace AppLibrary.common
{
	
	/// <summary> Simple assertion mechanism for use during development</summary>
	public sealed class Assert
	{
		/// <summary> Throws an AssertionFailed exception if the specified condition is
		/// false
		/// 
		/// </summary>
		/// <param name="condition">The assertion condition which must be true
		/// </param>
		public static void  verify(bool condition)
		{
			if (!condition)
			{
				throw new AssertionFailed();
			}
		}
		
		/// <summary> If the condition evaluates to false, an AssertionFailed is thrown
		/// 
		/// </summary>
		/// <param name="message">A message thrown with the failed assertion
		/// </param>
		/// <param name="condition">If this evaluates to false, an AssertionFailed is thrown
		/// </param>
		public static void  verify(bool condition, string message)
		{
			if (!condition)
			{
				throw new AssertionFailed(message);
			}
		}
	}
}