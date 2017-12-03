using System;
using System.Collections.Generic;

namespace ex
{
    //Тарасов Александр 11-708
    //Вариант 18
    public class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var dictionary = GetDictionary(n);
            n = int.Parse(Console.ReadLine());
            Loop(n,dictionary);
            Console.WriteLine();
        }

        //создаю словарь слов и их частоты
        static Dictionary<string,int> GetDictionary(int n)
        {
            var result = new Dictionary<string,int>();
            for (int i=0; i<n; i++)
            {
                var tmp = Console.ReadLine();
                var index = tmp.IndexOf(' ');
                var key = tmp.Substring(0, index);
                var value = int.Parse(tmp.Substring(index + 1));
                result.Add(key, value);
            }
            return result;
        }
        
        //цикл
        static void Loop(int numberOfQueries, Dictionary<string,int> dict)
        {
            for (int i=0; i<numberOfQueries; i++)
            {
                var tmp = Console.ReadLine();
                GetWords(tmp,dict);
                Console.WriteLine();
            }
        }

        //создаю словарь нужных слов и вывожу
        static void GetWords(string begin, Dictionary<string,int> dict)
        {
            var tmpDict = new Dictionary<string, int>();
            foreach (var e in dict)
                if (e.Key.StartsWith(begin))
                    tmpDict.Add(e.Key,e.Value);
            var i = 0;
            while (tmpDict.Count > 0 || i>10)
            {
                //вывожу максимальное, удаляю его, ищу новое
                var tmp = GetMax(tmpDict);
                Console.WriteLine(tmp);
                tmpDict.Remove(tmp);
                i++;            //не должно быть больше 10
            }
        }

        //нахожу слово с максимальной частотой в словаре
        static string GetMax(Dictionary<string,int> dict)
        {
            var max = -1;
            string maxElement = "";
            foreach (var e in dict)
                if (e.Value > max)
                {
                    max = e.Value;
                    maxElement = e.Key;
                }
            return maxElement;
        }
    }
}
