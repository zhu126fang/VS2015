namespace AppLibrary.WriteExcel
{
    /// <summary>
    /// The different types of Cell values.
    /// </summary>
	public enum CellTypes
	{
        /// <summary>Error</summary>
		Error,

        /// <summary>Null</summary>
        Null,

        /// <summary>Integer</summary>
        Integer,

        /// <summary>Text</summary>
        Text,

        /// <summary>Floating Point Number</summary>
        Float,

        /// <summary>Formula</summary>
        Formula,
        /// <summary>
        /// Image
        /// </summary>
        Image
	}
}
