using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex
{
    public enum Figure
    {
        Elephant, Horse, Rook, Queen, King
    }

    class Program
    {

        static void Main(string[] args)
        {
            //Cond1
            //
            Console.Write("Enter 1st cell coordinates: ");
            string cell0 = Console.ReadLine();
            Console.Write("Enter 2nd cell coordinates: ");
            string cell1 = Console.ReadLine();
            Console.Write("Enter type of figure: ");
            Figure typeOfFigure = (Figure)Enum.Parse(typeof(Figure), Console.ReadLine());

            TestMove(cell0, cell1, typeOfFigure);
        }

        public static void TestMove(string from, string to, Figure typeOfFigure)
        {
            Console.WriteLine("{0}-{1} {2}", from, to, IsCorrectMove(from, to, typeOfFigure));
        }

        public static bool IsCorrectMove(string from, string to, Figure typeOfFigure)
        {
            var dx = Math.Abs(to[0] - from[0]); //смещение фигуры по горизонтали
            var dy = Math.Abs(to[1] - from[1]); //смещение фигуры по вертикали


            switch (typeOfFigure)
            {
                //слон
                case Figure.Elephant:
                    {
                        return ((dx == 0 && dy != 0) || (dy == 0 && dx != 0));
                    }
                //лошадь    
                case Figure.Horse:
                    {
                        return ((dx == 1 && dy == 2) || (dy == 1 && dx == 2));
                    }
                //ладья
                case Figure.Rook:
                    {
                        return (dx == dy && dx != 0);
                    }
                //ферзь
                case Figure.Queen:
                    {
                        return (dx == dy && dy != 0) || ((dx == 0 && dy != 0) || (dy == 0 && dx != 0));
                    }
                //король
                case Figure.King:
                    {
                        return ((dx == 1 & dy == 0) || (dx == 0 && dy == 1));
                    }
            }

            return false;
        }
    }
}