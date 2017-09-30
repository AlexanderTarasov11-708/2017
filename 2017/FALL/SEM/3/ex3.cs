using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex
{

    class Program
    {
    	//Cond3

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            //checking next and previous ticket number
            if ((CheckForLuck(number+1) && number!=999999)||(CheckForLuck(number-1) && number != 0))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }

        //checking ticket number for luck
        private static bool CheckForLuck(int number)
        {
        	//assigning digits to variables
            int f = number % 10;
            number /= 10;
            int e = number % 10;
            number /= 10;
            int d = number % 10;
            number /= 10;
            int c = number % 10;
            number /= 10;
            int b = number % 10;
            number /= 10;
            int a = number % 10;

            return (a + b + c == d + e + f) ;
        }
    }
}