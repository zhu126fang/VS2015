using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetDirSize
{
    public partial class Form1 : Form
    {
        public static int ErrTemp;
        public static int FileTemp;
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            listView1.View = View.Details;               //显示数据的方式

            listView1.Columns.Add("序号");
            listView1.Columns.Add("文件夹名");
            listView1.Columns.Add("文件夹大小");
            listView1.Columns.Add("访问出错统计");

            listView1.Columns[0].Width = 40;
            listView1.Columns[0].TextAlign = HorizontalAlignment.Center;   //设置列的对齐方式  
            listView1.Columns[1].Width = 150;
            listView1.Columns[2].Width = 120;
            listView1.Columns[2].TextAlign = HorizontalAlignment.Right;   //设置列的对齐方式 
            listView1.Columns[3].Width = 100;
            listView1.Columns[3].TextAlign = HorizontalAlignment.Center;   //设置列的对齐方式  
        }
        public static long GetFilesSize(String path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            long length = 0;
            try
            {
                foreach (FileSystemInfo fsi in directoryInfo.GetFileSystemInfos())
                {
                    if (fsi is FileInfo)
                    {
                        length += ((FileInfo)fsi).Length;
                        FileTemp++;
                    }
                    else
                    {
                        length += GetFilesSize(fsi.FullName);       //递归调用，遍历子目录
                    }
                }
            }
            catch
            {
                ErrTemp++;
            }
            return length;
        }
        public void InitList()
        {
            Scripting.FileSystemObject fso = new Scripting.FileSystemObjectClass();

            // 遍历出当前目录的所有文件夹.
            DirectoryInfo d = new DirectoryInfo(@"C:\");   //绑定到当前的应用程序目录
            DirectoryInfo[] dis = d.GetDirectories();

            int j = 0;
            foreach (DirectoryInfo di in dis)
            {
                if (di.Attributes.ToString().IndexOf("Hidden") < 0)
                {
                    j++;
                    ListViewItem cj;
                    cj = new ListViewItem(j.ToString());
                    cj.SubItems.Add(di.Name);
                    string dName = di.FullName;
                    //MessageBox.Show(dName);

                    ///调用系统函数的方式
                    //object d1 = fso.GetFolder(dName).Size;
                    //String d11 =d1.ToString();
                    //double d111 = Convert.ToDouble(d11);

                    ///调用自定义函数的方式
                    ErrTemp = 0;
                    long d111 = GetFilesSize(dName);

                    cj.SubItems.Add(d111.ToString("N"));
                    cj.SubItems.Add(ErrTemp.ToString());
                    listView1.Items.Add(cj);
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            FileTemp = 0;
            //listView1.Clear();
            ListViewItem cj1;
            cj1 = new ListViewItem("0");
            cj1.SubItems.Add("");
            listView1.Items.Add(cj1);

            InitList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = FileTemp.ToString();
            //MessageBox.Show(textBox1.Text);
        }
    }
}
