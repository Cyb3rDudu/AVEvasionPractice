using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ManyIterations
{
    internal class Program
    {
        static void Main()
        {
            long count = 0;
            long max = 9000000000;
            for (int i = 0; i < max; i++){
                count++;
            }
            if (count == max)
            {
                runner();
            }
        }
        static void runner()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
