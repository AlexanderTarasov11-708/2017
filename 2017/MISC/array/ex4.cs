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
            //ex4
            //Значения массива сдвинуть циклически вправо на k позиций

            var arr = new int[5, 5] { { 1, 2, 3, 4, 5 }, { 4, 3, 2, 1, 5 }, { 1, 2, 3, 4, 5 }, { 4, 3, 2, 1, 5 }, { 1, 2, 3, 4, 5 } };
            ReplaceWithZero(arr);
            PrintArray(arr);
        }

        static int[,] ReplaceWithZero(int[,] tempArray)
        {
            for (int i=0; i < tempArray.GetLength(0); i++)
            {
                for (int j = 0; j < tempArray.GetLength(1); j++)
                {
                    if (i == j || (tempArray.GetLength(1) - i - 1) == j)
                    {
                        tempArray[i, j] = 0;
                    }
                }
            }
            return tempArray;
        }

        static void PrintArray(int [,] arr)
        {
            for (int i=0; i<arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}