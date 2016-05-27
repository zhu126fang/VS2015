using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Circular
{
    class Program
    {
        static void Main(string[] args)
        {
            const double Pi = 3.1415926;
            double r;
            double s;
            string str;

            Console.WriteLine("Put the r :");
            str=Console.ReadLine();
            r = Convert.ToDouble(str);

            s = Pi * r * r;
            Console.WriteLine("s is :{0}", s);
            Console.ReadLine();

        }
    }
}
