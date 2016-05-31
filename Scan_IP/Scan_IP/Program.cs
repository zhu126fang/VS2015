using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scan_IP
{
    class Program
    {
        static public List<System.String> ipList = new List<System.String>();

        static void Main(string[] args)
        {
            getIP();
        }        

        static public void getIP()
        {
            string _myHostIP = "192.168.1.1";

            //获取本地机器名 
            string _myHostName = Dns.GetHostName();

            //获取本机IP 
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                { _myHostIP = _IPAddress.ToString(); }
            }
            //Console.WriteLine(_myHostIP);

            //截取IP网段
            string ipDuan = _myHostIP.Remove(_myHostIP.LastIndexOf('.'));
            //枚举网段计算机
            for (int i = 1; i <= 255; i++)
            {
                Ping myPing = new Ping();
                myPing.PingCompleted += new PingCompletedEventHandler(_myPing_PingCompleted);
                string pingIP = ipDuan + "." + i.ToString();
                myPing.SendAsync(pingIP, 2000, null);       //Ping 延时2000ms
                //Console.Write(".");
            }
            Console.WriteLine("等待2s输出结果");           
            
            ////延时2s后输出采集结果
            Thread.Sleep(2000);
            foreach (System.String s in ipList)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("Fin");
            Console.Read();
        }
        static public void _myPing_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            if (e.Reply.Status == IPStatus.Success)
            {
                ipList.Add(e.Reply.Address.ToString());
            }
        }
    }
}