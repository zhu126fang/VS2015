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

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbooks wbks = app.Workbooks;
            try
            {
                //_Workbook _wbk = wbks.Add(true);
                _Workbook _wbk = wbks.Open("D:\\Francis\\AEF\\HZL1\\HZL1\\HZL1.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Visible = false;        //不在任务栏显示Excel
            }
            catch
            {
                MessageBox.Show("打开文件失败");
            }

            //打开后退出，否则打开的Excel无法正常关闭
            System.Environment.Exit(0);
        }
    }
}
