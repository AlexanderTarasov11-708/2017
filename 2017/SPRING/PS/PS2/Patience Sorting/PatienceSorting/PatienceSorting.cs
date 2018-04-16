using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var flag = false;
                var i = 0;
                while (!flag)
                {
                    //если переходим на новую стопку в списке
                    if (i == piles.Count)
                    {
                        AddNewPile(x);
                        flag = true;
                    }
                    else
                    {
                        //если первое значение в стопке <= данного, спускаемся по этой стопке
                        if (x <= piles[i].Head.Value)
                        {
                            for (int j = 0; j < piles[i].Length(); j++)
                            {
                                //если значение <= данного и (>= следующего или данное последнее в стопке), добавляем
                                if ((x <= piles[i].GetNode(j).Value &&
                                    ((piles[i].Length() == j + 1) || x >= piles[i].GetNode(j + 1).Value))
                                        || piles[i].GetNode(j).Next == null)
                                {
                                    iterations++;
                                    piles[i].Add(j + 1, x);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                    i++;
                }
            }

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
