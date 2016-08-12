using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartProgressbar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
            }
            else
            {
                System.Environment.Exit(0);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1366;
            this.Height = 768;
            progressBar1.Width = 1300;
            this.progressBar1.Location = new System.Drawing.Point(33, 700);
            label1.Width = 1300;
            this.label1.Location = new System.Drawing.Point(33, 670);

            Start();
        }
        static public void  Start()
        {
            string str1;
            String HZL1, HZL1sim;
            str1 = @"C:\Program Files\3S Software\CoDeSys V2.3\CoDeSysHMI\CoDeSysHMI.exe";
            HZL1 = @"D:\Francis\AEF\HZL1\HZL1\HZL1.pro  /target  /visudownload";
            HZL1sim = @"D:\Francis\AEF\HZL1\HZL1\HZL1.pro  /simulation /visudownload";

            //Process.Start(str1, HZL1);                         //打开程序
            Process.Start(str1, HZL1sim);                  //打开模拟程序
            DssDisplay.ClsWin32.HideTask(true);    //隐藏任务栏
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

namespace DssDisplay
{
    class ClsWin32
    {
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        public static Point GetCursorPos()
        {
            Point point = new Point();
            GetCursorPos(ref point);
            return point;
        }

        public static void HideTask(bool isHide)
        {
            try
            {
                IntPtr trayHwnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Shell_TrayWnd", null);
                IntPtr hStar = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Button", null);

                if (isHide)
                {
                    ShowWindow(trayHwnd, 0);
                    ShowWindow(hStar, 0);
                }
                else
                {
                    ShowWindow(trayHwnd, 1);
                    ShowWindow(hStar, 1);
                }
            }
            catch { }
        }
    }
}
