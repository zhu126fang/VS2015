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
using System.Diagnostics;

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

            dde ddecon = new dde();
            ddecon.ddeadvise();

            label20.Text = timer1.Interval.ToString() + "ms";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //窗口置顶
            this.TopMost = false;
            this.BringToFront();
            this.TopMost = true;

            //链接的内容 更新到文本框显示
            dateshow ds = new dateshow();
            ds.testboxshow();

            ///检测链接是否断开
            ///不是很好的方法
            checkcon cc = new checkcon();
            cc.timecheck();

            ///到达最后一步后，数据保存至文本
            filesave fs = new filesave();
            fs.datesave();
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
            StreamWriter sw = new StreamWriter("D:\\1.log");
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

            sw.Write("T" + dde.r_Value[23] + "\t");
            for (int i = 1; i < 12; i++)
            {
                sw.Write("S" + i + ":" + dde.r_Value[i] + "\r\t");
            }
            sw.Write("\n");
            sw.Close();
            System.Diagnostics.Process.Start("D:\\1.txt");
        }

        private void open_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("D:\\1.log");
        }

        private void Active_Click(object sender, EventArgs e)
        {
            dde ddecon = new dde();
            ddecon.ddeadvise();
        }

        public class dde        ////全局变量和 DDE的初始化及链接
        {
            public static string[] r_Value = new string[29];
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
                ddecon[23].StartAdvise("Rec_PageNow", 1, true, 60000);
                ddecon[23].Advise += client_Advise;

                ddecon[24].StartAdvise("Rec_Step", 1, true, 60000);
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

                else if (args.Item == "Rec_PageNow") r_Value[23] = args.Text;
                else if (args.Item == "Rec_Step") r_Value[24] = args.Text;
                else if (args.Item == "Rec_PageTime") r_Value[25] = args.Text;
                else if (args.Item == "model") r_Value[26] = args.Text;
                else if (args.Item == "number") r_Value[27] = args.Text;
                else if (args.Item == "Rec_PageSave") r_Value[28] = args.Text;
            }
        }
        
        public class global 
        {
            public static float link_Time = 0;
            public static int count = 0;
        }

        public class dateshow    ////数据显示到文本框
        {
            Form1 frm = System.Windows.Forms.Application.OpenForms[0] as Form1;
            public void testboxshow()
            {
                frm.textBox1.Text = dde.r_Value[1];
                frm.textBox2.Text = dde.r_Value[2];
                frm.textBox3.Text = dde.r_Value[3];
                frm.textBox4.Text = dde.r_Value[4];
                frm.textBox5.Text = dde.r_Value[5];
                frm.textBox6.Text = dde.r_Value[6];
                frm.textBox7.Text = dde.r_Value[7];
                frm.textBox8.Text = dde.r_Value[8];
                frm.textBox9.Text = dde.r_Value[9];
                frm.textBox10.Text = dde.r_Value[10];
                frm.textBox11.Text = dde.r_Value[11];

                frm.textBox12.Text = dde.r_Value[12];
                frm.textBox13.Text = dde.r_Value[13];
                frm.textBox14.Text = dde.r_Value[14];
                frm.textBox15.Text = dde.r_Value[15];
                frm.textBox16.Text = dde.r_Value[16];
                frm.textBox17.Text = dde.r_Value[17];
                frm.textBox18.Text = dde.r_Value[18];
                frm.textBox19.Text = dde.r_Value[19];
                frm.textBox20.Text = dde.r_Value[20];
                frm.textBox21.Text = dde.r_Value[21];
                frm.textBox22.Text = dde.r_Value[22];

                frm.textBox23.Text = dde.r_Value[23];
                frm.textBox24.Text = dde.r_Value[24];
                frm.textBox25.Text = dde.r_Value[25];
                frm.textBox26.Text = dde.r_Value[26];
                frm.textBox27.Text = dde.r_Value[27];
                frm.textBox28.Text = dde.r_Value[28];
            }
        }

        public class checkcon    /////检测链接是否断开
        {
            public void timecheck()
            {
                //////可以用全局变量置换出textbox 
                Form1 frm = System.Windows.Forms.Application.OpenForms[0] as Form1;

                if ((float.Parse(dde.r_Value[25]) - global.link_Time) == 0)        ///计时通道断开
                {
                    global.count = global.count + 1;
                    frm.textBox29.Text = global.count.ToString();
                }
                else                                                                                            ///计时通道正常
                {
                    global.count = 0;
                    frm.textBox29.Text = global.count.ToString();
                }
                if (global.count > 3)
                {
                    frm.textBox29.BackColor = System.Drawing.Color.Red;
                    frm.textBox29.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    frm.textBox29.BackColor = System.Drawing.Color.White;
                    frm.textBox29.ForeColor = System.Drawing.Color.Black;
                }

                //页面切换通道断开。
                //计时的数字的数字跨越性变化--解决办法。
                float dec_time = float.Parse(dde.r_Value[25]) - global.link_Time;
                frm.textBox30.Text = dec_time.ToString();
                if (dec_time > 1 || dec_time < 0)
                {
                    frm.textBox30.BackColor = System.Drawing.Color.Red;
                    frm.textBox30.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    frm.textBox30.BackColor = System.Drawing.Color.White;
                    frm.textBox30.ForeColor = System.Drawing.Color.Black;
                }

                global.link_Time = float.Parse(dde.r_Value[25]);
            }
        }

        public class filesave      ////数据保存至文本,循环检查是否满足保存条件
        {
            public static bool savefin=false;
            public static int pageold;

            public void datesave()
            {
                //若切换页面则,则去掉保存标记
                if ((int.Parse(dde.r_Value[23])) != pageold) savefin = false;     ////切换页面后，数据保存标记取消
                if ((int.Parse(dde.r_Value[28])) != 0) savefin = false;    ////按下数据保存按钮。

                if (int.Parse(dde.r_Value[24]) == 12 && savefin==false)
                {

                    Process[] ps = Process.GetProcesses();          //获取计算机上所有进程
                    foreach (Process p in ps)   if (p.ProcessName == "notepad")   p.Kill();

                    //表示追加文本                                    
                    StreamWriter sw = File.AppendText("D:\\1.log");
                    sw.Write("TValue" + dde.r_Value[23] + "\t");
                    for (int i = 1; i < 12; i++)
                    {
                        //if (dde.r_Value[i].Length<3)     sw.Write("S" + i + ":" + dde.r_Value[i] + "\t\t");
                        sw.Write("S" + i + ":" + dde.r_Value[i] + "\t");
                    }
                    sw.Write("\r\n");

                    sw.Write("TError" + dde.r_Value[23] + "\t");
                    for (int i = 12; i < 23; i++)
                    {
                        //(dde.r_Value[i].Length < 3) sw.Write("S" + (i-11) + ":" + dde.r_Value[i] + "\t\t");
                        sw.Write("S" + (i-11) + ":" + dde.r_Value[i] + "\t");
                    }
                    sw.Write("\r\n");
                    sw.Write("TTime" + dde.r_Value[25] + "\r");
                    sw.Write("\r\n");

                    sw.Close();
                    savefin = true;

                    System.Diagnostics.Process.Start("D:\\1.log");
                }
                pageold = int.Parse(dde.r_Value[23]);

                //dde.Rec_PageNow") r_Value[23] ;
                //dde.Rec_Step") r_Value[24] ;
                //dde.Rec_PageTime") r_Value[25] ;
                //dde.model") r_Value[26] ;
                //dde.number") r_Value[27] ;
                //dde.Rec_PageSave") r_Value[28] ;
                //MessageBox.Show("确认是否打开HX2B的测试程序", "DDE 连接错误");
            }
        } 
    }
}