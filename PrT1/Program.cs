using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrT1
{
    class Program
    {
        static void Main()
        {
            

            int a = int.Parse(Console.ReadLine());
            int max = a;
            while (a != 0)
            {
                a = int.Parse(Console.ReadLine());
                if (a > max) max = a;
            }
            Console.WriteLine(max);
        }
    }
}
