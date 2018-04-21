using System;
namespace PatienceSorting
{
    //ячейка в связной стопке
    public class Node
    {
        //значение
        public int Value;
        public int ID;

        //ссылка на следующую ячейку
        public Node Next { get; set; }

        //инициализация
        public Node(int a, int id)
        {
            Value = a;
            ID = id;
        }
    }
}
