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
        	//Cond7
        	
            Console.Write("Enter X: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Enter Y: ");
            double y = double.Parse(Console.ReadLine());
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Math.Ceiling((y * n - x * n) / (1 - y)));
        }
    }
}