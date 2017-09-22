using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex
{
    class Program
    {
        static void Main(string[] args)
        {
            //second task
            //Минимум функции

            Console.WriteLine();
        }

        private static void WriteParabolaMinX(int a, int b, int c)
        {
            if (a == 0)
                Console.WriteLine("Impossible");
            else
            {
                double x = (double)(-b) / (2 * a);
                Console.WriteLine(x);
            }
        }
    }
}