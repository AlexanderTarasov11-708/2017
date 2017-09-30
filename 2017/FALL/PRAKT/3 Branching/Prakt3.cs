using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double lengthAB = DistanceBtwPoints(Length(bx, ax), Length(by, ay));
            double lengthAP = DistanceBtwPoints(Length(ax, x), Length(ay, y));
            double lengthBP = DistanceBtwPoints(Length(bx, x), Length(by, y));

            //scalar multiplication
            double scalarAC = (bx - ax)*(x - ax) + (by - ay)*(y - ay);
            double scalarBC = (-bx + ax)* (x - bx) + (-by + ay)* (y - by);
            double scalarAB = Math.Pow(lengthAP, 2.0);
            
            //if lengthAB = 0 then AB is not line segment, but just point
            if ( lengthAB == 0 )
            {
                return lengthAP;    //or lengthBP the same
            }

            else if (scalarAC >= 0 && scalarBC >= 0)
            {
                double p = (lengthAP + lengthBP + lengthAB) / 2;
                //by Gerone formula
                double s = Math.Abs(p * (p - lengthAB) * (p - lengthAP) * (p - lengthBP));
                //finding the height of a triangle
                return (2* Math.Sqrt(s))/lengthAB;
            }
            //minimal distance btw point and A or B
            return Math.Min(lengthAP,lengthBP);
            

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