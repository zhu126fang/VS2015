using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.IO;

namespace telnet_client
{
    class Program
    {
        //登录固定IP地址的服务器
        public static NetworkStream stream;
        public static TcpClient tcpclient;
        public static string ip = "192.168.2.50";
        public static int port = 23;
        public static string strmsg;
        
        static void Main(string[] args)
        {
            //Console.WriteLine("目标IP:");
            //ip = Console.ReadLine();
            //Console.WriteLine("目标Port:");
            //port = int.Parse(Console.ReadLine());

            Run();
        }

        static public void Run()
        {
            tcpclient = new TcpClient(ip, port);  // 连接服务器
            stream = tcpclient.GetStream();   // 获取网络数据流对象
            StreamWriter sw = new StreamWriter(stream);
            StreamReader sr = new StreamReader(stream);
            while (true)
            {
                //Read Echo
                //Set ReadEcho Timeout
                stream.ReadTimeout = 10;

                strmsg = "";
                try
                {
                    while (true)
                    {
                        char c = (char)sr.Read();
                        if (c < 256)
                        {
                            if (c == 27)
                            {
                                while (sr.Read() != 109) { }
                            }
                            else
                            {
                                //Console.Write(c);
                                strmsg = strmsg + c.ToString();
                            }
                        }
                    }
                }
                catch   { }

                //Console.Write(strmsg);
                //自动输入用户名和密码
                if (strmsg.IndexOf("CPX-CEC login") != -1)
                {
                    sw.Write("{0}\r\n", "root");
                    sw.Flush();
                }
                else if (strmsg.IndexOf("Password") != -1)
                {
                    sw.Write("{0}\r\n", "Festo");
                    sw.Flush();
                }
                else
                {
                    Console.Write(strmsg);
                    //Send CMD
                    sw.Write("{0}\r\n", Console.ReadLine());
                    sw.Flush();
                }
            }
        }

    }
}
