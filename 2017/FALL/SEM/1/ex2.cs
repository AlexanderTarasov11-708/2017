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

            //second task
            //
            Console.WriteLine("Enter number for reverse: ")
            string s = Console.ReadLine();  //reading number from console in string format

            char[] array = s.ToCharArray(); //putting string into char array
            Array.Reverse(array);           //reversing char array and getting reversed number
            Console.WriteLine(array);       //output
        }
    }
}
