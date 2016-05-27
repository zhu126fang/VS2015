using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Null
{
    class Program
    {
        static void Main(string[] args)
        {
            int? num = null;
            string s;

            Console.WriteLine("num is :{0}",num);

            num = 1;
            Console.WriteLine("num is :{0}", num);
            num = null;
            Console.WriteLine("num is :{0}", num);
            num = new int?();
            Console.WriteLine("num is :{0}", num);
            s = num.ToString();
            Console.WriteLine("num is :{0}", num);

            Console.ReadKey();
        }
    }
}
