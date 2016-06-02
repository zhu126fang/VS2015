using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string[,] chengji = new string[4, 5];

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            listView1.View = View.Details;               //显示数据的方式

            //添加列标签
            listView1.Columns.Add("姓名");
            listView1.Columns.Add("语文");
            listView1.Columns.Add("数学");
            listView1.Columns.Add("科学");
            listView1.Columns.Add("英语");

            //初始化数组            
            chengji[0, 0] = "小王";
            chengji[0, 1] = "90";
            chengji[0, 2] = "98";
            chengji[0, 3] = "88";
            chengji[0, 4] = "92";
            chengji[1, 0] = "小李";
            chengji[1, 1] = "92";
            chengji[1, 2] = "94";
            chengji[1, 3] = "98";
            chengji[1, 4] = "93";
            chengji[2, 0] = "小黄";
            chengji[2, 1] = "91";
            chengji[2, 2] = "92";
            chengji[2, 3] = "93";
            chengji[2, 4] = "94";
            chengji[3, 0] = "小张";
            chengji[3, 1] = "95";
            chengji[3, 2] = "94";
            chengji[3, 3] = "93";
            chengji[3, 4] = "92";
        }

        private void button2_Click(object sender, EventArgs e)
        {          
            for (int i = 0; i < chengji.GetLength(0); i++)
            {
                string[] newchengji = { chengji[i, 0], chengji[i, 1], chengji[i, 2], chengji[i, 3], chengji[i, 3], chengji[i, 3] };
                //ListViewItem bb = new ListViewItem(new string[] { chengji[i, 0], chengji[i, 1], chengji[i, 2], chengji[i, 3], chengji[i, 4] });
                ListViewItem bb = new ListViewItem(newchengji);
                listView1.Items.Add(bb);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListViewItem cj;
            for (int i = 0; i < chengji.GetLength(0); i++)
            {
                cj = new ListViewItem(chengji[i, 0]);
                cj.SubItems.Add(chengji[i, 1]);
                cj.SubItems.Add(chengji[i, 2]);
                cj.SubItems.Add(chengji[i, 3]);
                cj.SubItems.Add(chengji[i, 4]);

                listView1.Items.Add(cj);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListViewItem cjj;
            string[] sstr = new string[chengji.GetLength(1)];
            for (int i = 0; i < chengji.GetLength(0); i++)
            {
                for (int j = 0; j < chengji.GetLength(1); j++)
                {
                    sstr[j] = chengji[i, j];
                }
                cjj = new ListViewItem(sstr);

                listView1.Items.Add(cjj);
            }
        }
    }
}
