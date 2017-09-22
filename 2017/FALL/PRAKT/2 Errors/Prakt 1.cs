using System;

namespace AngryBirds
{
	public static class AngryBirdsTask
	{
        //Практика «Angry Birds»
        const double G = 9.8; 

        public static double FindSightAngle(double v, double distance)
		{
            double angle0 = (Math.Asin( (distance * G) / (v * v))) / 2;

            return angle0;
		}
	}
}