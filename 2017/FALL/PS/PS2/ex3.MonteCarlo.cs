using System;

namespace ex
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine();
        }

        //сравнение результата, полученного с помощью формулы Монте-Карло, 
        //  и данного в условия значения
        static double Comparison(double result)
        {
            double given = 0.647199;
            return Math.Abs(result - given);
        }

        //вычисление интеграла по формуле Монте-Карло
        //a - левая граница
        //b - правая граница
        //n - число отрезков
        static double MonteCarlo(double a, double b, double n)
        {
            double h = (b - a) / n;
            double result = 0;
            for (int i = 1; i <= n; i++)
                result += Function(a + h * i);
            result *= h;
            return result;
        }

        //подинтегральная функция
        //в отдельный момент, чтобы можно было удобно заменить на другую
        static double Function(double x)
        {
            return -Math.Sin(Math.Tan(x));
        }
    }
}
