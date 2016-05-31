using System;
using System.Collections.Generic;
using System.Text;
using SeasideResearch.LibCurlNet;

namespace CURLDemo
{
	class Program
	{
		public static void Main(String[] args)
		{
			try {
				Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);

				Easy easy = new Easy();
				Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);

                /////开启数据更新
                //easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/write.php");
                //easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, "cmd=1");

                /////关闭数据更新
                //easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/write.php");
                //easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, "cmd=0");

                /////获取实时数据
                easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/mnt/symbols");

                //设定主机箱压力为500Kpa
                //easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/write.php");
                //easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, "set=.Main_Pression_Set%3AINT%3D5000%3B&cmd=3");

                //设定主机箱压力为0Kpa
                //easy.SetOpt(CURLoption.CURLOPT_URL, "http://192.168.2.50/variables/write.php");
                //easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, "set=.Main_Pression_Set%3AINT%3D0%3B&cmd=3");

                easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
				easy.Perform();
				easy.Cleanup();

				Curl.GlobalCleanup();

			} catch(Exception ex) {
				Console.WriteLine(ex);
			}
			Console.ReadKey();
		}

		public static Int32 OnWriteData(Byte[] buf, Int32 size, Int32 nmemb, Object extraData)
		{
			Console.Write(System.Text.Encoding.UTF8.GetString(buf));
			return size * nmemb;
		}
	}
}
