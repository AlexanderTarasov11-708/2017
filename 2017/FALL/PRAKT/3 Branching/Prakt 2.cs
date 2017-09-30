using System;

namespace Rectangles
{
    public static class RectanglesTask
    {
        
        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            // так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top

            return      //сначала по горизонтали 
                ((IntersectionRegion(LeftRectLeftPoint(r1, r2), LeftRectRightPoint(r1, r2), RightRectLeftPoint(r1, r2), RightRectRightPoint(r1, r2)) >= 0) &&
                        //затем по вертикали    
                (IntersectionRegion(TopRectTopPoint(r1, r2), TopRectBottomPoint(r1, r2), BottomRectTopPoint(r1, r2), BottomRectBottomPoint(r1, r2)) >= 0));
        }

        // нахождение длины пересечения 2 отрезков
        static double IntersectionRegion(double a, double b, double c, double d)
        {
            return Math.Min(b, d) - Math.Max(a, c);
        }
        
        // Методы для лучшего понимания кода
        // Левая точка левого прямоугольника
        public static double LeftRectLeftPoint(Rectangle r1, Rectangle r2)
        {
            return Math.Min(r1.Left, r2.Left);
        }
        // Правая точка левого прямоугольника
        public static double LeftRectRightPoint(Rectangle r1, Rectangle r2)
        {
            return Math.Min(r1.Right, r2.Right);
        }
        //и т.д.
        public static double RightRectLeftPoint(Rectangle r1, Rectangle r2)
        {
            return Math.Max(r1.Left, r2.Left);
        }

        public static double RightRectRightPoint(Rectangle r1, Rectangle r2)
        {
            return Math.Max(r1.Right, r2.Right);
        }

        private static double TopRectTopPoint(Rectangle r1, Rectangle r2)
        {
            return Math.Min(r1.Top, r2.Top);
        }

        private static double TopRectBottomPoint(Rectangle r1, Rectangle r2)
        {
            return Math.Min(r1.Bottom, r2.Bottom);
        }

        private static double BottomRectTopPoint(Rectangle r1, Rectangle r2)
        {
            return Math.Max(r1.Top, r2.Top);
        }

        private static double BottomRectBottomPoint(Rectangle r1, Rectangle r2)
        {
            return Math.Max(r1.Bottom, r2.Bottom);
        }
        //


        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            if (AreIntersected(r1, r2))
            {
                //внутренние кордиты это минимальные координаты точек (left, right, top, bottom)
                double interWidth = LeftRectRightPoint(r1,r2) - RightRectLeftPoint(r1, r2);
                double interHeight = TopRectBottomPoint(r1, r2) - BottomRectTopPoint(r1, r2);
                return Convert.ToInt32((interHeight * interWidth));
            }
            return 0;               //они не пересекаются
        }

        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            if (CheckForInner(r1, r2))
                return 0;                               //r1 внутри r2
            else if (CheckForInner(r2, r1))
                return 1;                               //r2 внутри r1
            return -1;                                  //оба не внутри
        }

        //проверка на то, что r1 в r2
        public static bool CheckForInner(Rectangle r1, Rectangle r2)     
        {
            return ((r1.Left >= r2.Left) && (r1.Right <= r2.Right) &&
                (r1.Top >= r2.Top) && (r1.Bottom <= r2.Bottom));
        }
    }
}