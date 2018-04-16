using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatienceSorting
{
    public class Program
    {
        //проверка
        static void Main(string[] args)
        {
            var arr = new int[] { 4, 2, 2, 3, 5, 6, 1 };
            var sorting = new PatienceSorting();
            var sorted = sorting.Sort(arr);
            Console.WriteLine();
        }
    }

    //класс с терпеливой сортировкой
    class PatienceSorting
    {
        //список стопок
        private List<Pile> piles;

        //конструктор
        public PatienceSorting()
        {
            piles = new List<Pile>();
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
                    //если первое значение в стопке <= данного, спускаемся по этой стопке
                    if (x <= piles[i].Head.Value)
                    {
                        for (int j = 0; j < piles[i].Length(); j++)
                        {
                            //если значение <= данного и (>= следующего или данное последнее в стопке), добавляем
                            if ((x <= piles[i].GetNode(j).Value && 
                                ((piles[i].Length() == j+1) || x >= piles[i].GetNode(j + 1).Value)) 
                                    || piles[i].GetNode(j).Next == null)
                            {
                                piles[i].Add(j+1,x);
                                flag = true;
                                break;
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
    }
}
