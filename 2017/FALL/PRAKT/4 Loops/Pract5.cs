using System;
using System.Drawing;

namespace Fractals
{
    internal static class DragonFractalTask
    {
        const double Pi = Math.PI;
        public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
        {
            //initial point (1;0)
            double x = 1;
            double y = 0;
            var random = new Random(seed);

            //going through loop
            while (iterationsCount > 0)
            {
                //finding random transformation
                var transformation = random.Next(2);
                double tempX = x;           //temp variables for saving initial x and y positions
                double tempY = y;
                x = TransformationX(transformation, tempX, tempY);
                y = TransformationY(transformation, tempX, tempY);

                pixels.SetPixel(x, y);          //draw current point
                iterationsCount--;              //next iteration
            }
        }

        //transormation for x
        static double TransformationX(int trans, double x, double y)
        {
            //first transformation
            if (trans == 0)
                //45 degress = Pi / 4
                return (x * Math.Cos(Pi / 4) - y * Math.Sin(Pi / 4)) / Math.Sqrt(2);

            //second transormation
            else
                //135 degrees = 3 * Pi / 4
                return (x * Math.Cos(3 * Pi / 4) - y * Math.Sin(3 * Pi / 4)) / Math.Sqrt(2) + 1;
        }

        //transformation for y
        static double TransformationY(int trans, double x, double y)
        {
            //first transformation
            if (trans == 0)
                return (x * Math.Sin(Pi / 4) + y * Math.Cos(Pi / 4)) / Math.Sqrt(2);

            //second transformation
            else
                return (x * Math.Sin(3 * Pi / 4) + y * Math.Cos(3 * Pi / 4)) / Math.Sqrt(2);
        }
    }
}