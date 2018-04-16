using System;
namespace PatienceSorting
{
    //ячейка в связной стопке
    public class Node
    {
        //значение
        public int Value;

        //ссылка на следующую ячейку
        public Node Next { get; set; }

        //инициализация
        public Node(int a)
        {
            Value = a;
        }
    }
}
