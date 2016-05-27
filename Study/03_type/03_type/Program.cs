using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_type
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello");

            Console.WriteLine("bool size is : {0}", sizeof(bool));
            Console.WriteLine("byte size is : {0}", sizeof(byte));
            Console.WriteLine("Int size is : {0}", sizeof(int));
            Console.WriteLine("char size is : {0}", sizeof(char));
            Console.WriteLine("long size is : {0}", sizeof(long));

            Console.ReadKey();
        }
    }
}
