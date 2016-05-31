 
using System;
using System.Collections;
//using System.Resources;
using AppLibrary.common;
using AppLibrary.Utils;



namespace AppLibrary.Biff.Formula
{
	
	/// <summary> A class which contains the function names for the current workbook. The
	/// function names can potentially vary from workbook to workbook depending
	/// on the locale
	/// </summary>
	public class FunctionNames
	{
		/// <summary> The logger class</summary>
		private static Logger logger;
		
		/// <summary> A hash mapping keyed on the function and returning its locale specific 
		/// name
		/// </summary>
		private Hashtable names;
		
		/// <summary> A hash mapping keyed on the locale specific name and returning the 
		/// function
		/// </summary>
		private Hashtable functions;
		
		/// <summary> Constructor
		/// @ws the workbook settings
		/// </summary>
		public FunctionNames(System.Globalization.CultureInfo l)
		{

            ResourceManager rm = new ResourceManager("AppLibrary.Biff.Formula.FunctionNames", l, this.GetType().Assembly);

			names = new Hashtable(Function.functions.Length);
			functions = new Hashtable(Function.functions.Length);
			
			// Iterate through all the functions, adding them to the hash maps
			Function f = null;
			string n = null;
			string propname = null;
			for (int i = 0; i < Function.functions.Length; i++)
			{
				f = Function.functions[i];
				propname = f.PropertyName;
				
				n = propname.Length != 0 ? rm.GetString(propname) : null;
				
				
				if ((System.Object) n != null)
				{
					names[f] =  n;
					functions[n] =  f;
				}
			}
		}
		
		/// <summary> Gets the function for the specified name</summary>
		internal virtual Function getFunction(string s)
		{
			return (Function) functions[s];
		}
		
		/// <summary> Gets the name for the function</summary>
		internal virtual string getName(Function f)
		{
			return (string) names[f];
		}
		static FunctionNames()
		{
			logger = Logger.getLogger(typeof(FunctionNames));
		}
	}
}
