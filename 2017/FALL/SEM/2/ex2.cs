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
            //second task
            //
            Console.Write("Enter hours: ");                 //input
            string temp = Console.ReadLine();
            double hours = (double)int.Parse(temp);
            Console.Write("Enter minutes: ");
            temp = Console.ReadLine();

            double minutes = (double)int.Parse(temp);

            hours = hours + (minutes / 60.0);               //movement of hour hand based on minutes (0,60)

            if (hours >= 12)                                //deleting unnecessary hours
                hours -= 12;
            hours *= 30;                                    //converting hours to degrees
            minutes *= 6;                                   //converting minutes to degrees

            double result = Math.Abs(hours - minutes);
            if (result > 180)                               //finding the smallest difference between hands
                result -= 180;

            Console.WriteLine(result);
        }
    }