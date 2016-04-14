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
using System.IO;

using NDde.Client;

namespace Ndde_Codesys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //不检查跨线程的调用是否合法
            //不是很合适的处理方法
            CheckForIllegalCrossThreadCalls = false;

            global ddecon = new global();
            ddecon.ddeadvise();

        }
  
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = global.r_Value[1];
            textBox2.Text = global.r_Value[2];
            textBox3.Text = global.r_Value[3];
            textBox4.Text = global.r_Value[4];
            textBox5.Text = global.r_Value[5];
            textBox6.Text = global.r_Value[6];
            textBox7.Text = global.r_Value[7];
            textBox8.Text = global.r_Value[8];
            textBox9.Text = global.r_Value[9];
            textBox10.Text = global.r_Value[10];
            textBox11.Text = global.r_Value[11];

            textBox12.Text = global.r_Value[12];
            textBox13.Text = global.r_Value[13];
            textBox14.Text = global.r_Value[14];
            textBox15.Text = global.r_Value[15];
            textBox16.Text = global.r_Value[16];
            textBox17.Text = global.r_Value[17];
            textBox18.Text = global.r_Value[18];
            textBox19.Text = global.r_Value[19];
            textBox20.Text = global.r_Value[20];
            textBox21.Text = global.r_Value[21];
            textBox22.Text = global.r_Value[22];

            textBox23.Text = global.r_Value[23];
            textBox24.Text = global.r_Value[24];
            textBox25.Text = global.r_Value[25];
            textBox26.Text = global.r_Value[26];
            textBox27.Text = global.r_Value[27];
            textBox28.Text = global.r_Value[28];

            //窗口置顶
            this.TopMost = false;
            this.BringToFront();
            this.TopMost = true;

            //计时通道断开。
            if ((float.Parse(global.r_Value[25])- global.link_Time)==0)        ///计时通道断开
            {
                global.count = global.count + 1;
                textBox29.Text = global.count.ToString();
            }
            else                                                                                            ///计时通道正常
            {
                global.count = 0;
                textBox29.Text = global.count.ToString();
            }
            if (global.count > 3)
            {
                textBox29.BackColor = System.Drawing.Color.Red;
                textBox29.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                textBox29.BackColor = System.Drawing.Color.White;
                textBox29.ForeColor = System.Drawing.Color.Black;
            } 

            //页面切换通道断开。
            //计时的数字的数字跨越性变化--解决办法。
            float dec_time= float.Parse(global.r_Value[25]) - global.link_Time;
            textBox30.Text = dec_time.ToString();
            if (dec_time > 1 || dec_time < 0)
            {
                textBox30.BackColor = System.Drawing.Color.Red;
                textBox30.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                textBox30.BackColor = System.Drawing.Color.White;
                textBox30.ForeColor = System.Drawing.Color.Black;
            }

            global.link_Time = float.Parse(global.r_Value[25]);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            //1.只是关闭当前窗口，若不是主窗体的话，是无法退出程序的，另外若有托管线程（非主线程），也无法干净地退出；
            //this.Close(); 

            //2.强制所有消息中止，退出所有的窗体，但是若有托管线程（非主线程），也无法干净地退出；
            //Application.Exit(); 

            //3.强制中止调用线程上的所有消息，同样面临其它线程无法正确退出的问题；
            //Application.ExitThread(); 

            //4. 这是最彻底的退出方式，不管什么线程都被强制退出，把程序结束的很干净。
            System.Environment.Exit(0);  
        }

        private void clear_Click(object sender, EventArgs e)
        {
            //表示清空 txt
            StreamWriter sw = new StreamWriter("D:\\1.txt");
            string w = "";
            sw.Write(w);
            sw.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            //表示向txt写入文本
            //StreamWriter sw = new StreamWriter("D:\\1.txt");
            //string w = "10";
            //sw.Write(w);
            //sw.Close();

            //表示追加文本
            StreamWriter sw = File.AppendText("D:\\1.txt");
            for(int i=1;i<12;i++)
            {
                sw.Write("S" + i + ":"+ global.r_Value[i] + "\r\n");
            }
            sw.Close();
        }

        private void open_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("D:\\1.txt");
        }

        private void Active_Click(object sender, EventArgs e)
        {
            global ddecon = new global();
            ddecon.ddeadvise();
        }

        public class global
        {
            public static string[] r_Value = new string[29];
            public static float link_Time = 0;
            public static int count = 0;

            public static string s_name = "CoDeSysHMI";
            public static string s_topic = @"C:\Windows\Logs\bin\HX2B\HX2B.pro";
            public static DdeClient[] ddecon = new DdeClient[29];     //每一個item都需要建立一個DDE連結

            public void ddeadvise()
            {
                /////初始化数组
                for (int i = 1; i < 29; i++)
                {
                    r_Value[i] = "0";            //初始化数据     
                    ddecon[i] = new DdeClient(s_name, s_topic);    //初始化Item
                }

                ////连接CodesysHMI
                for (int i = 1; i < 29; i++)
                {
                    try
                    {
                        ddecon[i].Connect();
                    }
                    catch
                    {
                        //MessageBox.Show(ex.ToString());
                        MessageBox.Show("确认是否打开HX2B的测试程序", "DDE 连接错误");
                        //若未连接程序，需要重新连接。
                        i = 1;
                    }
                }

                /////连接并关注Item
                for (int i = 1; i < 12; i++)
                {
                    ddecon[i].StartAdvise("Rec_Value[" + i.ToString() + "]", 1, true, 60000);
                    ddecon[i].Advise += client_Advise;
                }
                for (int i = 12; i < 23; i++)
                {
                    int j;
                    j = i - 11;
                    ddecon[i].StartAdvise("Rec_Err[" + j.ToString() + "]", 1, true, 60000);
                    ddecon[i].Advise += client_Advise;
                }
                ddecon[23].StartAdvise("Rec_Step", 1, true, 60000);
                ddecon[23].Advise += client_Advise;

                ddecon[24].StartAdvise("Rec_PageNow", 1, true, 60000);
                ddecon[24].Advise += client_Advise;

                ddecon[25].StartAdvise("Rec_PageTime", 1, true, 60000);
                ddecon[25].Advise += client_Advise;

                ddecon[26].StartAdvise("model", 1, true, 60000);
                ddecon[26].Advise += client_Advise;

                ddecon[27].StartAdvise("number", 1, true, 60000);
                ddecon[27].Advise += client_Advise;

                ddecon[28].StartAdvise("Rec_PageSave", 1, true, 60000);
                ddecon[28].Advise += client_Advise;
            }

            public void client_Advise(object sender, DdeAdviseEventArgs args)
            {
                //显示更新数据
                if (args.Item == "Rec_Value[1]") r_Value[1] = args.Text;
                else if (args.Item == "Rec_Value[2]") r_Value[2] = args.Text;
                else if (args.Item == "Rec_Value[3]") r_Value[3] = args.Text;
                else if (args.Item == "Rec_Value[4]") r_Value[4] = args.Text;
                else if (args.Item == "Rec_Value[5]") r_Value[5] = args.Text;
                else if (args.Item == "Rec_Value[6]") r_Value[6] = args.Text;
                else if (args.Item == "Rec_Value[7]") r_Value[7] = args.Text;
                else if (args.Item == "Rec_Value[8]") r_Value[8] = args.Text;
                else if (args.Item == "Rec_Value[9]") r_Value[9] = args.Text;
                else if (args.Item == "Rec_Value[10]") r_Value[10] = args.Text;
                else if (args.Item == "Rec_Value[11]") r_Value[11] = args.Text;

                else if (args.Item == "Rec_Err[1]") r_Value[12] = args.Text;
                else if (args.Item == "Rec_Err[2]") r_Value[13] = args.Text;
                else if (args.Item == "Rec_Err[3]") r_Value[14] = args.Text;
                else if (args.Item == "Rec_Err[4]") r_Value[15] = args.Text;
                else if (args.Item == "Rec_Err[5]") r_Value[16] = args.Text;
                else if (args.Item == "Rec_Err[6]") r_Value[17] = args.Text;
                else if (args.Item == "Rec_Err[7]") r_Value[18] = args.Text;
                else if (args.Item == "Rec_Err[8]") r_Value[19] = args.Text;
                else if (args.Item == "Rec_Err[9]") r_Value[20] = args.Text;
                else if (args.Item == "Rec_Err[10]") r_Value[21] = args.Text;
                else if (args.Item == "Rec_Err[11]") r_Value[22] = args.Text;

                else if (args.Item == "Rec_Step") r_Value[23] = args.Text;
                else if (args.Item == "Rec_PageNow") r_Value[24] = args.Text;
                else if (args.Item == "Rec_PageTime") r_Value[25] = args.Text;
                else if (args.Item == "model") r_Value[26] = args.Text;
                else if (args.Item == "number") r_Value[27] = args.Text;
                else if (args.Item == "Rec_PageSave") r_Value[28] = args.Text;
            }
        }
    }
}