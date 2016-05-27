using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//0. 导入命名空间： 
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;

namespace Excel_Sheet
{
    public partial class Form1 : Form
    {
        //全局静态变量
        public static Microsoft.Office.Interop.Excel.Application app = null;
        public static Workbooks wkbs=null;
        public static _Workbook _wkb=null;
        public static Sheets shs = null;
        public static _Worksheet _wsh = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_show_Click(object sender, EventArgs e)
        {
            // 显示
            app.Visible = true;
        }

        private void button_quit_Click(object sender, EventArgs e)
        {
            //设置禁止弹出保存和覆盖的询问提示框  
            app.DisplayAlerts = false;
            app.AlertBeforeOverwriting = false;

            app.Quit();

            //释放掉多余的excel进程
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. 如何打开已有excel文档，或者创建一个新的excel文档 
            app = new Microsoft.Office.Interop.Excel.Application();
            wkbs = app.Workbooks;
            _wkb = wkbs.Add(true);

            //textBox1.Text = "如何打开已有excel文档，或者创建一个新的excel文档";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //2.取得、删除和添加sheet
            shs = _wkb.Sheets;
            _wsh = (_Worksheet)shs.get_Item(1);
            textBox1.Text = _wsh.Name;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //删除sheet必须的设置
            app.DisplayAlerts = false;
            _wsh.Delete();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            for (int i = 1; i < 10; i++)
            {
                _wsh.Cells[i 1] = i;
                _wsh.Cells[1, 1].Interior.ColorIndex = 3;
            }

            //行列宽度
            ((Range)_wsh.Rows[3, Missing.Value]).RowHeight = 5;
            ((Range)_wsh.Columns[3, Missing.Value]).ColumnWidth = 20;

        }
    }
}
