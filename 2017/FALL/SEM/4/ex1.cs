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
            //ex1
            //Дано целое неотрицательное число N. Найти число, составленное теми же десятичными цифрами, что и N, но в обратном порядке. 
            //Запрещено использовать массивы.
            int n = ParseInput("N");
            string temp = "";

            while (true)
            {
                temp += n % 10;
                n /= 10;
                if (n == 0)
                    break;
            }
            n = int.Parse(temp);

            Console.WriteLine(n);
        }

        //assigning variables from input
        static int ParseInput(string varName)
        {
            Console.Write("Enter {0}: ", varName);
            string temp = Console.ReadLine();
            return int.Parse(temp);
        }
    }
}