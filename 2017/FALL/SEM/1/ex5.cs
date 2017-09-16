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
            //fifth task
            //
            Console.WriteLine("Enter first year: ");                //asking first year in range
            string s = Console.ReadLine();                          //reading number from console in string format
            int first = Convert.ToInt32(s);                         //converting string to int

            Console.WriteLine("Enter second year: ");               //asking second year in range
            s = Console.ReadLine();                                 //reading number from console in string format
            int second = Convert.ToInt32(s);                        //converting string to int

            int leapYears = 0;                                      //initializing number of leap-years in range

            int years = second - first;                             //number of years between them

            leapYears = years / 4 - years / 100 + years / 400 + 1;

            Console.WriteLine();
            Console.WriteLine("Number: " + leapYears);                  //Output results
        }
    }
}
