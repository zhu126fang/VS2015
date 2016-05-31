
using System;
namespace AppLibrary.Format
{
	
	/// <summary> Enumeration type which contains the available excel paper sizes and
	/// their codes
	/// </summary>
	public sealed class PaperSize
	{
		/// <summary> Accessor for the internal binary value association with this paper
		/// size
		/// 
		/// </summary>
		/// <returns> the internal value
		/// </returns>
		public int Value
		{
			get
			{
				return val;
			}
			
		}
		/// <summary> The excel encoding</summary>
		private int val;
		
		/// <summary> The paper sizes</summary>
		private static PaperSize[] paperSizes;
		
		/// <summary> Constructor</summary>
		private PaperSize(int v)
		{
			val = v;
			
			// Grow the array and add this to it
			PaperSize[] newarray = new PaperSize[paperSizes.Length + 1];
			Array.Copy((System.Array) paperSizes, 0, (System.Array) newarray, 0, paperSizes.Length);
			newarray[paperSizes.Length] = this;
			paperSizes = newarray;
		}
		
		private class Dummy
		{
		}
		
		private static readonly Dummy unknown = new Dummy();
		
		/// <summary> Constructor with a dummy parameter for unknown paper sizes</summary>
		private PaperSize(int v, Dummy u)
		{
			val = v;
		}
		
		/// <summary> Gets the paper size for a specific value
		/// 
		/// </summary>
		/// <param name="val">the value
		/// </param>
		/// <returns> the paper size
		/// </returns>
		public static PaperSize getPaperSize(int val)
		{
			bool found = false;
			int pos = 0;
			
			while (!found && pos < paperSizes.Length)
			{
				if (paperSizes[pos].Value == val)
				{
					found = true;
				}
				else
				{
					pos++;
				}
			}
			
			if (found)
			{
				return paperSizes[pos];
			}
			
			return new PaperSize(val, unknown);
		}
		
		/// <summary> A4</summary>
		public static PaperSize A4;
		
		/// <summary> Small A4</summary>
		public static PaperSize A4_SMALL;
		
		/// <summary> A5</summary>
		public static PaperSize A5;
		
		/// <summary> US Letter</summary>
		public static PaperSize LETTER;
		
		/// <summary> US Legal</summary>
		public static PaperSize LEGAL;
		
		/// <summary> A3</summary>
		public static PaperSize A3;
		static PaperSize()
		{
			paperSizes = new PaperSize[0];
			A4 = new PaperSize(0x9);
			A4_SMALL = new PaperSize(0xa);
			A5 = new PaperSize(0xb);
			LETTER = new PaperSize(0x1);
			LEGAL = new PaperSize(0x5);
			A3 = new PaperSize(0x8);
		}
	}
}