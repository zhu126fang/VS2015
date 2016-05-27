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

namespace Ndde_MT4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //displayTextBox.Text = "hello";
            try
            {
                //申明并实例化一个DdeClient对象   
                DdeClient  client = new DdeClient("MT4", "BID", this);
                client.Advise += client_Advise;
                //连接到DDE服务器   
                client.Connect();
                //循环获取数据   
                client.StartAdvise("USDCHF", 1, true, 60000);
            }
            catch (Exception ex)
            {
                displayTextBox.Text = "MainForm_Load: " + ex.Message;
            }
        }
        private void client_Advise(object sender, DdeAdviseEventArgs args)
        {
            //显示更新数据   
            displayTextBox.Text = "OnAdvise: " + args.Text;
        }
    }
}
