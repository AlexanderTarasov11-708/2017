using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar1
{
    class Program
    {
        static void Main(string[] args)
        {

            //first task
            //
            int a = 1;
            int b = 2;

            //first method
            int temp = 0;
            temp = a;
            a = b;
            b = temp;

            //second method
            //b = b - a;
            //a = a + b;
            //b = a - b;

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.ReadLine();


            //second task
            //
            a = 123;
            b = (a / 100);
            
            b += ((a % 100) / 10) * 10;
            b += ((a % 100) % 10) * 100;
            
            Console.WriteLine(b);

            //third task
            //
        }
    }
}
