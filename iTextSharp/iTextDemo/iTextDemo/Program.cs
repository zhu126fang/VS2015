using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Microsoft.VisualBasic.FileIO;

namespace iTextDemo
{
    class Program
    {
        static void Main(string[] args)
        {
           ReportDemo demo = new ReportDemo();
            demo.GeneratePDFReport();

          

        }

    }
}
