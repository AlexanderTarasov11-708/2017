using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar1
{
    class First
    {
        static void Main(string[] args)
        {

            //first task
            //
            int a = 1;
            int b = 2;

            //first method
            int temp = 0;           //creating temp variable
            temp = a;               //initializing it to a, so that we can use a value further
            a = b;                  // a = 2
            b = temp;               // b = 1

            Console.WriteLine("First method: ");
            Console.WriteLine("a = " + a);   //Output results
            Console.WriteLine("b = " + b);
            Console.WriteLine();

            //second method
            b = b - a;
            a = a + b;
            b = a - b;

            Console.WriteLine("Second method: ");

            Console.WriteLine("a = " + a);   //Output results
            Console.WriteLine("b = " + b);
            Console.WriteLine();

        }
    }
}
