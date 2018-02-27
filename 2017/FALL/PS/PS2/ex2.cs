using System;

namespace ex
{
    public class Program
    {
        //Тарасов Александр 11-708
        //Вариант 17
        //Задача 2
        static void Main()
        {
            Console.WriteLine();
        }

        //определяем на каком шаге достигнется точность
        public static Tuple<int, double> DetermineStep(double accuracy)
        {
            if (accuracy < 0.000000000000001)
                //тип double охватывает до 15 разрядов
                return null;
            int step = 0;
            double sum = 0;
            SumAlgorithm(accuracy, ref step, ref sum);
            return Tuple.Create(step, sum);
        }

        //выполняем алгоритм суммы, пока не достигнем нужной точности
        static void SumAlgorithm(double accuracy, ref int step, ref double sum)
        {
            while (Math.Abs(Math.PI - 2 * Math.Pow(3, 0.5) * sum) > accuracy)
            {
                var tmp = sum * 2 * Math.Pow(3, 0.5);
				//---check--- и здесь
                sum += SumFunction(step);
                step++;
            }
            sum *= 2 * Math.Pow(3, 0.5);
        }

        //функция суммы
        public static double SumFunction(int step)
        {
            return (Math.Pow(-1, step) / (Math.Pow(3, step) * (2 * step + 1)));
        }
    }
}
