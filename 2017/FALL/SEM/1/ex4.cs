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
            //fourth task
            //
            Console.Write("Enter N: ");
            string s = Console.ReadLine();              //reading string from console
            int N = int.Parse(s);                       //parsing string to int
            Console.Write("Enter X: ");
            s = Console.ReadLine();
            int X = int.Parse(s);
            Console.Write("Enter Y: ");
            s = Console.ReadLine();
            int Y = int.Parse(s);
            N--;                                        //because we count numbers < than N

            int quantity = N / X + N / Y - N / (X * Y);
            Console.WriteLine(quantity);
        }
    }
}
