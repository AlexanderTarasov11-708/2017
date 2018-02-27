using System;

namespace ex
{
    public class Program
    {
        //Тарасов Александр 11-708
        //Вариант 17
        //Задача 1.1
        static void Main()
        {
            Console.WriteLine();
        }

        //определяем на каком шаге достигнется точность
        public static Tuple<int, double> DetermineStep(int x, double accuracy)
        {
            //начинаем шаг с 2, потому что
            //log(0)x не имеет решений
            //log(1)x = 0
            int step = 2;
            double function = Math.Pow(3, x);
            double sum = 0;
            if (SumAlgorithm(x, accuracy, ref step, function, ref sum))
                return Tuple.Create(step, sum);
            else
                //точность не достигнута
                return null;
        }

        //выполняем алгоритм суммы, пока не достигнем нужной точности
        static bool SumAlgorithm(int x, double accuracy, ref int step, double function, ref double sum)
        {
            while (Math.Abs(function - sum) > accuracy)
            {
                if (step == 13)
                    //если больше 12, значение факториала будет слишком большим, больше long
                    return false;
				// ---check--- просто не надо было пересчитывать факториал на каждом шаге, а надо было накапливать результат. Решение неоптимальное
                sum += SumFunction(x, step);
                step++;
            }
            return true;
        }

        //функция суммы
        public static double SumFunction(int x, int step)
        {
            return (Math.Pow(x, step) * Math.Pow(Math.Log(3), step)) / Factorial(step);
        }

        //вычисление факториала числа
        public static long Factorial(int n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }
    }
}
