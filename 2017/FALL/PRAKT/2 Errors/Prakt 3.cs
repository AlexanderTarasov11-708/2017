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
            //Практика «Проценты»

            string temp = Console.ReadLine();

            Console.WriteLine(Calculate(temp));
        }

        static double Calculate(string input)
        {
            int index = input.IndexOf(' ');
            double sum = GetNumberFromStr(input, index);
            input = input.Substring(index + 1);

            index = input.IndexOf(' ');
            double percents = GetNumberFromStr(input, index);
            input = input.Substring(index + 1);
            percents = percents / 100 / 12 + 1;

            int months = int.Parse(input);

            double newSum = sum * Math.Pow(percents, months);

            return newSum;
        }

        static double GetNumberFromStr(string s, int i)
        {
            return double.Parse(s.Substring(0, i));
        }
    }
}
