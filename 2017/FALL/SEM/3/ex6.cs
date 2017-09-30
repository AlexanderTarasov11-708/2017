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
            //Cond6
            
            int x0 = InputCoordinate("x", 1);
            int y0 = InputCoordinate("y", 1);
            int x1 = InputCoordinate("x", 2);
            int y1 = InputCoordinate("y", 2);
            int x2 = InputCoordinate("x", 3);
            int y2 = InputCoordinate("y", 3);

            if (CheckForSquare(x0,y0,x1,y1,x2,y2))
            {
                //if it is square, find 4th point
                // ???
            }

        }

        //method for input
        private static int InputCoordinate(string xOrY, int OneTwo)
        {
            Console.Write("Enter " + xOrY + " coordinate of {0}st point: ", OneTwo);
            return int.Parse(Console.ReadLine());
        }

        //check for right angle
        static bool CheckForRightAngle(int x0, int y0, int x1, int y1, int x2, int y2)
        {
            double lengthX0 = Length(x0,x1);
            double lengthX1 = Length(x2, x1);
            double lengthY0 = Length(y0, y1);
            double lengthY1 = Length(y2, y1);
            double distance0 = DistanceBtwPoints(lengthX0, lengthY0);
            double distance1 = DistanceBtwPoints(lengthX1, lengthY1);
            //if arccos = 0, then angle = 90 degrees
            return (Math.Acos((lengthX0 * lengthX1 + lengthY0 * lengthY1) / (distance0 * distance1)) == 0);
        }

        //check for square
        static bool CheckForSquare(int x0, int y0, int x1, int y1, int x2, int y2)
        {
            double distance0 = DistanceBtwPoints(Length(x0, x1), Length(y0, y1));
            double distance1 = DistanceBtwPoints(Length(x2, x1), Length(y2, y1));
            //if angle is right and sides are equal, figure is square
            return (CheckForRightAngle(x0, y0, x1, y1, x2, y2) && (distance0 == distance1));
        }

        //distance between points
        private static double DistanceBtwPoints(double xLength, double yLength)
        {
            //by Pythagorean theorem
            return Math.Sqrt((Math.Pow(xLength, 2.0) + Math.Pow(yLength, 2.0)));
        }

        //length between points on needed axis
        static double Length(double a0, double a1)
        {
            return Math.Abs(a0 - a1);
        }
    }
}