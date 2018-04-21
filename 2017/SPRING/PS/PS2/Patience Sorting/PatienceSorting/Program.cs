using System;
using System.IO;
using System.Collections.Generic;

namespace PatienceSorting
{
    public class Program
    {
        //проверка
        public static void Main(string[] args)
        {
            var timeArray = new Dictionary<int, double>();
            var iterations = new Dictionary<int, int>();
            var timeString = "";
            var iterationString = "";

            for (int i=100; i<=10000; i+=50 )
            {
                FillInput(i);
                var readPath = new StreamReader("data.txt");

                try
                {
                    var array = DecodeText(readPath.ReadLine());
                    var sorting = new PatienceSorting();
                    DateTime time = DateTime.Now;
                    var sortedArray = sorting.Sort(array).ToArray();
                    //время работы программы
                    var measureTime = (DateTime.Now - time).TotalMilliseconds;
                    timeArray[i] = measureTime;
                    //кол-во итераций
                    var sortIterations = sorting.iterations;
                    iterations[i] = sortIterations;

                    timeString+= timeArray[i] + "\r\n";
                    iterationString += iterations[i] + "\r\n";
                }
                // если неправильные входные данные вывести сообщение
                catch (FormatException)
                {
                    Console.WriteLine("Во входном текстовом файле должны быть числа");
                }
                readPath.Close();
            }

            var writePath1 = new StreamWriter("time.txt");
            writePath1.WriteLine(timeString);
            var writePath2 = new StreamWriter("iterations.txt");
            writePath2.WriteLine(iterationString);
            writePath1.Close();
            writePath2.Close();
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

        public static void FillInput(int arraySize)
        {
            Random rnd = new Random();
            string input = "";
            var writePath = new StreamWriter("data.txt");

            input += rnd.Next();
            for (int i = 1; i < arraySize; i++)
                input += " " + rnd.Next();
            writePath.WriteLine(input);
            writePath.Close();
        }
    }
}
