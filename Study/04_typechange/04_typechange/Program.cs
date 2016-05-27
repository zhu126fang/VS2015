using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_typechange
{
    class Program
    {
        static void Main(string[] args)
        {
            double d = 128.64;
            bool b = true;
            int i;
            string s,s1;

            i = (int)d; //强制类型转换
            s = d.ToString();
            s1 = b.ToString();

            Console.WriteLine("d is :{0}  \ni is :{1} \ns is :{2}",d,i,s1);
            Console.ReadKey();
        }
    }
}
