using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar1
{
    class Program
    {
        //не успел
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var temp = Console.ReadLine();
            var a = int.Parse(temp.Substring(0, temp.IndexOf(' ')));
            var b = int.Parse(temp.Substring(temp.IndexOf(' ') + 1));

            var dictionary = new Dictionary<int, int[]>();
        }

        public int Check (Dictionary<int, int[]> dict, int begin, int end)
        {
            foreach (var elem in dict[begin])
                //уже есть дорога
                if (elem == end)
                    return 0;
            return -1;

        }
    }
}
