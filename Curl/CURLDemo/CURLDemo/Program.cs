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

				easy.SetOpt(CURLoption.CURLOPT_URL, "https://kyfw.12306.cn/otn/lcxxcx/query?purpose_codes=ADULT&queryDate=2016-06-07&from_station=BJP&to_station=AOH");

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
