
using System;
using AppLibrary.common;

namespace AppLibrary.Biff
{
	
	/// <summary> This class is a wrapper for a list of mappings between indices.
	/// It is used when removing duplicate records and specifies the new
	/// index for cells which have the duplicate format
	/// </summary>
	public sealed class IndexMapping
	{
		/// <summary> The logger</summary>
		private static Logger logger;
		
		/// <summary> The array of new indexes for an old one</summary>
		private int[] newIndices;
		
		/// <summary> Constructor
		/// 
		/// </summary>
		/// <param name="size">the number of index numbers to be mapped
		/// </param>
		internal IndexMapping(int size)
		{
			newIndices = new int[size];
		}
		
		/// <summary> Sets a mapping</summary>
		/// <param name="oldIndex">the old index
		/// </param>
		/// <param name="newIndex">the new index
		/// </param>
		internal void  setMapping(int oldIndex, int newIndex)
		{
			newIndices[oldIndex] = newIndex;
		}
		
		/// <summary> Gets the new cell format index</summary>
		/// <param name="oldIndex">the existing index number
		/// </param>
		/// <returns> the new index number
		/// </returns>
		public int getNewIndex(int oldIndex)
		{
			return newIndices[oldIndex];
		}
		static IndexMapping()
		{
			logger = Logger.getLogger(typeof(IndexMapping));
		}
	}
}
