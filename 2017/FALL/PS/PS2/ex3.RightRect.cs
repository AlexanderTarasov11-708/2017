using System;

namespace ex
{
    public class Program
    {
        //Тарасов Александр 11-708
        //Вариант 17
        //Задача 3 - Правые прямоугольники
        static void Main()
        {
            Console.WriteLine();
        }

        //сравнение результата, полученного с помощью формулы левого прямоугольника, 
        //  и данного в условия значения
        public static double Comparison(double result)
        {
            double given = 0.647199;
            return Math.Abs(result - given);
        }

        //вычисление интеграла по формуле правого прямоугольника
        //a - левая граница
        //b - правая граница
        //n - число отрезков
        public static double RightRectangle(double a, double b, double n)
        {
            double h = (b - a) / n;
            double result = 0;
            for (int i=1; i<=n; i++)
                result += Function(a+h*i);
            result *= h;
            return result;
        }

        //подинтегральная функция
        //в отдельный момент, чтобы можно было удобно заменить на другую
        public static double Function(double x)
        {
            return -Math.Sin(Math.Tan(x));
        }
    }
}
