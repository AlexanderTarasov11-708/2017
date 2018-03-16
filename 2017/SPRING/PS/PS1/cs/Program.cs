using System;
using System.IO;

namespace GameRing
{
    /**
     * @author - Тарасов Александр 11-708
     * Вариант 12 
     * Реализация кольцевого список
     * Класс с демонстрацией функционала и вводом/выводом из текстового файла
     */
    class Program
    {
        static void Main(string[] args)
        {
            var readPath = new StreamReader("data.txt");
            var listFromTextFile = DecodeText(readPath.ReadLine());
            readPath.Close();

            Console.WriteLine("Изначальный список из файла");
            Console.WriteLine(listFromTextFile.StringList()+"\n");

            listFromTextFile.Add(4,'M');
            var writePath = new StreamWriter("data.txt");
            writePath.WriteLine(Encoding(listFromTextFile));
            writePath.Close();

            Console.WriteLine("Добавили мужского игрока на 4 позицию");
            Console.WriteLine(listFromTextFile.StringList() + "\n");

            listFromTextFile.Remove(1);
            writePath = new StreamWriter("data.txt");
            writePath.WriteLine(Encoding(listFromTextFile));
            writePath.Close();

            Console.WriteLine("Удалили игрока на 1 позиции");
            Console.WriteLine(listFromTextFile.StringList() + "\n");

            writePath = new StreamWriter("male.txt");
            var tuple = listFromTextFile.SeparateGender(1);
            writePath.WriteLine(Encoding(tuple.Item1));
            writePath.Close();

            Console.WriteLine("Мужской список");
            Console.WriteLine(tuple.Item1.StringList() + "\n");

            writePath = new StreamWriter("female.txt");
            writePath.WriteLine(Encoding(tuple.Item2));
            writePath.Close();

            Console.WriteLine("Женский список");
            Console.WriteLine(tuple.Item2.StringList() + "\n");

            var merged = tuple.Item1.Merge(tuple.Item2);
            writePath = new StreamWriter("data1.txt");
            writePath.WriteLine(Encoding(merged));
            writePath.Close();

            Console.WriteLine("Объединили 2 списка");
            Console.WriteLine(merged.StringList() + "\n");

            var sorted = listFromTextFile.Sort(1, false);
            writePath = new StreamWriter("data2.txt");
            writePath.WriteLine(Encoding(sorted));
            writePath.Close();

            Console.WriteLine("Сортировали список по полу, сначала женщины");
            Console.WriteLine(sorted.StringList() + "\n");

            var deleted = listFromTextFile.DeleteEveryK(3);
            writePath = new StreamWriter("deleted.txt");
            writePath.WriteLine(deleted.ID);
            writePath.Close();

            Console.Write("Удалили каждый 3й элемент, остался элемент под id ");
            Console.Write(deleted.ID);
            if (deleted.Gender == 0)
                Console.WriteLine(" мужского пола");
            else Console.WriteLine(" женского пола");
        }

        // Обработка ввода из текстового файла
        public static RingList DecodeText(string path)
        {
            var newList = new RingList();
            for (int i = 0; i<path.Length; i++)
            {
                newList.Add(path[i]);
            }
            return newList;
        }

        // Кодирование для вывода в текстовый файл
        public static string Encoding(RingList list)
        {
            var text = "";
            foreach (var elem in list)
                text += elem.GetChar();
            return text;
        }
    }
}
