using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;

namespace Excel_Open
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbooks wbks = app.Workbooks;
            try
            {
                _Workbook _wbk = wbks.Open(@"D:\Users\Administrator\Documents\Visual Studio 2015\Projects\Excel_Demo\Demo.xls");
                app.Visible = true;
            }
            catch
            {
                MessageBox.Show("打开文件失败");
            }
        }
    }
}
