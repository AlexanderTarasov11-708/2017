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
            //first task

            int result = SumOfMultiplies(3) + SumOfMultiplies(5) - SumOfMultiplies(15);
            Console.WriteLine("Sum of multipliers: {0}", result);
        }

        static int SumOfMultiplies(int number)      // quantity of numbers < than 'border' and miltiple of 'number'
        {
            //sum of multiplies is sum of members of arithmetic progression
            // sum = ((a1 + aN) * n ) / 2

            int n = 999 / number;
            int lastNumber = n * number;

            int sum = ((number + lastNumber) * n ) / 2;

            return sum;
        }
    }
}
