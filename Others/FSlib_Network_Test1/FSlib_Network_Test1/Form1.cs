using FSLib.Network.Http;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSlib_Network_Test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("正在请求 https://www.5ichai.com/ ...\n");
            var client = new HttpClient();
            var context = client.Create<string>(HttpMethod.Get, "https://www.baidu.com/");
            await context.SendTask();
            if (context.IsValid())
            {
                textBox1.AppendText(context.Result);
            }
            else
            {
                textBox1.AppendText("错误！状态码：" + context.Response.Status);
                textBox1.AppendText("服务器响应：" + context.ResponseContent);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("正在请求 http://www.baidu.com/img/bdlogo.png ...");

            var client = new HttpClient();
            var context = client.Create<Image>(HttpMethod.Get, "https://www.baidu.com/img/bd_logo1.png");
            await context.SendTask();

            if (context.IsValid())
            {
                textBox1.AppendText("正在显示图片...");

                var form = new Form() { Size = context.Result.Size };
                var pic = new PictureBox();
                form.Controls.Add(pic);
                pic.Dock = DockStyle.Fill;
                pic.Image = context.Result;
                form.Show();
                form.Activate();
            }
            else
            {
                textBox1.AppendText("错误！状态码：" + context.Response.Status);
                textBox1.AppendText("服务器响应：" + context.ResponseContent);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var ctx = client.Create<ResponseFileContent>(HttpMethod.Get,
                                "http://dldir1.qq.com/qqfile/qq/QQ7.9/16638/QQ7.9.exe",
                                saveToFile: @"D:\QQ.exe"
                );

            //setup a timer to display
            var timer = new System.Timers.Timer(1000);
            //timer.Elapsed += (s, e) =>
            {
                var perf = ctx.Performance;
                if (perf == null)
                    return;
                //textBox1.AppendText.WriteLine(
                        //"{0}> 已下载大小：{1}, 总大小：{2}, 已用下载时间 {3}, 当前下载速度 {4}, 平均下载速度 {5}, 预计剩余时间 {6}",
                        //DateTime.Now.ToString("HH:mm:ss"),
                        //perf.ResponseLengthProcessed.ToSizeDescription(),
                        //perf.ResponseLength.ToSizeDescription(),
                        //perf.ElapsedTime?.ToFriendlyDisplay(),
                        //perf.InstantDownloadSpeed?.ToSizeDescription(),
                        //perf.AverageDownloadSpeed?.ToSizeDescription(),
                        //perf.DownloadResetTime?.ToFriendlyDisplay());
            };

            //textBox1.AppendText.WriteLine("开始下载....");

            timer.Start();
            //ctx.WithSpeedMeter().Send();
            timer.Stop();

            //textBox1.AppendText.WriteLine("下载完成，状态=" + ctx.IsValid() + "，耗时=" + ctx.Performance.ElapsedTime?.ToFriendlyDisplay());
        }
    }
}
