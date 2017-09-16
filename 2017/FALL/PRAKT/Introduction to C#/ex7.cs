using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulearn1
{
    class ex7
    {
    	private static string PrintGreeting(string name, double salary)
		{
			// возвращает "Hello, <name>, your salary is <salary>"
			string temp = "Hello, " + name + ", your salary is ";
			int s = (int) Math.Ceiling(salary);     //Math.Ceiling округляет вверх
			temp+=s;
			return temp;
		}


        static void Main(string[] args)
        {
            Console.WriteLine(PrintGreeting("Student", 10.01));
			Console.WriteLine(PrintGreeting("Bill Gates", 10000000.5));
			Console.WriteLine(PrintGreeting("Steve Jobs", 1));
        }
    }
}