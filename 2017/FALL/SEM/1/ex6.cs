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
            //sixth task
            //
            Console.Write("Enter X coordinate of first point: ");
            string s = Console.ReadLine();
            int x1 = int.Parse(s);

            Console.Write("Enter Y coordinate of first point: ");
            s = Console.ReadLine();
            int y1 = int.Parse(s);

            Console.Write("Enter X coordinate of second point: ");
            s = Console.ReadLine();
            int x2 = int.Parse(s);

            Console.Write("Enter Y coordinate of second point: ");
            s = Console.ReadLine();
            int y2 = int.Parse(s);

            int height = Math.Abs(y2 - y1);                                             // height = |y2 - y1|
            int width = Math.Abs(x2 - x1);                                              // width = |x2 - x1|
            int distance = (int)Math.Sqrt(Math.Pow(height,2.0) + Math.Pow(width,2.0) ); //distance is counting with Pythagorean theorem


            Console.WriteLine();
            Console.Write("Distance is: ");
            Console.WriteLine(distance);
        }
    }
}
