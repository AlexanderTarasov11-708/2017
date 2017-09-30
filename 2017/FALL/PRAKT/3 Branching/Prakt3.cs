using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double xVector = Length(bx, ax);
            double yVector = Length(by, ay);

            double xLength0 = Length(ax, x);
            double yLength0 = Length(ay, y);

            double xLength1 = Length(bx, x);
            double yLength1 = Length(by, y);

            double lengthAB = DistanceBtwPoints(xVector, yVector);
            double lengthAP = DistanceBtwPoints(xLength0, yLength0);
            double lengthBP = DistanceBtwPoints(xLength1, yLength1);

            //scalar multiplication of AP and AB
            double scalarMulti0 = (bx - ax)*(x - ax) + (by - ay)*(y - ay);
            //scalar multiplication of AB*AB
            double scalarMulti1 = Math.Pow(lengthAP, 2.0);

            //if point is on the same horizontal line with line segment
            if (ay == by && ay == y)
            {
                //if point belongs to line segment
                if (x > Math.Min(ax,bx) && x < Math.Max(ax,bx))
                    return 0.0;
                return Math.Min(Length(ax,x),Length(bx,x));
            }
            else if (scalarMulti0 <= 0)
                return lengthAP;
            else if (scalarMulti1 <= scalarMulti0)
                return lengthBP;
            else
            {
                return (Math.Abs(yVector * x - xVector * y + bx * ay - by * ax)) / lengthAB;
            }
            

        }

        //distance between points
        private static double DistanceBtwPoints(double xLength, double yLength)
        {
            return Math.Sqrt((Math.Pow(xLength, 2.0) + Math.Pow(yLength, 2.0)));
        }

        //length between points on needed axis
        static double Length(double a0, double a1)
        {
            return Math.Abs(a0 - a1);
        }
    }
}