using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulearn1
{
    class ex5
    {
        static void Main(string[] args)
        {
            string doubleNumber = "894376.243643";
			double number = double.Parse(doubleNumber); // Вася уверен, что ошибка где-то тут
			Console.WriteLine(number + 1);
        }
    }
}
