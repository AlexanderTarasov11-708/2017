using System;

namespace ex
{
    public class Program
    {
        //Тарасов Александр 11-708
        //Вариант 17
        //Задача 3 - Симпсон
        static void Main()
        {
            Console.WriteLine();
        }

        //сравнение результата, полученного с помощью формулы Симпсона, 
        //  и данного в условия значения
        static double Comparison(double result)
        {
            double given = 0.647199;
            return Math.Abs(result - given);
        }

        //вычисление интеграла по формуле Симпсона
        //a - левая граница
        //b - правая граница
        //n - число отрезков
        public static double Simpson(double a, double b, double n)
        {
            double h = (b - a) / (2 * n);
			var result = (h / 3) * (Function(a) + Sum1(a, n, h) + Sum2(a, n, h) + Function(b));
            return result;
        }

		//---check--- оптимальнее одним циклом решать
        //первая сумма в формуле Симпсона
        private static double Sum1(double a, double n, double h)
        {
            double tmp = 0;
            for (int i = 1; i < n; i++)
                tmp += Function(2 * h * i + a);
            return tmp * 2;
        }

        //вторая сумма в формуле Симпсона
        private static double Sum2(double a, double n, double h)
        {
            double tmp = 0;
            for (int i = 1; i <= n; i++)
                tmp += Function((2 * i - 1) * h + a);
            return tmp * 4;
        }

        //подинтегральная функция
        //в отдельный момент, чтобы можно было удобно заменить на другую
        public static double Function(double x)
        {
            return -Math.Sin(Math.Tan(x));
        }
    }
}
