using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulearn1
{
    class ex8
    {
    	private static int GetSquare(int num){ //getting square of int number
			return num*num;
		}

		private static void Print(int s){     //output string
			Console.WriteLine(s);
		}



        static void Main(string[] args)
        {
            Print(GetSquare(42));
        }
    }
}