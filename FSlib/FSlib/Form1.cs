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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// JSON参考文献
/// http://www.newtonsoft.com/json
/// 获取电报码
/// https://kyfw.12306.cn/otn/resources/js/framework/station_name.js
/// 获取JSON数据
/// https://kyfw.12306.cn/otn/lcxxcx/query?purpose_codes=ADULT&queryDate=2016-06-03&from_station=BJP&to_station=AOH
/// </summary>

namespace FSlib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            init();
        }

        /// <summary>
        /// 1. 抓取网页的JSON数据
        /// 2. 将抓取的数据转化为数组
        /// 3. ListView读取JArray数组
        /// </summary>
        private void btnGrabBdPage_Click(object sender, EventArgs e)
        {
            clear();
            seturl();
            showlist();
        }

        /// <summary>
        ///清理表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        /// <summary>
        /// 获取一张图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// 表格初始化
        /// </summary>
        void init()
        {
            listView1.View = View.Details;               //显示数据的方式

            //添加列标签
            listView1.Columns.Add("No");
            for(int i=1;i<15;++i)
            {
                listView1.Columns.Add(i.ToString());
            }
            listView1.Columns[0].Width = 30;

            ////起点和终点查询
            comboBox1.Items.Add("AOH|上海");
            comboBox1.Items.Add("VXN|红安西");
            comboBox1.Items.Add("WHN|武汉");
            comboBox1.Items.Add("BJP|北京");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add("VXN|红安西");
            comboBox2.Items.Add("WHN|武汉");
            comboBox2.Items.Add("BJP|北京");
            comboBox2.Items.Add("AOH|上海");
            comboBox2.SelectedIndex = 0;

            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now.AddDays(59);            
        }

        /// <summary>
        /// 表清楚函数
        /// </summary>
        void clear()
        {
            listView1.Items.Clear();
        }

        /// <summary>
        /// 获取请求地址函数
        /// </summary>
        public string geturl;
        void seturl()
        {
            /////获取地址变量
            string site;
            string queryDate;
            string fromstation = "AOH", tostation = "VXN";

            /////获取起点和终点
            string aaa = "";
            if (comboBox1.SelectedIndex > -1)
            {
                //aaa = comboBox1.Items[comboBox1.SelectedIndex].ToString();//方法1
                aaa = comboBox1.SelectedItem.ToString();//方法2
                fromstation = aaa.Substring(0, 3);
            }
            if (comboBox2.SelectedIndex > -1)
            {
                aaa = comboBox2.SelectedItem.ToString();
                tostation = aaa.Substring(0, 3);
            }

            ////获取时间
            queryDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            ////MessageBox.Show(queryDate);
            //queryDate = "2016-06-03";

            /////拼接获取地址
            site = "https://kyfw.12306.cn/otn/lcxxcx/query?purpose_codes=ADULT&queryDate=";
            ////起点和终点统一，强制默认值。
            if (fromstation == tostation)
            {
                comboBox1.SelectedIndex = 0;
                fromstation = "VXN";
                tostation = "AOH";
            }
            geturl = site + queryDate + "&from_station=" + fromstation + "&to_station=" + tostation;
        }

        /// <summary>
        /// 请求数据并显示函数
        /// </summary>
        public JArray ja;
        async void  showlist()
        {
            ////初始化文本框，调试用
            ////InitWorkingUI();
            AppendText("请求地址 " + geturl);

            ////1. 抓取网页的JSON数据
            var client = new HttpClient();
            var context = client.Create<string>(HttpMethod.Get, geturl);     ///需要修改为https
            await context.SendTask();

            ////2. 处理获取的数据
            if (context.IsValid())
            {
                ////调试显示用
                ////AppendText(context.Result);
                ////MessageBox.Show(context.Result);

                ///2.1 JObject读取字符串
                JObject jsonObj = null;
                jsonObj = JObject.Parse(context.Result);

                try
                {
                    string temp = jsonObj["data"]["datas"].ToString();

                    ////2.2 JArray 数组化数据
                    ////两种方式效果好像一样
                    ////ja = JArray.Parse(jsonObj["data"]["datas"].ToString());  
                    ja = (JArray)JsonConvert.DeserializeObject(temp);
                    //MessageBox.Show(jlist.ToString());      
                    //MessageBox.Show(ja.Count.ToString());

                    ////3. ListView读取JArray数组
                    ListViewItem cj;
                    for (int i = 0; i < ja.Count; i++)
                    {
                        cj = new ListViewItem((i + 1).ToString());
                        //cj.SubItems.Add(ja[i]["train_no"].ToString());
                        cj.SubItems.Add(ja[i]["station_train_code"].ToString());
                        //cj.SubItems.Add(ja[i]["start_station_telecode"].ToString());
                        cj.SubItems.Add(ja[i]["start_station_name"].ToString());
                        //cj.SubItems.Add(ja[i]["end_station_telecode"].ToString());
                        cj.SubItems.Add(ja[i]["end_station_name"].ToString());
                        //cj.SubItems.Add(ja[i]["from_station_telecode"].ToString());
                        cj.SubItems.Add(ja[i]["from_station_name"].ToString());
                        //cj.SubItems.Add(ja[i]["to_station_telecode"].ToString());
                        //cj.SubItems.Add(ja[i]["to_station_name"].ToString());
                        cj.SubItems.Add(ja[i]["start_time"].ToString());
                        cj.SubItems.Add(ja[i]["arrive_time"].ToString());
                        //cj.SubItems.Add(ja[i]["day_difference"].ToString());
                        //cj.SubItems.Add(ja[i]["train_class_name"].ToString());
                        cj.SubItems.Add(ja[i]["lishi"].ToString());
                        //cj.SubItems.Add(ja[i]["canWebBuy"].ToString());
                        //cj.SubItems.Add(ja[i]["lishiValue"].ToString());
                        //cj.SubItems.Add(ja[i]["yp_info"].ToString());
                        //cj.SubItems.Add(ja[i]["control_train_day"].ToString());
                        cj.SubItems.Add(ja[i]["start_train_date"].ToString());
                        //cj.SubItems.Add(ja[i]["seat_feature"].ToString());
                        //cj.SubItems.Add(ja[i]["yp_ex"].ToString());
                        //cj.SubItems.Add(ja[i]["train_seat_feature"].ToString());
                        //cj.SubItems.Add(ja[i]["seat_types"].ToString());
                        //cj.SubItems.Add(ja[i]["location_code"].ToString());
                        //cj.SubItems.Add(ja[i]["from_station_no"].ToString());
                        //cj.SubItems.Add(ja[i]["to_station_no"].ToString());
                        //cj.SubItems.Add(ja[i]["control_day"].ToString());
                        //cj.SubItems.Add(ja[i]["sale_time"].ToString());
                        //cj.SubItems.Add(ja[i]["is_support_card"].ToString());
                        //cj.SubItems.Add(ja[i]["note"].ToString());
                        //cj.SubItems.Add(ja[i]["controlled_train_flag"].ToString());
                        //cj.SubItems.Add(ja[i]["controlled_train_message"].ToString());
                        //cj.SubItems.Add(ja[i]["gg_num"].ToString());
                        //cj.SubItems.Add(ja[i]["gr_num"].ToString());
                        //cj.SubItems.Add(ja[i]["qt_num"].ToString());
                        //cj.SubItems.Add(ja[i]["rw_num"].ToString());
                        //cj.SubItems.Add(ja[i]["rz_num"].ToString());
                        //cj.SubItems.Add(ja[i]["tz_num"].ToString());
                        //cj.SubItems.Add(ja[i]["wz_num"].ToString());
                        //cj.SubItems.Add(ja[i]["yb_num"].ToString());
                        //cj.SubItems.Add(ja[i]["yw_num"].ToString());
                        //cj.SubItems.Add(ja[i]["yz_num"].ToString());
                        cj.SubItems.Add(ja[i]["ze_num"].ToString());                ///二等座
                        cj.SubItems.Add(ja[i]["zy_num"].ToString());                ///一等座
                        //cj.SubItems.Add(ja[i]["swz_num"].ToString());         ///商务座
                        listView1.Items.Add(cj);
                    }
                }
                catch
                {
                    AppendText("数据格式错误");
                }                
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

        /// <summary>
        /// 辅助函数
        /// </summary>
        /// <param name="txt"></param>
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            clear();
            seturl();       /////
            showlist();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (button2.Text == "开始循环")
            {
                button2.Text = "停止循环";
                timer1.Enabled = true;
            }
            else
            {
                button2.Text = "开始循环";
                timer1.Enabled = false;
            }
        }
    }
}
