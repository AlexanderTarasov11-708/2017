using System;

namespace ex
{
    public class Program
    {
        //Тарасов Александр 11-708
        //Вариант 17
        //Задача 1.2
        static void Main()
        {
            var res = DetermineStep(2, 0.05);
            Console.WriteLine();
        }

        //определяем на каком шаге достигнется точность
        public static Tuple<int, double> DetermineStep(double x, double accuracy)
        {
            if (Math.Abs(x) > 1 || x == -1)
            {
                //x /= -1, потому что в левой части в знаменателе получается 0
                Console.WriteLine("Wrong input, |x| < 1");
                return null;
            }
            else
            {
                int step = 0;
                double function = Math.Pow(1 + x, -2);
                double sum = 0;
                if (SumAlgorithm(x, accuracy, ref step, function, ref sum))
                    return Tuple.Create(step, sum);
                else
                    //точность не достигнута
                    return null;
            }
        }

        //выполняем алгоритм суммы, пока не достигнем нужной точности
        static bool SumAlgorithm(double x, double accuracy, ref int step, double function, ref double sum)
        {
            while (Math.Abs(function - sum) > accuracy)
            {
                if (Math.Abs(function - sum) > 2)
                    return false;
				//---check--- Опять же неоптимально пересчитывать на каждом шаге степень
                sum += SumFunction(x, step);
                step++;
            }
            return true;
        }

        //функция суммы
        public static double SumFunction(double x, int step)
        {
            var sum = (Math.Pow(-x, step) * (1 + step));
            return sum;
        }
    }
}
