using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar1
{
    class Third
    {
        static void Main(string[] args)
        {
            //third task
            //
            Console.WriteLine("Enter first year: ");            //asking first year in range
            string s = Console.ReadLine();                      //reading number from console in string format
            int a = Convert.ToInt32(s);                         //converting string to int

            Console.WriteLine("Enter second year: ");           //asking second year in range
            s = Console.ReadLine();                             //reading number from console in string format
            int b = Convert.ToInt32(s);                         ////converting string to int

            int count = 0;                                      //initializing number of leap-years in range

            for (int i = a; i <= b; i++)                        //loop in range btw first and second year
            {
                if (i % 4 == 0)                                 // if year is divided by 4
                {
                    if ((i % 100 != 0)|((i % 100 == 0) & (i % 400 == 0)))    // and isn't divided by 100 or divided by 400
                        count++;                                             //incrementing number of leap-years in range
                }
            }

            Console.WriteLine();
            Console.WriteLine("Number: " + count);              //Output results
        }
    }
}
