using System;
using System.Collections.Generic;

namespace GameRing
{
    
    public class RingList : IEnumerable<Player>, ICloneable
    {
        public Player Head;
        public Player Current;
        public Player Tail;
        public int PlayerCount;

        //пустая инициализация
        public RingList() { }

        //  инициализация, аргумент - пол первого игрока
        //  аргумент:
        //  'M' - мужской пол / 0
        //  'F' - женский пол / 1
        public RingList(char age)
        {
            Head = new Player(PlayerCount++, age);
            Head.Next = Head;
            Initialization();
        }

        //инициализация по объекту игрока
        public RingList(Player player)
        {
            Head = player;
            Head.Next = Head;
            Initialization();
        }

        private void Initialization()
        {
            Current = Head;
            Tail = Head;
        }

        public void MoveNext()
        {
            Current = Current.Next;
        }

        //добавить игрока в список по полу
        public void Add(char value)
        {
            var newPlayer = new Player(PlayerCount++, value);
            Add(newPlayer);
        }

        //добавить игрока в список
        public void Add(Player newPlayer)
        {
            if (Head == null)
            {
                Head = newPlayer;
                Head.Next = Head;
                Initialization();
            }
            else
            {
                Tail.Next = newPlayer;
                Tail = newPlayer;
                Tail.Next = Head;
            }
        }

        //добавить игрока в список по полу и значению
        public void Add(int index, char value)
        {
            var newPlayer = new Player(PlayerCount++, value);
            AddPlayerObject(index, newPlayer);
        }

        //добавить игрока в список по значению
        public void AddPlayerObject(int index, Player newPlayer)
        {
            if (index == 0)
            {
                newPlayer.Next = Head;
                Head = newPlayer;
            }
            else
            {
                var prev = GetPlayer(index - 1);
                var next = prev.Next;

                prev.Next = newPlayer;
                newPlayer.Next = next;
            }
        }

        //  найти и вернуть игрока в списке по индексу
        //  если запрашиваемый индекс больше количества игроков, поиск продолжает идти по кругу
        public Player GetPlayer(int index)
        {
            if (index < 0)
                return null;
            var res = Head;
            for (int i=0;i< index; i++)
                res = res.Next;
            return res;
        }

        //  проход по всем элементам списка без повторений
        public IEnumerator<Player> GetEnumerator()
        {
            var player = Head;
            if (player != null)
            {
                while (true)
                {
                    yield return player;
                    player = player.Next;
                    if (player == Head)
                        break;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //очистить кольцевой список
        public void Clear()
        {
            PlayerCount = 0;
            Head = null;
            Current = null;
            Tail = null;
        }

        //удалить игрока из списка по индексу
        public void Remove(int index)
        {
            var prev = GetPlayer(index - 1);
            if (prev == null)
                prev = Tail;
            RemoveNextPlayerTo(prev);
            if (Tail != null)
                Head = Tail.Next;
        }

        //удалить следующий элемент в списке от заданного
        public void RemoveNextPlayerTo(Player prev)
        {
            if (Length() == 1)
                Clear();
            if (Length() == 2)
                prev.Next = prev.Next;
            if (prev.Next == Tail)
                Tail = prev;
            var next = prev.Next.Next;
            prev.Next = next;
        }

        //создать новый список из текущего и списка, данного в аргументе
        public RingList Merge(RingList list)
        {
            var mergedList = (RingList) Clone();
            mergedList.Tail.Next = list.Head;
            mergedList.Tail = list.Tail;
            mergedList.Tail.Next = mergedList.Head;
            return mergedList;
        }

        //реализация клонирования
        public object Clone()
        {
            var clone = new RingList
            {
                Head = Head,
                Current = Head,
                PlayerCount = PlayerCount,
                Tail = Tail
        };
            return clone;
        }

        // кол-во элементов в списке
        public int Length()
        {
            var i = 0;
            foreach (var elem in this)
                i++;
            return i;
        }

        //разделить список на 2 списка женщин и мужчин
        // возвращается Tuble
        // Item1 - список мужчин
        // Item2 - список женщин
        public Tuple<RingList, RingList> SeparateGender(int index)
        {
            var maleList = new RingList();
            var femaleList = new RingList();

            var begin = GetPlayer(index);
            var currentPlayer = begin;

            while (true)
            {
                var tmp = currentPlayer.Copy();
                if (tmp.Gender == 0)
                    maleList.Add(tmp);
                else
                    femaleList.Add(tmp);
                currentPlayer = currentPlayer.Next;
                if (currentPlayer == begin)
                    break;
            }
            return Tuple.Create(maleList, femaleList);
        }

        //  сортировка по полу, в качестве начального элемента выбирается элемент по индексу
        //  true - если сначала мужчины
        //  false - если сначала женщины
        public RingList Sort(int index, bool male)
        {
            var tuple = SeparateGender(index);
            if (male)
                return tuple.Item1.Merge(tuple.Item2);
            else
                return tuple.Item2.Merge(tuple.Item1);
        }

        // удаление каждого k-го элемента со смыканием круга
        // цикл работает до того момента, как остаётся один элемент
        // метод его возвращает
        public Player DeleteEveryK (int index)
        {
            var res = (RingList) Clone();
            var i = 1;
            while (res.Length() > 1)
            {
                if ((i + 1) % index == 0)
                    res.RemoveNextPlayerTo(res.Current);
                else
                    res.MoveNext();
                i++;
            }

            return res.Head;
        }
    }
}
