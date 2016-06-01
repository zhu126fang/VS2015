using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FSLib.Network.Http;
using FSLib.Network;       //需要引用net45的dll文件

namespace FSlib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGrabBdPage_Click(object sender, EventArgs e)
        {
            InitWorkingUI();
            AppendText("正在请求 https://www.baidu.com/ ...");

            var client = new HttpClient();
            var context = client.Create<string>(HttpMethod.Get, "https://www.baidu.com/");     ///需要修改为https
            await context.SendTask();

            if (context.IsValid())
            {
                AppendText(context.Result);
            }
            else
            {
                AppendText("错误！状态码：" + context.Response.Status);
                AppendText("服务器响应：" + context.ResponseContent);
            }
            WorkingFinished();
        }

        #region 辅助函数
        void InitWorkingUI()
        {
            txtResult.Clear();
            //pgWaiting.Visible = true;
        }

        void AppendText(string txt)
        {
            txtResult.AppendText(txt);
            txtResult.AppendText(Environment.NewLine);
            txtResult.AppendText(Environment.NewLine);
            txtResult.ScrollToCaret();
        }

        void WorkingFinished()
        {
            //pgWaiting.Visible = false;
        }
        #endregion

        private async void btnGrabBdLogo_Click(object sender, EventArgs e)
        {
            InitWorkingUI();


            AppendText("正在请求 http://www.baidu.com/img/bdlogo.png ...");

            var client = new HttpClient();
            var context = client.Create<Image>(HttpMethod.Get, "http://www.baidu.com/img/bdlogo.png");
            await context.SendTask();

            if (context.IsValid())
            {
                AppendText("正在显示图片...");

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
                AppendText("错误！状态码：" + context.Response.Status);
                AppendText("服务器响应：" + context.ResponseContent);
            }
            WorkingFinished();
        }
    }
}
