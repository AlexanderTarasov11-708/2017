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
            //ex5
            //Разложить чётное целое число на сумму двух простых чисел. Нужно вывести пару с наименьшим простым числом
            int number = ParseInput("number");

            int a0 = 1;
           
            //while we don't find second prime number for sum
            while (!IsPrime(number - a0))
            {
                //go to next prime number
                a0 = FindingNextPrime(a0+1);
            }

            int a1 = number - a0;
            Console.WriteLine("First: {0} \nSecond: {1}",a0,a1);

        }
        
        //find next prime number after (a-1)
        static int FindingNextPrime(int a)
        {
            //while a is not prime, increment value
            while (!IsPrime(a))
            {
                a++;
            }
            return a;
        }

        //assigning variables from input
        static int ParseInput(string varName)
        {
            Console.Write("Enter {0}: ", varName);
            string temp = Console.ReadLine();
            return int.Parse(temp);
        }

        //determining is a prime number
        static bool IsPrime(int a)
        {
            int i = 2;
            //if i > a/2, a cannot be divided by i 
            // i == a/2 is not prime number
            while (i < a / 2)
            {
                if (a % i == 0)
                    return false;
                i++;
            }
            return true;
        }
    }
}
