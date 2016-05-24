using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace Screenshot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Visible = false;
            int picwidth = 1366;
            int picheight = 768;
            //picwidth = Screen.PrimaryScreen.Bounds.Width;
            //picheight = Screen.PrimaryScreen.Bounds.Height;

            //日期和目录
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string strYMD = currentTime.ToString("yyyyMMdd");
            string strHMS = currentTime.ToString("HHmmss");
            string path1 = @"D:\Report";
            string path2 = @"D:\Report\" + strYMD;
            if (!Directory.Exists(path1)) Directory.CreateDirectory(path1);
            if (!Directory.Exists(path2)) Directory.CreateDirectory(path2);
            string filename = @"D:\Report\" + strYMD + @"\" + strYMD + "_" + strHMS + ".jpg";

            //Thread.Sleep(10000);

            //创建图象，保存将来截取的图象
            Bitmap image = new Bitmap(picwidth, picheight);
            Graphics imgGraphics = Graphics.FromImage(image);
            //设置截屏区域 可定义
            imgGraphics.CopyFromScreen(0, 0, 0, 0, new Size(picwidth, picheight));

            //保存图片
            //MessageBox.Show (filename);
            image.Save(filename);
            System.Environment.Exit(0);
        }
    }
}