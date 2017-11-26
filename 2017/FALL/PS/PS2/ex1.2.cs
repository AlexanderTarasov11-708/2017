using System;

namespace ex
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine();
        }

        //определяем на каком шаге достигнется точность
        static Tuple<int, double> DetermineStep(int x, double accuracy)
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
        static bool SumAlgorithm(int x, double accuracy, ref int step, double function, ref double sum)
        {
            while (Math.Abs(function - sum) > accuracy)
            {
                if (sum > function + accuracy)
                    //если сумма уходит дальше, точность не достигнута
                    return false;
                sum += SumFunction(x, step);
                step++;
            }
            return true;
        }

        //функция суммы
        private static double SumFunction(int x, int step)
        {
            return (Math.Pow(-x, step) * (1 + step));
        }
    }
}
