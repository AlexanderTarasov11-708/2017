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
            //Lucky ticket
            int text = int.Parse(Console.ReadLine());

            isLuckyTicket(text);
        }

        //determining is ticket lucky or not
        static void isLuckyTicket(int n)
        {
            //parsing ticket number into digits
            int a = n / 100000;
            int b = (n / 10000) %10;
            int c = (n / 1000) %10;
            int d = (n / 100) % 10;
            int e = (n / 10) % 10;
            int f = n % 10;

            int firstsum = a + b + c;
            int secondsum = d + e + f;

            if (firstsum == secondsum)
                Console.WriteLine("Lucky ticket!");
            else
                Console.WriteLine("Unlucky ticket");
        }
    }
}
