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
            //ex3
            //Finding multiplication of digits of n in k-numeral system
            int k = ParseInput("k");
            int n = ParseInput("n");

            int s = Multiply(k,n);
            Console.WriteLine(s);
        }

        //multiplication of digits of n in k-numeral system
        static int Multiply(int k, int n)
        {
            int temp = 1;           //multiplication variable
            if (n == 0)             //if n = 0, multiplication = 0
                return 0;
            while (n > 0)
            {
                //going through digits of number
                temp *= ConvertToNumeralSystem(k, n % 10);
                n /= 10;
            }

            return temp;
        }

        //assigning variables from input
        static int ParseInput(string varName)
        {
            Console.Write("Enter {0}: ", varName);
            string temp = Console.ReadLine();
            return int.Parse(temp);
        }

        //convert number to the given numeral system
        static int ConvertToNumeralSystem(int numeralSystem, int n)
        {
            string temp = "";
            if (numeralSystem <= n)
            {
                while (n >= numeralSystem)
                {
                    //process of converting consists of finding remainders
                    temp += n % numeralSystem;
                    n /= numeralSystem;             //go to next quotient
                }
                //and lastly adding last quotient
                temp += n;

                //reversing string, because digits were written in reverse order
                temp = ReverseString(temp);
                return int.Parse(temp);
            }
            return n;
        }

        //reversing string
        private static string ReverseString(string temp)
        {
            string newString = "";

            for (int i = temp.Length - 1; i >= 0; i--)
            {
                newString += temp.Substring(i, 1);
            }

            return newString;
        }

        //reversing string 2nd variant
        //but I didn't know could I use such methods or not
        private static string ReverseString1(string temp)
        {
            char[] array = temp.ToCharArray();      //putting string into char array
            Array.Reverse(array);                   //reversing char array and getting reversed number
            return new string(array);
        }
    }
}
