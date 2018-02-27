using System;

namespace ex
{
    public class Program
    {
        //Тарасов Александр 11-708
        //Вариант 17
        //Задача 1.3

        //константа Эйлера
        static double Euler = 0.577215664901533;

        static void Main()
        {
            Console.WriteLine();
        }

        //определяем, на каком шаге достигнется точность
        public static Tuple<int, double> DetermineStep(int n, double accuracy)
        {
            int step = 1;
            double function = Function(n) + Euler;
            double sum = 0;

            if (SumAlgorithm(accuracy, ref step, function, ref sum))
            {
				//---check--- здесь аналогично предыдущим заданиям
                var res = sum - Function(n);
                return Tuple.Create(step, res);
            }
            else
                //точность не достигнута
                return null;
        }

        //функция
        public static double Function(int x)
        {
            return Math.Log(x) + Math.Pow(2 * x, -1) - Math.Pow(12 * x * x, -1) + Math.Pow(120 * x * x * x * x, -1);
        }

        //выполняем алгоритм суммы, пока не достигнем нужной точности
        static bool SumAlgorithm(double accuracy, ref int step, double function, ref double sum)
        {
            while (Math.Abs(function - sum) > accuracy)
            {
                if (sum > function + accuracy)
                    //если сумма уходит дальше, точность не достигнута
                    return false;
                sum += SumFunction(step);
                step++;
            }
            return true;
        }

        //функция суммы
        public static double SumFunction(int step)
        {
            return Math.Pow(step, -1);
        }
    }
}
