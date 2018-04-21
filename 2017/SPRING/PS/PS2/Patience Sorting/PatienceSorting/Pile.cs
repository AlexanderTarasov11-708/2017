using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatienceSorting
{
    //стопка
    public class Pile : IEnumerable<Node>, IComparable
    {
        public int incr;
        public Node Head;

        //пустая инициализация
        public Pile() { }
        

        //инициализация по значению
        public Pile(int value)
        {
            Head = new Node(value, incr++);
        }

        //добавить элемент в список по индексу
        public void Add(int index, int value)
        {
            var newPlayer = new Node(value, incr++);
            if (index == 0)
                Head = newPlayer;
            else
            {
                var prev = GetNode(index - 1);
                var next = prev.Next;

                prev.Next = newPlayer;
                newPlayer.Next = next;
            }
        }

        //  найти и вернуть элемент в списке по индексу
        public Node GetNode(int index)
        {
            if (index < 0)
                return null;
            var res = Head;
            for (int i = 0; i < index; i++)
                res = res.Next;
            return res;
        }

        //  проход по всем элементам списка
        public IEnumerator<Node> GetEnumerator()
        {
            var node = Head;
            if (node != null)
            {
                while (node != null)
                {
                    yield return node;
                    node = node.Next;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // кол-во элементов в списке
        public int Length()
        {
            var i = 0;
            foreach (var elem in this)
                i++;
            return i;
        }

        public int CompareTo(object obj)
        {
            var pile = (Pile)obj;
            return Head.Value.CompareTo(pile.Head.Value);
        }

        //первое значение в кортеже индекс, второе итерации
        public Tuple<int,int> BinarySearchRow(int x)
        {
            //левая граница
            var left = 0;
            //правая граница
            var right = Length();
            //итерации
            var iterations = 0;
            //середина рассматриваемого отрезка
            var mid = left + (right - left) / 2;
            // Если просматриваемый участок не пуст, first < last
            while (left < right)
            {
                //сужаем рассматриваем отрезок в нужную сторону (правую/левую)
                if (x >= GetNode(mid).Value)
                    right = mid;
                else
                    left = mid + 1;
                mid = left + (right - left) / 2;
                //итерация самого вложенного цикла
                iterations++;
            }
            return new Tuple<int,int>(mid,iterations);
        }
    }


}
