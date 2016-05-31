using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                AppLibrary.WriteExcel.XlsDocument doc = new AppLibrary.WriteExcel.XlsDocument();
                doc.FileName = "Report.xls";
                string SheetName = string.Empty;
                //记录条数
                int mCount = 1;
                //每个SHEET的数量
                int inv = 1;
                //计算当前多少个SHEET
                int k = 1;//Convert.ToInt32(Math.Round(Convert.ToDouble(mCount / inv))) + 1;

                for (int i = 0; i < k; i++)
                {
                    SheetName = "当前是SHEET" + i.ToString();
                    AppLibrary.WriteExcel.Worksheet sheet = doc.Workbook.Worksheets.Add(SheetName);
                    AppLibrary.WriteExcel.Cells cells = sheet.Cells;
                    //第一行表头
                    cells.Add(1, 1, "序号");                    
                    int f = 1;
                    for (int m = i * inv; m < mCount && m < (i + 1) * inv; m++)
                    {
                        f++;
                        cells.Add(f, 1,"测试");                       
                    }
                }
                doc.Save(ofd.SelectedPath,true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                AppLibrary.ReadExcel.Workbook wb= AppLibrary.ReadExcel.Workbook.getWorkbook(ofd.FileName);
                AppLibrary.ReadExcel.Sheet[] ss = wb.Sheets;
            }
        }
    }
}
