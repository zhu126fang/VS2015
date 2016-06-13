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
        public Form1()
        {
            InitializeComponent();

            listView1.Clear();
            listView1.View = View.Details;               //显示数据的方式
            
            listView1.Columns.Add("序号");
            listView1.Columns.Add("文件名");
            //添加列标签
            ColumnHeader ch = new ColumnHeader();
            ch.Text = "文件大小";   //设置列标题  
            ch.Width = 120;    //设置列宽度  
            ch.TextAlign = HorizontalAlignment.Right;   //设置列的对齐方式  
            listView1.Columns.Add(ch);    //将列头添加到ListView控件。 
            listView1.Columns.Add("");

            listView1.Columns[0].Width = 40;
            listView1.Columns[1].Width = 150;
            listView1.Columns[2].Width = 120;
            listView1.Columns[3].Width = 100;

            Scripting.FileSystemObject fso = new Scripting.FileSystemObjectClass();
            //MessageBox.Show(fso.GetFolder("D://Program Files").Size.ToString());
            //this.listBox1.Items.Add(fso.GetFolder(@"D:\Program Files").Size.ToString());

            // 遍历出当前目录的所有文件夹.
            DirectoryInfo d = new DirectoryInfo(@"..");   //绑定到当前的应用程序目录
            DirectoryInfo[] dis = d.GetDirectories();

            int j = 0;            
            foreach (DirectoryInfo di in dis)
            {
                if (di.Attributes.ToString().IndexOf("Hidden")< 0)
                {
                    j++;
                    ListViewItem cj;                

                    cj = new ListViewItem(j.ToString());
                    cj.SubItems.Add(di.Name);
                    double d11 = Convert.ToDouble(fso.GetFolder(di.FullName).Size.ToString());
                    cj.SubItems.Add(d11.ToString("N"));
                    listView1.Items.Add(cj);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
