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
            //eighth task
            //
            //line
            Console.WriteLine("Line L: y = a*x + b");
            Console.Write("Enter a for line L: ");
            string s = Console.ReadLine();
            double a1 = (double) int.Parse(s);
            Console.Write("Enter b for line L: ");
            s = Console.ReadLine();
            double b1 = (double)int.Parse(s);
            //point
            Console.Write("Enter x for point A: ");
            s = Console.ReadLine();
            double x0 = (double) int.Parse(s);
            Console.Write("Enter y for point A: ");
            s = Console.ReadLine();
            double y0 = (double) int.Parse(s);

            double x1  = 0.0;
            double y1 = 0.0;

            if (a1 != 0)                        
            {
                double a2 = -1 / a1;
                double b2 = y0 - a2 * x0;       //from the y0 = a2*x0 + b2 

                x1 = (b2 - b1) / (a1 - a2);     //from the system of equation  { y = a*x + b 
                y1 = a1 * x1 + b1;              //                             { y = a1*x + b1
            }
            else                                //line is parallel to ox axis
            {
                y1 = b1;
                x1 = x0;
            }

            Console.WriteLine("(" + x1 + "; " + y1 + ")");

        }
    }
}
