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
            //Serial number of arithmetic progression
            int f = ParseInput("f");
            int s = ParseInput("s");
            int n = ParseInput("n");

            Console.WriteLine(FindingSerialNumber(f, s, n));
        }

        //assigning variables from input
        static int ParseInput(string varName)
        {
            Console.Write("Enter {0}: ", varName);
            string temp = Console.ReadLine();
            return int.Parse(temp);
        }

        //finding serial number of n in arithmetic progression
        static int FindingSerialNumber(int f, int s, int n)
        {
            n -= f;
            
            //if (n - f) is divided by s, it belongs to arithmetic progression
            if (n % s == 0)
                return n / s + 1;
            //if not, return -1
            return -1;
        }
    }
}
