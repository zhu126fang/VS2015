using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_PointRef
{
    class PointRef
    {
        public void swap(ref int x, ref int y)
        {
            int temp;
            temp = x;
            x = y;
            y = temp;
        }
        
        static void Main(string[] args)
        {
            int a=1, b=2;
            PointRef n = new PointRef();

            Console.WriteLine("a:{0} b:{1}", a, b);
            n.swap(ref a, ref b);
            Console.WriteLine("a:{0} b:{1}",a,b);
            Console.ReadKey();
        }
    }
}
