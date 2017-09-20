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
            //fourth task
            //
            string temp = Console.ReadLine();
            string [] tempArray = temp.Split(' ');                      //spliting string into array of string by spaces
            
            double a = double.Parse(tempArray[0]);                      //assigning numbers to double variables
            double ropeRadius = double.Parse(tempArray[1]);
            double s = 0;

            if (ropeRadius > (a*Math.Sqrt(2.0)))                        //square is whole in the circle
            {
                s = Math.Pow(a,2.0);                                    //square area
            }
            else if (ropeRadius > (a / 2.0))
            {
                double angle = 2.0 * (Math.Acos(1 - (ropeRadius - (a / 2.0)) / ropeRadius));        //angle of segment

                s = (Math.Pow(ropeRadius, 2.0) * (angle - Math.Sin(angle))) / 2.0;                  //segment area
                s = CircleArea(ropeRadius) - 4 * s;
            }
            else                                                        
            {
                s = CircleArea(ropeRadius);                             //circle area less than square
            }
            
            Console.WriteLine(s.ToString());
        }

        static double CircleArea(double radius)
        {
            return Math.PI * Math.Pow(radius, 2.0);
        }
    }
}