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
            //Cond2
            //
            Console.Write("Enter x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Enter y: ");
            int y = int.Parse(Console.ReadLine());
            Console.Write("Enter z: ");
            int z = int.Parse(Console.ReadLine());

            Console.Write("Enter a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter b: ");
            int b = int.Parse(Console.ReadLine());

            if (WillCrawlThrough(x, y, z, a, b))
                Console.WriteLine("Will Crawl");
            else
                Console.WriteLine("Will not crawl");
        }

        //method for checking will timber crawl through hole or not
        static bool WillCrawlThrough(int x0, int y0, int z0, int a0, int b0)
        {
            return ((Minimum(x0, y0, z0) < Math.Min(a0, b0)) && 
                    (Medium(x0, y0, z0) < Math.Max(a0, b0)));
        }

        //minimum of 3 numbers
        static int Minimum(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b),c);
        }

        //maximum of 3 numbers
        static int Maximum(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b),c);
        }

        //medium of 3 numbers
        static int Medium(x0,y0,z0)
        {
            if (CheckForMedium(a,b,c))
                return a;
            else if (CheckForMedium(b,a,c))
                return b;
            else
                return c;        
        }

        //первый аргумент проверяется на медиум
        static bool CheckForMedium(a,b,c)
        {
            if (a > Minimum(a,b,c) && x0 < Maximum(a,b,c))
                return true;
            return false;    
        }
        
    }
}