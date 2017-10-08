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
            //ex2
            //Найти количество трехзначных натуральных чисел, сумма цифр которых равна N

            int n = ParseInput("N");
            
            Console.WriteLine(CountNumber(n));
            
        }

        //assigning variables from input
        static int ParseInput(string varName)
        {
            Console.Write("Enter {0}: ", varName);
            string temp = Console.ReadLine();
            return int.Parse(temp);
        }

        static int CountNumber(int n)
        {
            int sum = 0;
            for (int i = 100; i < 1000; i++)
            {
                if (SumOfDigits(i) == n)
                    sum++;
            }
            return sum;
        }

        static int SumOfDigits(int n)
        {
            string temp = n.ToString();
            int a = int.Parse(temp.Substring(0, 1));
            int b = int.Parse(temp.Substring(1, 1));
            int c = int.Parse(temp.Substring(2, 1));

            return a+b+c;
        }
    }
}
