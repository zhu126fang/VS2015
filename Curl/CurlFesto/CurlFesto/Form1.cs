using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SeasideResearch.LibCurlNet;
namespace CurlFesto
{
        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);

                Easy easy = new Easy();
                Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);

                /////获取实时数据
                easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/config");

                //调用函数获取数据
                easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
                easy.Perform();
                easy.Cleanup();

                Curl.GlobalCleanup();
            }
            catch
            {
                MessageBox.Show("获取失败！");
            }

            string[] sArray = Global.msgtemp.Split(';');

            listBox1.Items.Clear();
            foreach (string i in sArray)
            {
                if (i != "") listBox1.Items.Add(i);
            }
    }

        public static Int32 OnWriteData(Byte[] buf, Int32 size, Int32 nmemb, Object extraData)
        {
            Global.msgtemp = (System.Text.Encoding.UTF8.GetString(buf));
            return size * nmemb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);

                Easy easy = new Easy();
                Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);

                //设定主机箱压力为500Kpa
                easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/write.php");
                easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, "set=.Main_Pression_Set%3AINT%3D5900%3B&cmd=3");

                //调用函数获取数据
                easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
                easy.Perform();
                easy.Cleanup();

                Curl.GlobalCleanup();
            }
            catch
            {
                MessageBox.Show("错误");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);

                Easy easy = new Easy();
                Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);

                /////关闭数据更新
                //easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/write.php");
                //easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, "cmd=0");

                /////获取实时数据
                //easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/mnt/symbols");

                //设定主机箱压力为500Kpa
                //easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/write.php");
                //easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, "set=.Main_Pression_Set%3AINT%3D5000%3B&cmd=3");

                //设定主机箱压力为0Kpa
                easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/write.php");
                easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, "set=.Main_Pression_Set%3AINT%3D0%3B&cmd=3");

                easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
                easy.Perform();
                easy.Cleanup();

                Curl.GlobalCleanup();

            }
            catch
            {
                MessageBox.Show("错误2");
            }
        }

        public  class Global
        {
            public static string msgtemp;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);

                Easy easy = new Easy();
                Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);

                /////获取实时数据
                easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/mnt/symbols");

                //调用函数获取数据
                easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
                easy.Perform();
                easy.Cleanup();

                Curl.GlobalCleanup();
            }
            catch
            {
                textBox1.Text = "获取失败！";
            }

            textBox1.Text = Global.msgtemp;
            string[] sArray = Global.msgtemp.Split(';');

            listBox2.Items.Clear();
            foreach (string i in sArray)
            {
                if (i !="")     listBox2.Items.Add(i);
            }
}

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);

                Easy easy = new Easy();
                Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);

                /////开启数据更新
                easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/write.php");
                easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, "cmd=1");

                //调用函数获取数据
                easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
                easy.Perform();
                easy.Cleanup();

                Curl.GlobalCleanup();
            }
            catch
            {
                MessageBox.Show("打开失败！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);

                Easy easy = new Easy();
                Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);

                /////关闭数据更新
                easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/write.php");
                easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, "cmd=0");

                //调用函数获取数据
                easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
                easy.Perform();
                easy.Cleanup();

                Curl.GlobalCleanup();
            }
            catch
            {
                MessageBox.Show("关闭失败！");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);

                Easy easy = new Easy();
                Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);

                /////获取实时数据
                easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/config");

                //调用函数获取数据
                easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
                easy.Perform();
                easy.Cleanup();

                Curl.GlobalCleanup();
            }
            catch
            {
                textBox1.Text = "获取失败！";
            }
            timer1.Enabled = false;
            textBox1.Text = Global.msgtemp;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);

                Easy easy = new Easy();
                Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);

                //设定主机箱压力为500Kpa
                easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/write.php");
                easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, "set=.Gas_Pression_Set%3AINT%3D5900%3B&cmd=3");

                //调用函数获取数据
                easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
                easy.Perform();
                easy.Cleanup();

                Curl.GlobalCleanup();
            }
            catch
            {
                MessageBox.Show("错误");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);

                Easy easy = new Easy();
                Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);

                /////关闭数据更新
                //easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/write.php");
                //easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, "cmd=0");

                /////获取实时数据
                //easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/mnt/symbols");

                //设定主机箱压力为500Kpa
                //easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/write.php");
                //easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, "set=.Main_Pression_Set%3AINT%3D5000%3B&cmd=3");

                //设定主机箱压力为0Kpa
                easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/write.php");
                easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, "set=.Gas_Pression_Set%3AINT%3D0%3B&cmd=3");

                easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
                easy.Perform();
                easy.Cleanup();

                Curl.GlobalCleanup();

            }
            catch
            {
                MessageBox.Show("错误2");
            }
        }
    }
}
