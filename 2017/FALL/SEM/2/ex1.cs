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
            //first task

            int sum = 0;

            for (int i = 0; i < 1000; i++)              //loop of all positive numbers < than 1000
            {
                if ((i % 3 == 0) || (i % 5 == 0))       //check for multiplicity on 3 or 5
                    sum += i;
            }

            Console.WriteLine(sum);
        }
    }
}
