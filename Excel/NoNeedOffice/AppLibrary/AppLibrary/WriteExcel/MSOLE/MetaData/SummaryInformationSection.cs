using System;
using System.Collections.Generic;
using System.Text;
using AppLibrary.Bits;

namespace AppLibrary.Metadata
{
    /// <summary>
    /// Represents a SummaryInformation stream in an Ole2 Document.
    /// </summary>
    public class SummaryInformationSection : MetadataStream.Section
    {
        private static readonly byte[] FORMAT_ID = new byte[] {
                0xE0, 0x85, 0x9F, 0xF2, 0xF9, 0x4F, 0x68, 0x10, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9 };

        private const uint ID_CODEPAGE = 1; //http://msdn2.microsoft.com/en-us/library/aa372045.aspx
        private const uint ID_TITLE = 2;
        private const uint ID_SUBJECT = 3;
        private const uint ID_AUTHOR = 4;
        private const uint ID_KEYWORDS = 5;
        private const uint ID_COMMENTS = 6;
        private const uint ID_TEMPLATE = 7;
        private const uint ID_LAST_SAVED_BY = 8;
        private const uint ID_REVISION_NUMBER = 9;
        private const uint ID_TOTAL_EDITING_TIME = 10;
        private const uint ID_LAST_PRINTED = 11;
        private const uint ID_CREATE_TIME_DATE = 12;
        private const uint ID_LAST_SAVED_TIME_DATE = 13;
        private const uint ID_NUMBER_OF_PAGES = 14;
        private const uint ID_NUMBER_OF_WORDS = 15;
        private const uint ID_NUMBER_OF_CHARACTERS = 16;
        private const uint ID_THUMBNAIL = 17;
        private const uint ID_NAME_OF_CREATING_APPLICATION = 18;
        private const uint ID_SECURITY = 19;

        /// <summary>
        /// Initializes a new instance of the SummaryInformationSection class.
        /// </summary>
        public SummaryInformationSection()
        {
            FormatId = FORMAT_ID;
            CodePage = 1252;
            LastSavedBy = Environment.UserName;
            NameOfCreatingApplication = "MDS MIS";
            Comments = "Design By MDS MIS";
            CreateTimeDate = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the CodePage of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public short? CodePage
        {
            get { return (short?)GetProperty(ID_CODEPAGE); }
            set { SetProperty(ID_CODEPAGE, Property.Types.VT_I2, value); }
        }

        /// <summary>
        /// Gets or sets the Title of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public string Title
        {
            get { return (string)GetProperty(ID_TITLE); }
            set { SetProperty(ID_TITLE, Property.Types.VT_LPSTR, value); }
        }

        /// <summary>
        /// Gets or sets the Subject of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public string Subject
        {
            get { return (string)GetProperty(ID_SUBJECT); }
            set { SetProperty(ID_SUBJECT, Property.Types.VT_LPSTR, value); }
        }

        /// <summary>
        /// Gets or sets the Author of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public string Author
        {
            get { return (string)GetProperty(ID_AUTHOR); }
            set { SetProperty(ID_AUTHOR, Property.Types.VT_LPSTR, value); }
        }

        /// <summary>
        /// Gets or sets the Keywords of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public string Keywords
        {
            get { return (string)GetProperty(ID_KEYWORDS); }
            set { SetProperty(ID_KEYWORDS, Property.Types.VT_LPSTR, value); }
        }

        /// <summary>
        /// Gets or sets the Comments of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public string Comments
        {
            get { return (string)GetProperty(ID_COMMENTS); }
            set { SetProperty(ID_COMMENTS, Property.Types.VT_LPSTR, value); }
        }

        /// <summary>
        /// Gets or sets the Template of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public string Template
        {
            get { return (string)GetProperty(ID_TEMPLATE); }
            set { SetProperty(ID_TEMPLATE, Property.Types.VT_LPSTR, value); }
        }

        /// <summary>
        /// Gets or sets the LastSavedBy of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public string LastSavedBy
        {
            get { return (string)GetProperty(ID_LAST_SAVED_BY); }
            set { SetProperty(ID_LAST_SAVED_BY, Property.Types.VT_LPSTR, value); }
        }

        /// <summary>
        /// Gets or sets the RevisionNumber of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public string RevisionNumber
        {
            get { return (string)GetProperty(ID_REVISION_NUMBER); }
            set { SetProperty(ID_REVISION_NUMBER, Property.Types.VT_LPSTR, value); }
        }

        /// <summary>
        /// Gets or sets the TotalEditingTime of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public DateTime? TotalEditingTime
        {
            get { return (DateTime?)GetProperty(ID_TOTAL_EDITING_TIME); }
            set { SetProperty(ID_TOTAL_EDITING_TIME, Property.Types.VT_FILETIME, value); }
        }

        /// <summary>
        /// Gets or sets the LastPrinted Date/Time of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public DateTime? LastPrinted
        {
            get { return (DateTime?)GetProperty(ID_LAST_PRINTED); }
            set { SetProperty(ID_LAST_PRINTED, Property.Types.VT_FILETIME, value); }
        }

        /// <summary>
        /// Gets or sets the CreateDateTime of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public DateTime? CreateTimeDate
        {
            get { return (DateTime?)GetProperty(ID_CREATE_TIME_DATE); }
            set { SetProperty(ID_CREATE_TIME_DATE, Property.Types.VT_FILETIME, value); }
        }

        /// <summary>
        /// Gets or sets the LastSavedDateTime of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public DateTime? LastSavedTimeDate
        {
            get { return (DateTime?)GetProperty(ID_LAST_SAVED_TIME_DATE); }
            set { SetProperty(ID_LAST_SAVED_TIME_DATE, Property.Types.VT_FILETIME, value); }
        }

        /// <summary>
        /// Gets or sets the NumberOfPages of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public int? NumberOfPages
        {
            get { return (int?)GetProperty(ID_NUMBER_OF_PAGES); }
            set { SetProperty(ID_NUMBER_OF_PAGES, Property.Types.VT_I4, value); }
        }

        /// <summary>
        /// Gets or sets the NumberOfWords of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public int? NumberOfWords
        {
            get { return (int?)GetProperty(ID_NUMBER_OF_WORDS); }
            set { SetProperty(ID_NUMBER_OF_WORDS, Property.Types.VT_I4, value); }
        }

        /// <summary>
        /// Gets or sets the NumberOfCharacters of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public int? NumberOfCharacters
        {
            get { return (int?)GetProperty(ID_NUMBER_OF_CHARACTERS); }
            set { SetProperty(ID_NUMBER_OF_CHARACTERS, Property.Types.VT_I4, value); }
        }

//        public object Thumbnail
//        {
//            get { return _thumbnail; }
//            set { _thumbnail = value; }
//        }

        /// <summary>
        /// Gets or sets the NameOfCreatingApplication of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public string NameOfCreatingApplication
        {
            get { return (string)GetProperty(ID_NAME_OF_CREATING_APPLICATION); }
            set { SetProperty(ID_NAME_OF_CREATING_APPLICATION, Property.Types.VT_LPSTR, value); }
        }

        /// <summary>
        /// Gets or sets the Security of this SummaryInformation Section.  Setting to null removes the property.
        /// </summary>
        public int? Security
        {
            get { return (int?)GetProperty(ID_SECURITY); }
            set { SetProperty(ID_SECURITY, Property.Types.VT_I4, value); }
        }
    }
}
