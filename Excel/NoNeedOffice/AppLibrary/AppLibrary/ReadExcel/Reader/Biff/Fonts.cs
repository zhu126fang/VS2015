
using System;
using System.Collections;
using AppLibrary.common;
namespace AppLibrary.Biff
{
	
 	
	/// <summary> A container for the list of fonts used in this workbook</summary>
	public class Fonts
	{
		/// <summary> The list of fonts</summary>
		private ArrayList fonts;
		
		/// <summary> The default number of fonts</summary>
		private const int numDefaultFonts = 4;
		
		/// <summary> Constructor</summary>
		public Fonts()
		{
			fonts = new ArrayList();
		}
		
		/// <summary> Adds a font record to this workbook.  If the FontRecord passed in has not
		/// been initialized, then its font index is determined based upon the size
		/// of the fonts list.  The FontRecord's initialized method is called, and
		/// it is added to the list of fonts.
		/// 
		/// </summary>
		/// <param name="f">the font to add
		/// </param>
		public virtual void  addFont(FontRecord f)
		{
			if (!f.IsInitialized())
			{
				int pos = fonts.Count;
				
				// Remember that the pos with index 4 is skipped
				if (pos >= 4)
				{
					pos++;
				}
				
				f.initialize(pos);
				fonts.Add(f);
			}
		}
		
		/// <summary> Used by FormattingRecord for retrieving the fonts for the
		/// hardcoded styles
		/// 
		/// </summary>
		/// <param name="index">the index of the font to return
		/// </param>
		/// <returns> the font with the specified font index
		/// </returns>
		public virtual FontRecord getFont(int index)
		{
			// remember to allow for the fact that font index 4 is not used
			if (index > 4)
			{
				index--;
			}
			
			return (FontRecord) fonts[index];
		}
		
 		//  /**
		//   * Writes out the list of fonts
		//   *
		//   * @param outputFile the compound file to write the data to
		//   * @exception IOException
		//   */
		//  public void write(File outputFile) throws IOException
		//  {
		//    Iterator i = fonts.iterator();
		//
		//    FontRecord font = null;
		//    while (i.hasNext())
		//    {
		//      font = (FontRecord) i.next();
		//      outputFile.write(font);
		//    }
		//  }
		//
		/// <summary> Rationalizes all the fonts, removing any duplicates
		/// 
		/// </summary>
		/// <returns> the mappings between new indexes and old ones
		/// </returns>
		internal virtual IndexMapping rationalize()
		{
			IndexMapping mapping = new IndexMapping(fonts.Count + 1);
			// allow for skipping record 4
			
			ArrayList newfonts = new ArrayList();
			FontRecord fr = null;
			int numremoved = 0;
			
			// Preserve the default fonts
			for (int i = 0; i < numDefaultFonts; i++)
			{
				fr = (FontRecord) fonts[i];
				newfonts.Add(fr);
				mapping.setMapping(fr.FontIndex, fr.FontIndex);
			}
			
			// Now do the rest
			//    Iterator it = null;
//			FontRecord fr2 = null;
			bool duplicate = false;
			for (int i = numDefaultFonts; i < fonts.Count; i++)
			{
				fr = (FontRecord) fonts[i];
				
				// Compare to all the fonts currently on the list
				duplicate = false;
				foreach (FontRecord fr2 in newfonts)
				{
					if (duplicate) break;
				
					if (fr.Equals(fr2))
					{
						duplicate = true;
						mapping.setMapping(fr.FontIndex,
							mapping.getNewIndex(fr2.FontIndex));
						numremoved++;
					}
				}
				
				if (!duplicate)
				{
					// Add to the new list
					newfonts.Add(fr);
					int newindex = fr.FontIndex - numremoved;
					Assert.verify(newindex > 4);
					mapping.setMapping(fr.FontIndex, newindex);
				}
			}
			
			// Iterate through the remaining fonts, updating all the font indices
			foreach (FontRecord fr3 in newfonts)
			{
			fr3.initialize(mapping.getNewIndex(fr3.FontIndex));
			}
			
			fonts = newfonts;
			
			return mapping;
		}
	}
}
