using System;
using System.IO;
using System.Collections.Generic;

namespace PatienceSorting
{
    public class Program
    {
        //проверка
        static void Main(string[] args)
        {
            var readPath = new StreamReader("data.txt");

            try
            {
                var array = DecodeText(readPath.ReadLine());
                var sorting = new PatienceSorting();
                DateTime time = DateTime.Now;
                var sortedArray = sorting.Sort(array).ToArray();
                //время работы программы
                var measureTime = (DateTime.Now - time).TotalMilliseconds;  
                //кол-во итераций
                var sortIterations = sorting.iterations;
                readPath.Close();
            }
            // если неправильные входные данные вывести сообщение
            catch (FormatException)
            {
                Console.WriteLine("Во входном текстовом файле должны быть числа");
            }
        }

        // Обработка ввода из текстового файла
        public static int[] DecodeText(string path)
        {
            //разделение по пробелам
            var stringNumbers = path.Split(' ');
            var result = new int[stringNumbers.Length];
            //парсинг по элементам
            for (int i = 0; i < result.Length; i++)
                result[i] = int.Parse(stringNumbers[i]);
            return result;
        }
    }
}
