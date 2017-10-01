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
            //ex6
            //Last number of factorial
            int n = ParseInput("n");

            int lastDigit = LastNumberOfFactorial(n);
            
            if (lastDigit > -1)
                Console.WriteLine(lastDigit);
            else 
                Console.WriteLine("Mistake");
        }

        //assigning variables from input
        static int ParseInput(string varName)
        {
            Console.Write("Enter {0}: ", varName);
            string temp = Console.ReadLine();
            return int.Parse(temp);
        }

        //last number of factorial
        static int LastNumberOfFactorial(int n)
        {
            if (n >= 0)
            {
                if (n == 0 || n == 1)
                    return 1;
                if (n == 2)
                    return 2*1;         //2
                if (n == 3)
                    return 2*3;         //6
                if (n == 4)
                    return (2*3*4)%10;  //4
                return 0;               //all others ends with 0
            }
            //incorrect
            return -1;
        }
    }
}
