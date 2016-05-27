using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_method
{
    class Program
    {
        public int sum(int n)
        {
            int result;

            if (n == 1)
                    result = 1;
            else
                    result= n + sum(n - 1);
                    Console.WriteLine("100+..+ {0}: {1}", n,result);
            return result;
        }

        static void Main(string[] args)
        {
            int sum;
            Program n = new Program();
            sum = n.sum(100);
            Console.WriteLine("sum is :{0}", sum);
            Console.ReadLine();
        }
    }
}
