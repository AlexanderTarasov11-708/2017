using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex
{
    class Program
    {
        static void Main(string[] args)
        {
            //ex2
            //Значения массива сдвинуть циклически вправо на одну позицию

            var arr = new int[5] { 0, 1, 2, 3, 4 };
            ShiftArray(arr, 1);
        }

        //shift array to the right on positions
        static int[] ShiftArray(int[] tempArray, int positions)
        {
            int n = tempArray.Length;
            var newArray = new int[tempArray.Length];
            for (int i=0; i < tempArray.Length; i++)
            {
                if (i - positions < 0)
                    newArray[i] = tempArray[n - positions + i];
                else
                {
                    newArray[i] = tempArray[i - positions];
                }
            }
            return newArray;
        }
    }
}