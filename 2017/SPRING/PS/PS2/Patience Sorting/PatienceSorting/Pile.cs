using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatienceSorting
{
    //стопка
    public class Pile : IEnumerable<Node>
    {
        public Node Head;

        //пустая инициализация
        public Pile() { }
        

        //инициализация по значению
        public Pile(int value)
        {
            Head = new Node(value);
        }

        //добавить элемент в список по индексу
        public void Add(int index, int value)
        {
            var newPlayer = new Node(value);
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
        
    }
}
