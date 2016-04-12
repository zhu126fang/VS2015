///读取CodesyHMI中的DDE数据。
///读取数据的更新周期，根据定时器控制。

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NDde.Client;

namespace Ndde_Codesys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class value
        {
            public static string[] r_Value=new string[12];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //不检查跨线程的调用是否合法
            //不是很合适的处理方法
            CheckForIllegalCrossThreadCalls = false;

            string s_name;
            string s_topic;            

            s_name = "CoDeSysHMI";
            s_topic = @"C:\Windows\Logs\bin\HX2B\HX2B.pro";

            //每一個item都需要建立一個DDE連結
            DdeClient[] ddecon = new DdeClient[12];

            for (int i = 1; i < 12; i++)
            {
                ddecon[i] = new DdeClient(s_name, s_topic);
            }

            for (int i = 1; i < 12; i++)
            {
                try
                {
                    ddecon[i].Connect();
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }

            //连接并关注Item
            for (int i = 1; i < 12; i++)
            {
                ddecon[i].StartAdvise("Rec_Value["  + i.ToString() + "]", 1, true, 60000);
                ddecon[i].Advise += client_Advise;
            }      
        }
        private void client_Advise(object sender, DdeAdviseEventArgs args)
        {
            //显示更新数据
            if         (args.Item == "Rec_Value[1]") value.r_Value[1] = args.Text;
            else if (args.Item == "Rec_Value[2]") value.r_Value[2] = args.Text;
            else if (args.Item == "Rec_Value[3]") value.r_Value[3] = args.Text;
            else if (args.Item == "Rec_Value[4]") value.r_Value[4] = args.Text;
            else if (args.Item == "Rec_Value[5]") value.r_Value[5] = args.Text;
            else if (args.Item == "Rec_Value[6]") value.r_Value[6] = args.Text;
            else if (args.Item == "Rec_Value[7]") value.r_Value[7] = args.Text;
            else if (args.Item == "Rec_Value[8]") value.r_Value[8] = args.Text;
            else if (args.Item == "Rec_Value[9]") value.r_Value[9] = args.Text;
            else if (args.Item == "Rec_Value[10]") value.r_Value[10] = args.Text;
            else if (args.Item == "Rec_Value[11]") value.r_Value[11] = args.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = value.r_Value[1];
            textBox2.Text = value.r_Value[2];
            textBox3.Text = value.r_Value[3];
            textBox4.Text = value.r_Value[4];
            textBox5.Text = value.r_Value[5];
            textBox6.Text = value.r_Value[6];
            textBox7.Text = value.r_Value[7];
            textBox8.Text = value.r_Value[8];
            textBox9.Text = value.r_Value[9];
            textBox10.Text = value.r_Value[10];
            textBox11.Text = value.r_Value[11];
        }
    }
}