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
            //third task
            //
            Console.WriteLine("Enter H hours: ");
            string s = Console.ReadLine();              //reading number from console
            int n = int.Parse(s);                       //parsing string into int
            n = n % 12;                                 //putting away unnecessary hours
            if (n > 6)                                  //we need to get least degree acording to condition of the task
                n = 12 - n;                             //so if arrow is in the right side of time, we count counterclock-wise, otherwise - clockwise
            Console.WriteLine(n*30);                    //getting needed degree
        }
    }
}
