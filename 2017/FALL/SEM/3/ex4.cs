using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex
{

    class Program
    {
    	//Cond4
    	
        static void Main(string[] args)
        {
            Console.Write("Enter A: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter B: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter C: ");
            double c = double.Parse(Console.ReadLine());
            Console.Write("Enter D: ");
            double d = double.Parse(Console.ReadLine());

            Console.WriteLine("Intersection region is: " + IntersectionRegion(a, b, c, d));
        }

        // finding intersection region 2 line segments
        static double IntersectionRegion(double a, double b, double c, double d)
        {
            return Math.Min(b, d) - Math.Max(a, c);
        }
    }
}