using System.Collections.Generic;
using System.Linq;

namespace PatienceSorting
{
    //класс с терпеливой сортировкой
    class PatienceSorting
    { 
        public int iterations;
        //список стопок
        private List<Pile> piles;

        //конструктор
        public PatienceSorting()
        {
            iterations = 0;
            piles = new List<Pile>();
            iterations = 0;
        }

        //сортировка в аргументе массив целых чисел
        public List<Pile> Sort(int[] array)
        {
            //поэлементное добавление
            foreach (var item in array)
                PushItem(item);
            return piles;
        }

        //добавление нового элемента в список
        public void PushItem(int x)
        {
            //если список пуст, добавляем в него новую стопку
            if (piles.Count == 0)
                AddNewPile(x);
            else
            {
                var i = 0;
                i = BinarySearchPile(x);

                //если -1, то идти вглубь по стопке не надо, элемент уже добавлен на вершину новой
                if (i != -1)
                {
                    //ищем подходящее место в стопке
                    var tuple = piles[i].BinarySearchRow(x);
                    //накапливаем итерации
                    iterations += tuple.Item2;
                    //добавляем элемент в стопку
                    piles[i].Add(tuple.Item1,x);
                }
            }
        }

        public int BinarySearchPile(int x)
        {
            //левая граница
            var left = 0;
            //правая граница
            var right = piles.Count;
            //середина рассматриваемого отрезка
            var mid = left + (right - left) / 2;
            // Если просматриваемый участок не пуст, first < last
            while (left < right)
            {
                //сужаем рассматриваем отрезок в нужную сторону (правую/левую)
                if (x < piles[mid].Head.Value)
                    right = mid;
                else
                    left = mid + 1;
                mid = left + (right - left) / 2;
            }
            //если больше всех в предыдущих стопках, создаём новую
            if (mid >= piles.Count)
            {
                AddNewPile(x);
                return -1;
            }
            return mid;
        }

        //создание новой стопки по значению
        private void AddNewPile(int x)
        {
            var queue = new Pile(x);
            //добавление в список стопок
            piles.Add(queue);
        }

        //вывод в массив
        public int[] ToArray()
        {
            int count = 0;
            int i = 0;
            foreach (var elem in piles)
                count += elem.Length();
            var array = new int[count];
            foreach (var elem in piles)
                for (int j = elem.Length() - 1; j >= 0; j--)
                    array[i++] = elem.ElementAt(j).Value;
            return array;
        }
    }
}
