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
            //ex4
            //На вход подаётся последовательность из n целых чисел (по модулю <=10^9). 
            //Определить является ли последовательность строго убывающей (каждый элемент < предыдущего)
            if (IsDecreasing())
                Console.WriteLine("Sequence is decreasing");
            else
                Console.WriteLine("Sequence is not decreasing");

        }

        private static bool IsDecreasing()
        {
            int a = int.MaxValue;       //max value for less comparison
            while (true)
            {
                string s = Console.ReadLine();

                //if next string is not empty, sequence ended
                if (s == "")            
                    return true;

                int temp = int.Parse(s);
                //if next value is less than previous, OK
                if (temp < a)
                {
                    a = temp;
                }
                //else, sequence is not decreasing
                else
                {
                    return false;
                }
            }
        }
    }
}
