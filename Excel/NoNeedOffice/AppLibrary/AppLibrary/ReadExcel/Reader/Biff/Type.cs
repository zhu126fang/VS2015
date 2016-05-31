
using System;
namespace AppLibrary.Biff
{
	
	/// <summary> An enumeration class which contains the  biff types</summary>
	public sealed class Type
	{
		/// <summary> The biff value for this type</summary>
		public int Value;
		/// <summary> An array of all types</summary>
        private static AppLibrary.Biff.Type[] types;
		
		/// <summary> Constructor
		/// Sets the biff value and adds this type to the array of all types
		/// 
		/// </summary>
		/// <param name="v">the biff code for the type
		/// </param>
		private Type(int v)
		{
			Value = v;
			
			// Add to the list of available types
            AppLibrary.Biff.Type[] newTypes = new AppLibrary.Biff.Type[types.Length + 1];
			Array.Copy(types, 0, newTypes, 0, types.Length);
			newTypes[types.Length] = this;
			types = newTypes;
		}
		
		/// <summary> Standard hash code method</summary>
		/// <returns> the hash code
		/// </returns>
		public override int GetHashCode()
		{
			return Value;
		}
		
		/// <summary> Standard equals method</summary>
		/// <param name="o">the object to compare
		/// </param>
		/// <returns> TRUE if the objects are equal, FALSE otherwise
		/// </returns>
		public  override bool Equals(System.Object o)
		{
			if (o == this)
			{
				return true;
			}

            if (!(o is AppLibrary.Biff.Type))
			{
				return false;
			}

            AppLibrary.Biff.Type t = (AppLibrary.Biff.Type)o;
			
			return Value == t.Value;
		}
		
		/// <summary> Gets the type object from its integer value</summary>
		/// <param name="v">the internal code
		/// </param>
		/// <returns> the type
		/// </returns>
        public static AppLibrary.Biff.Type getType(int v)
		{
			for (int i = 0; i < types.Length; i++)
			{
				if (types[i].Value == v)
				{
					return types[i];
				}
			}
			
			return UNKNOWN;
		}


        public static readonly AppLibrary.Biff.Type BOF;
        public static readonly AppLibrary.Biff.Type EOF;
        public static readonly AppLibrary.Biff.Type BOUNDSHEET;
        public static readonly AppLibrary.Biff.Type SUPBOOK;
        public static readonly AppLibrary.Biff.Type EXTERNSHEET;
        public static readonly AppLibrary.Biff.Type DIMENSION;
		public static readonly AppLibrary.Biff.Type BLANK;
		public static readonly AppLibrary.Biff.Type MULBLANK;
		public static readonly AppLibrary.Biff.Type ROW;
		public static readonly AppLibrary.Biff.Type NOTE;
		public static readonly AppLibrary.Biff.Type TXO;
		public static readonly AppLibrary.Biff.Type RK;
		public static readonly AppLibrary.Biff.Type RK2;
		public static readonly AppLibrary.Biff.Type MULRK;
		public static readonly AppLibrary.Biff.Type INDEX;
		public static readonly AppLibrary.Biff.Type DBCELL;
		public static readonly AppLibrary.Biff.Type SST;
		public static readonly AppLibrary.Biff.Type COLINFO;
		public static readonly AppLibrary.Biff.Type EXTSST;
		public static readonly AppLibrary.Biff.Type CONTINUE;
		public static readonly AppLibrary.Biff.Type LABEL;
		public static readonly AppLibrary.Biff.Type RSTRING;
		public static readonly AppLibrary.Biff.Type LABELSST;
		public static readonly AppLibrary.Biff.Type NUMBER;
		public static readonly AppLibrary.Biff.Type NAME;
		public static readonly AppLibrary.Biff.Type TABID;
		public static readonly AppLibrary.Biff.Type ARRAY;
		public static readonly AppLibrary.Biff.Type STRING;
		public static readonly AppLibrary.Biff.Type FORMULA;
		public static readonly AppLibrary.Biff.Type FORMULA2;
		public static readonly AppLibrary.Biff.Type SHAREDFORMULA;
		public static readonly AppLibrary.Biff.Type FORMAT;
		public static readonly AppLibrary.Biff.Type XF;
		public static readonly AppLibrary.Biff.Type BOOLERR;
		public static readonly AppLibrary.Biff.Type INTERFACEHDR;
		public static readonly AppLibrary.Biff.Type SAVERECALC;
		public static readonly AppLibrary.Biff.Type INTERFACEEND;
		public static readonly AppLibrary.Biff.Type XCT;
		public static readonly AppLibrary.Biff.Type CRN;
		public static readonly AppLibrary.Biff.Type DEFCOLWIDTH;
		public static readonly AppLibrary.Biff.Type DEFAULTROWHEIGHT;
		public static readonly AppLibrary.Biff.Type WRITEACCESS;
		public static readonly AppLibrary.Biff.Type WSBOOL;
		public static readonly AppLibrary.Biff.Type CODEPAGE;
		public static readonly AppLibrary.Biff.Type DSF;
		public static readonly AppLibrary.Biff.Type FNGROUPCOUNT;
		public static readonly AppLibrary.Biff.Type COUNTRY;
		public static readonly AppLibrary.Biff.Type PROTECT;
		public static readonly AppLibrary.Biff.Type SCENPROTECT;
		public static readonly AppLibrary.Biff.Type OBJPROTECT;
		public static readonly AppLibrary.Biff.Type PRINTHEADERS;
		public static readonly AppLibrary.Biff.Type HEADER;
		public static readonly AppLibrary.Biff.Type FOOTER;
		public static readonly AppLibrary.Biff.Type HCENTER;
		public static readonly AppLibrary.Biff.Type VCENTER;
		public static readonly AppLibrary.Biff.Type FILEPASS;
		public static readonly AppLibrary.Biff.Type SETUP;
		public static readonly AppLibrary.Biff.Type PRINTGRIDLINES;
		public static readonly AppLibrary.Biff.Type GRIDSET;
		public static readonly AppLibrary.Biff.Type GUTS;
		public static readonly AppLibrary.Biff.Type WINDOWPROTECT;
		public static readonly AppLibrary.Biff.Type PROT4REV;
		public static readonly AppLibrary.Biff.Type PROT4REVPASS;
		public static readonly AppLibrary.Biff.Type PASSWORD;
		public static readonly AppLibrary.Biff.Type REFRESHALL;
		public static readonly AppLibrary.Biff.Type WINDOW1;
		public static readonly AppLibrary.Biff.Type WINDOW2;
		public static readonly AppLibrary.Biff.Type BACKUP;
		public static readonly AppLibrary.Biff.Type HIDEOBJ;
		public static readonly AppLibrary.Biff.Type NINETEENFOUR;
		public static readonly AppLibrary.Biff.Type PRECISION;
		public static readonly AppLibrary.Biff.Type BOOKBOOL;
		public static readonly AppLibrary.Biff.Type FONT;
		public static readonly AppLibrary.Biff.Type MMS;
		public static readonly AppLibrary.Biff.Type CALCMODE;
		public static readonly AppLibrary.Biff.Type CALCCOUNT;
		public static readonly AppLibrary.Biff.Type REFMODE;
		public static readonly AppLibrary.Biff.Type TEMPLATE;
		public static readonly AppLibrary.Biff.Type OBJPROJ;
		public static readonly AppLibrary.Biff.Type DELTA;
		public static readonly AppLibrary.Biff.Type MERGEDCELLS;
		public static readonly AppLibrary.Biff.Type ITERATION;
		public static readonly AppLibrary.Biff.Type STYLE;
		public static readonly AppLibrary.Biff.Type USESELFS;
		public static readonly AppLibrary.Biff.Type HORIZONTALPAGEBREAKS;
		public static readonly AppLibrary.Biff.Type SELECTION;
		public static readonly AppLibrary.Biff.Type HLINK;
		public static readonly AppLibrary.Biff.Type OBJ;
		public static readonly AppLibrary.Biff.Type MSODRAWING;
		public static readonly AppLibrary.Biff.Type MSODRAWINGGROUP;
		public static readonly AppLibrary.Biff.Type LEFTMARGIN;
		public static readonly AppLibrary.Biff.Type RIGHTMARGIN;
		public static readonly AppLibrary.Biff.Type TOPMARGIN;
		public static readonly AppLibrary.Biff.Type BOTTOMMARGIN;
		public static readonly AppLibrary.Biff.Type EXTERNNAME;
		public static readonly AppLibrary.Biff.Type PALETTE;
		public static readonly AppLibrary.Biff.Type PLS;
		public static readonly AppLibrary.Biff.Type SCL;
		public static readonly AppLibrary.Biff.Type PANE;
		public static readonly AppLibrary.Biff.Type WEIRD1;
		public static readonly AppLibrary.Biff.Type SORT;
		// Chart types
		public static readonly AppLibrary.Biff.Type FONTX;
		public static readonly AppLibrary.Biff.Type IFMT;
		public static readonly AppLibrary.Biff.Type FBI;
		public static readonly AppLibrary.Biff.Type UNKNOWN;

		static Type()
		{
            types = new AppLibrary.Biff.Type[0];

			BOF = new AppLibrary.Biff.Type(0x809);
			EOF = new AppLibrary.Biff.Type(0x0a);
			BOUNDSHEET = new AppLibrary.Biff.Type(0x85);
			SUPBOOK = new AppLibrary.Biff.Type(0x1ae);
			EXTERNSHEET = new AppLibrary.Biff.Type(0x17);
			DIMENSION = new AppLibrary.Biff.Type(0x200);
			BLANK = new AppLibrary.Biff.Type(0x201);
			MULBLANK = new AppLibrary.Biff.Type(0xbe);
			ROW = new AppLibrary.Biff.Type(0x208);
			NOTE = new AppLibrary.Biff.Type(0x1c);
			TXO = new AppLibrary.Biff.Type(0x1b6);
			RK = new AppLibrary.Biff.Type(0x7e);
			RK2 = new AppLibrary.Biff.Type(0x27e);
			MULRK = new AppLibrary.Biff.Type(0xbd);
			INDEX = new AppLibrary.Biff.Type(0x20b);
			DBCELL = new AppLibrary.Biff.Type(0xd7);
			SST = new AppLibrary.Biff.Type(0xfc);
			COLINFO = new AppLibrary.Biff.Type(0x7d);
			EXTSST = new AppLibrary.Biff.Type(0xff);
			CONTINUE = new AppLibrary.Biff.Type(0x3c);
			LABEL = new AppLibrary.Biff.Type(0x204);
			RSTRING = new AppLibrary.Biff.Type(0xd6);
			LABELSST = new AppLibrary.Biff.Type(0xfd);
			NUMBER = new AppLibrary.Biff.Type(0x203);
			NAME = new AppLibrary.Biff.Type(0x18);
			TABID = new AppLibrary.Biff.Type(0x13d);
			ARRAY = new AppLibrary.Biff.Type(0x221);
			STRING = new AppLibrary.Biff.Type(0x207);
			FORMULA = new AppLibrary.Biff.Type(0x406);
			FORMULA2 = new AppLibrary.Biff.Type(0x6);
			SHAREDFORMULA = new AppLibrary.Biff.Type(0x4bc);
			FORMAT = new AppLibrary.Biff.Type(0x41e);
			XF = new AppLibrary.Biff.Type(0xe0);
			BOOLERR = new AppLibrary.Biff.Type(0x205);
			INTERFACEHDR = new AppLibrary.Biff.Type(0xe1);
			SAVERECALC = new AppLibrary.Biff.Type(0x5f);
			INTERFACEEND = new AppLibrary.Biff.Type(0xe2);
			XCT = new AppLibrary.Biff.Type(0x59);
			CRN = new AppLibrary.Biff.Type(0x5a);
			DEFCOLWIDTH = new AppLibrary.Biff.Type(0x55);
			DEFAULTROWHEIGHT = new AppLibrary.Biff.Type(0x225);
			WRITEACCESS = new AppLibrary.Biff.Type(0x5c);
			WSBOOL = new AppLibrary.Biff.Type(0x81);
			CODEPAGE = new AppLibrary.Biff.Type(0x42);
			DSF = new AppLibrary.Biff.Type(0x161);
			FNGROUPCOUNT = new AppLibrary.Biff.Type(0x9c);
			COUNTRY = new AppLibrary.Biff.Type(0x8c);
			PROTECT = new AppLibrary.Biff.Type(0x12);
			SCENPROTECT = new AppLibrary.Biff.Type(0xdd);
			OBJPROTECT = new AppLibrary.Biff.Type(0x63);
			PRINTHEADERS = new AppLibrary.Biff.Type(0x2a);
			HEADER = new AppLibrary.Biff.Type(0x14);
			FOOTER = new AppLibrary.Biff.Type(0x15);
			HCENTER = new AppLibrary.Biff.Type(0x83);
			VCENTER = new AppLibrary.Biff.Type(0x84);
			FILEPASS = new AppLibrary.Biff.Type(0x2f);
			SETUP = new AppLibrary.Biff.Type(0xa1);
			PRINTGRIDLINES = new AppLibrary.Biff.Type(0x2b);
			GRIDSET = new AppLibrary.Biff.Type(0x82);
			GUTS = new AppLibrary.Biff.Type(0x80);
			WINDOWPROTECT = new AppLibrary.Biff.Type(0x19);
			PROT4REV = new AppLibrary.Biff.Type(0x1af);
			PROT4REVPASS = new AppLibrary.Biff.Type(0x1bc);
			PASSWORD = new AppLibrary.Biff.Type(0x13);
			REFRESHALL = new AppLibrary.Biff.Type(0x1b7);
			WINDOW1 = new AppLibrary.Biff.Type(0x3d);
			WINDOW2 = new AppLibrary.Biff.Type(0x23e);
			BACKUP = new AppLibrary.Biff.Type(0x40);
			HIDEOBJ = new AppLibrary.Biff.Type(0x8d);
			NINETEENFOUR = new AppLibrary.Biff.Type(0x22);
			PRECISION = new AppLibrary.Biff.Type(0xe);
			BOOKBOOL = new AppLibrary.Biff.Type(0xda);
			FONT = new AppLibrary.Biff.Type(0x31);
			MMS = new AppLibrary.Biff.Type(0xc1);
			CALCMODE = new AppLibrary.Biff.Type(0x0d);
			CALCCOUNT = new AppLibrary.Biff.Type(0x0c);
			REFMODE = new AppLibrary.Biff.Type(0x0f);
			TEMPLATE = new AppLibrary.Biff.Type(0x60);
			OBJPROJ = new AppLibrary.Biff.Type(0xd3);
			DELTA = new AppLibrary.Biff.Type(0x10);
			MERGEDCELLS = new AppLibrary.Biff.Type(0xe5);
			ITERATION = new AppLibrary.Biff.Type(0x11);
			STYLE = new AppLibrary.Biff.Type(0x293);
			USESELFS = new AppLibrary.Biff.Type(0x160);
			HORIZONTALPAGEBREAKS = new AppLibrary.Biff.Type(0x1b);
			SELECTION = new AppLibrary.Biff.Type(0x1d);
			HLINK = new AppLibrary.Biff.Type(0x1b8);
			OBJ = new AppLibrary.Biff.Type(0x5d);
			MSODRAWING = new AppLibrary.Biff.Type(0xec);
			MSODRAWINGGROUP = new AppLibrary.Biff.Type(0xeb);
			LEFTMARGIN = new AppLibrary.Biff.Type(0x26);
			RIGHTMARGIN = new AppLibrary.Biff.Type(0x27);
			TOPMARGIN = new AppLibrary.Biff.Type(0x28);
			BOTTOMMARGIN = new AppLibrary.Biff.Type(0x29);
			EXTERNNAME = new AppLibrary.Biff.Type(0x23);
			PALETTE = new AppLibrary.Biff.Type(0x92);
			PLS = new AppLibrary.Biff.Type(0x4d);
			SCL = new AppLibrary.Biff.Type(0xa0);
			PANE = new AppLibrary.Biff.Type(0x41);
			WEIRD1 = new AppLibrary.Biff.Type(0xef);
			SORT = new AppLibrary.Biff.Type(0x90);
			// Chart types
			FONTX = new AppLibrary.Biff.Type(0x1026);
			IFMT = new AppLibrary.Biff.Type(0x104e);
			FBI = new AppLibrary.Biff.Type(0x1060);
			UNKNOWN = new AppLibrary.Biff.Type(0xffff);

		}
	}
}
