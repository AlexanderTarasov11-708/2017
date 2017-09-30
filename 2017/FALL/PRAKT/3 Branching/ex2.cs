using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex
{
    class Program
    {
    	//Среднее трех
    	
    	public static void Main()
		{
			Console.WriteLine(MiddleOf(5, 0, 100)); // => 5
			Console.WriteLine(MiddleOf(12, 12, 11)); // => 12
			Console.WriteLine(MiddleOf(2, 3, 2));
			Console.WriteLine(MiddleOf(8, 8, 8));
			Console.WriteLine(MiddleOf(5, 0, 1));
		}

    	public static int MiddleOf(int a, int b, int c)
		{
			if (a > b)
			{
				if (b > c) return b;
				else if (a > c) return c;
					else return a;
			}
			else 
			if (a > c) return a;
				else if (b > c) return c;
				else return b;
			}
		}
}