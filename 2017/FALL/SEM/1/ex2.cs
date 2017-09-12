using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar1
{
    class ex2
    {
        static void Main(string[] args)
        {

            //second task
            //
            int a = 123;
            int b = (a / 100);              //getting first digit of a = 1 and putting it to first digit in b
            
            b += ((a % 100) / 10) * 10;     //getting second digit of a = 2 and putting it to the same (2nd) digit in b
            b += ((a % 100) % 10) * 100;    //getting third digit of a = 3 and putting it to the third digit in b
            
            Console.WriteLine("Inverse: ");
            Console.WriteLine(b);           //Output
        }
    }
}
