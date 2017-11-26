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
            //ex1
            //переставить элементы целочисленного массива в обратном порядке

            var arr = new int[5] { 0, 1, 2, 3, 4 };
            ReverseArray(arr);
        }

        static int[] ReverseArray(int [] tempArray)
        {
            int n = tempArray.Length;
            var newArray = new int[n];
            for (int i=0; i < tempArray.Length; i++)
            {
                newArray[i] = tempArray[n - i - 1];
            }
            return newArray;
        }
        
        //reversing int array 2nd variant
        //but I didn't know could I use such methods or not
        static int[] ReverseArray2(int[] tempArray)
        {
            Array.Reverse(tempArray);                   //reversing char array and getting reversed number
            return tempArray;
        }
    }
}
