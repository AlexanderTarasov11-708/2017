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
            //seventh task
            //
            Console.WriteLine("A*x + B*y + C = 0");
            Console.Write("Enter A: ");
            string s = Console.ReadLine();
            int a= int.Parse(s);
            Console.Write("Enter B: ");
            s = Console.ReadLine();
            int b = int.Parse(s);
            Console.Write("Enter C: ");
            s = Console.ReadLine();
            int c = int.Parse(s);

            int x = b * (-1);
            int y = a;
            Console.Write("Вектор, параллельный прямой: ");
            Console.WriteLine("Вектор ā1(" + x + "; " + y + ")");
            Console.WriteLine();

            x = a;
            y = b;
            Console.Write("Вектор, перпендикулярный прямой: ");
            Console.WriteLine("Вектор ā2(" + x + "; " + y + ")");
            Console.WriteLine();
        }
    }
}