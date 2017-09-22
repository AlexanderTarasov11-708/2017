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
            //third task
            //Сделай то, не знаю что

            Console.WriteLine();
        }

        static string Decode(string stringToDecode)
        {
            stringToDecode = stringToDecode.Replace(".", "");     //deleting points and spaces from string
            int number = int.Parse(stringToDecode);               //parsing in to int
            number = number % 1024;                               //number must be in 0 .. 1023
            string result = Convert.ToString(number);             //parsing in to string because of type of method
            return result;
        }
    }
}
