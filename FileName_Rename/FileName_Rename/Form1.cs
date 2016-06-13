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

namespace FileName_Rename
{
    public partial class Form1 : Form
    {
        String FilePath;
        String[] files;
        string Rename= "arm-none-linux-gnueabi-";

        public Form1()
        {
            InitializeComponent();            

            this.listBoxLog.Items.Clear();

            //FilePath = @"D:\ArmToolchain\bin1";                      // 指定路径
            FilePath = Environment.CurrentDirectory;                  //当前路径
            textBox1.Text = FilePath;                     
       }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            //手动选择目录
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();                       //手动选择
            folderDlg.ShowDialog();
            FilePath = folderDlg.SelectedPath.ToString();
            textBox1.Text = FilePath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (String filename in files)
            {
                int lastpath = filename.LastIndexOf("\\");                                                 // 最后一个"\"               
                int lastdot = filename.LastIndexOf(".");                                                      // 最后一个"."                
                int length = lastdot - lastpath - 1;                                                                 //  纯文件名字长度                
                String beginpart = filename.Substring(0, lastpath + 1);                         //  文件目录字符串 xx\xx\xx\                
                String namenoext = filename.Substring(lastpath + 1, length);            //   纯文件名字                
                String ext = filename.Substring(lastdot);                                                   //   扩展名

                String namenew;
                Rename = textBox2.Text;
                namenew = namenoext.Replace(Rename, "");

                String fullnewname = beginpart + namenew + ext;
                // 改名
                if (File.Exists(fullnewname))
                {
                    //存在
                    this.listBoxLog.Items.Add(namenoext + "--->" + "已存在文件");
                }
                else
                {
                    //不存在
                    this.listBoxLog.Items.Add(namenoext + "--->" + namenew);
                    File.Move(filename, fullnewname);
                }
                // log
                this.listBoxLog.SelectedIndex = this.listBoxLog.Items.Count - 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //显示所有文件
            files = Directory.GetFiles(FilePath);                  //路径下所有文件
            foreach (String filename in files)
            {
                this.listBoxLog.Items.Add("文件名:" + filename);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //清除
            this.listBoxLog.Items.Clear();
        }
    }
}
