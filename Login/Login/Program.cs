using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string strTime = currentTime.ToString("HH时mm分ss秒, dddd, MMMM dd yyyy");

            string path1 = @"D:\Users\Administrator\Documents\Visual Studio 2015\Projects\VS2015\Login";
            if (!Directory.Exists(path1)) Directory.CreateDirectory(path1);

            string filename1 = @"D:\Users\Administrator\Documents\Visual Studio 2015\Projects\VS2015\Login\Login.log";
            string filename2 = @"C:\login.log";         

            ///文件写入项目
            FileStream fs = new FileStream(filename1, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.Write(strTime + "\r\n");            
            sw.Close();
            fs.Close();

            /////文件写入C盘
            FileStream fs1 = new FileStream(filename2, FileMode.Append);
            StreamWriter sw1 = new StreamWriter(fs1, Encoding.Default);
            sw1.Write(strTime + "\r\n");
            sw1.Close();
            fs1.Close();
        }
    }
}
