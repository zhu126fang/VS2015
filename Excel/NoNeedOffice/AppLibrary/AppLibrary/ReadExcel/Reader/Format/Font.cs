
using System;
namespace AppLibrary.Format
{
	
	/// <summary> Interface which exposes the user font display information to the user</summary>
	public interface Font
		{
			/// <summary> Gets the name of this font
			/// 
			/// </summary>
			/// <returns> the name of this font
			/// </returns>
			string Name
			{
				get;
				
			}
			/// <summary> Gets the point size for this font, if the font hasn't been initialized
			/// 
			/// </summary>
			/// <returns> the point size
			/// </returns>
			int PointSize
			{
				get;
				
			}
			/// <summary> Gets the bold weight for this font
			/// 
			/// </summary>
			/// <returns> the bold weight for this font
			/// </returns>
			int BoldWeight
			{
				get;
				
			}
			/// <summary> Returns the italic flag
			/// 
			/// </summary>
			/// <returns> TRUE if this font is italic, FALSE otherwise
			/// </returns>
			bool Italic
			{
				get;
				
			}
			/// <summary> Gets the underline style for this font
			/// 
			/// </summary>
			/// <returns> the underline style
			/// </returns>
			UnderlineStyle UnderlineStyle
			{
				get;
				
			}
			/// <summary> Gets the colour for this font
			/// 
			/// </summary>
			/// <returns> the colour
			/// </returns>
			Colour Colour
			{
				get;
				
			}
			/// <summary> Gets the script style
			/// 
			/// </summary>
			/// <returns> the script style
			/// </returns>
			ScriptStyle ScriptStyle
			{
				get;
				
			}
		}
}