using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Scan_Port
{
    class Program
    {
        //已扫描端口数目
        internal static int scannedCount = 0;

        internal static int runningThreadCount = 0;

        internal static List<int> openedPorts = new List<int>();

        static int startPort = 1;
        static int endPort = 500;

        static int maxThread = 100;

        static void Main(string[] args)
        {
            //简单提示
            Console.WriteLine("//////////////////////////////////////////////////////////////////");
            Console.Write("请输入扫描的主机 (默认：192.168.2.151):");
            string host = Console.ReadLine();
            Console.Write("请输入扫描的端口 (默认：1-100):");
            string portRange = Console.ReadLine();

            if (host == "")         {host = "192.168.2.151"; }
            if (portRange == "") { startPort = 1; endPort = 100; }
            else
            {
                startPort = int.Parse(portRange.Split('-')[0].Trim());
                endPort = int.Parse(portRange.Split('-')[1].Trim());
            }

            for (int port = startPort; port < endPort; port++)
            {
                Scanner scanner = new Scanner(host, port);
                Thread thread = new Thread(new ThreadStart(scanner.Scan));
                thread.Name = port.ToString();
                thread.IsBackground = true;
                thread.Start();

                runningThreadCount++;
                Thread.Sleep(10);

                //循环，直到某个线程工作完毕才启动另一新线程，也可以叫做推拉窗技术
                while (runningThreadCount >= maxThread) ;
            }

            //空循环，直到所有端口扫描完毕
            while (scannedCount + 1 < (endPort - startPort)) ;
            Console.WriteLine();
            Console.WriteLine();

            //输出结果
            Console.WriteLine("Scan for host:{0} has been completed, \n total {1} ports scanned, \n opened ports:{2}", host, (endPort - startPort), openedPorts.Count);

            foreach (int port in openedPorts)
            {
                Console.WriteLine("\tport: {0} is open", port.ToString().PadLeft(6));
            }

            Console.ReadLine();
        }

        class Scanner
        {
            string m_host;
            int m_port;

            public Scanner(string host, int port)
            {
                m_host = host;
                m_port = port;
            }
            public void Scan()
            {
                TcpClient tc = new TcpClient();
                tc.SendTimeout = tc.ReceiveTimeout = 2000;

                try
                {
                    tc.Connect(m_host, m_port);
                    if (tc.Connected)
                    {
                        Console.WriteLine("Port {0} is Open", m_port.ToString().PadRight(6));
                        Program.openedPorts.Add(m_port);
                    }
                }
                catch
                {
                    //Console.WriteLine("Port {0} is Closed", m_port.ToString().PadRight(6));
                    Console.Write(".");
                }
                finally
                {
                    tc.Close();
                    tc = null;
                    Program.scannedCount++;
                    Program.runningThreadCount--;
                }
            }
        }
    }
}
