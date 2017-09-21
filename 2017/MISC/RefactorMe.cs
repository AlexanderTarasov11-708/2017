using System;
using System.Diagnostics;
using System.Drawing;

namespace RefactorMe
{
    class Drawer
    {
        static Bitmap image = new Bitmap(800, 600);
        static float x, y;
        static Graphics graphics;

        public static void Initialize()
        {
            image = new Bitmap(800, 600);
            graphics = Graphics.FromImage(image);
        }

        public static void SetPos(float x0, float y0)
        {
            x = x0;
            y = y0;
        }

        public static void Go(double length, double angle)
        {
            //Делает шаг длиной L в направлении angle и рисует пройденную траекторию
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graphics.DrawLine(Pens.Yellow, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void ShowResult()
        {
            image.Save("result.bmp");
            Process.Start("result.bmp");
        }
    }

    public class ImpossibleSquare
    {
        public static void Main()
        {
            Drawer.Initialize();

            //Рисуем четыре одинаковые части невозможного квадрата.
            // Часть первая:
            Draw(10,0,0);

            // Часть вторая:
            Draw(120,10,Math.PI / 2);

            // Часть третья:
            Draw(110,120,Math.PI);

            // Часть четвертая:
            Draw(0,110,-Math.PI / 2);

            Drawer.ShowResult();
        }

        private static void Draw(int x, int y, double a)
        {
            Drawer.SetPos(x, y);
            Drawer.Go(100, a);
            Drawer.Go(10 * Math.Sqrt(2), a + Math.PI / 4);
            Drawer.Go(100, a + Math.PI);
            Drawer.Go(100 - (double)10, a + Math.PI / 2);
        }
    }
}