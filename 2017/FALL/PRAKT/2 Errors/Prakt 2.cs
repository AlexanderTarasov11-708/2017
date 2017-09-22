using System;

namespace Billiards
{
	public static class BilliardsTask
	{
		public static double BounceWall(double directionRadians, double wallInclinationRadians)
		{
            double angle = wallInclinationRadians*2 - directionRadians;
			return angle;
		}
	}
}