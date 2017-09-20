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
            //
            string temp = Console.ReadLine();
            string [] tempArray = temp.Split(' ');                  //spliting string into array of string by spaces

            double h = double.Parse(tempArray[0]);                  //assigning numbers to double variables
            double t = double.Parse(tempArray[1]);
            double v = double.Parse(tempArray[2]);
            double x = double.Parse(tempArray[3]);

            double max =  t;
            double min = (double) ((h - x * t) / (v - x));

            if (h / x <= t)
            {
                min = 0.0;
                max = h / x;
            }

            Console.WriteLine(min.ToString() + " " + max.ToString());
        }

    }
}