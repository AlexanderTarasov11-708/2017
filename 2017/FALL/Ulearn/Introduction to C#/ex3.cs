using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulearn1
{
    class ex3
    {
        static void Main(string[] args)
        {
            double pi = Math.PI;
			int tenThousand = (int)10000L;
			float tenThousandPi = (float)pi*tenThousand;
			int roundedTenThousandPi = (int)Math.Round(tenThousandPi);
			int integerPartOfTenThousandPi = (int)tenThousandPi;
			Console.WriteLine(integerPartOfTenThousandPi);
			Console.WriteLine(roundedTenThousandPi);
        }
    }
}
