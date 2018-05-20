using System.Collections.Generic;
using System.Linq;

namespace ConvexHull
{
    class Algorithms
    {
        //алгоритм Грэхема
        public static List<Point> Graham(List<Point> list)
        {
            var n = list.Count;
            //список индексов множества точек list
            var indexArray = Range(n);

            //делаем первый элемент списка индексом самой левой вершины из list
            FindLeft(list, indexArray);

            //сортируем список indexArray быстрой сортировкой
            Quicksort(indexArray, list, 1, n);

            //создаём стек
            var stack = new Stack<int>();
            stack.Push(indexArray[0]);
            stack.Push(indexArray[1]);
            //проходимся по всем вершинам и удаляем те из них, в которых угол > 180 градусов
            for (var i=2; i < n; i++)
            {
                while (Rotate(list[stack.ElementAt(stack.Count-2)], list[stack.ElementAt(stack.Count - 1)], list[indexArray[i]]) < 0)
                    stack.Pop();

                stack.Push(indexArray[i]);
            }
            
            return FromIntToPoint(stack.ToList(), list);
        }

        //алгоритм Джарвиса
        public static List<Point> Jarvis(List<Point> list)
        {
            var n = list.Count;
            //список индексов множества точек list
            var indexArray = Range(n);

            //делаем первый элемент списка индексом самой левой вершины из list
            FindLeft(list, indexArray);
            //результирующий список индексов множества точек list
            var resultIndex = new List<int>();
            //добавляем первый элемент списка индексов в результирующий
            resultIndex.Add(indexArray[0]);
            //удаляем его из indexArray
            indexArray.RemoveAt(0);
            //добавляем в конец
            indexArray.Add(resultIndex[0]);

            //заполняем результирующий массив самыми правыми точками (по часовой стрелке) относительно текущей
            MostRightPoints(list, indexArray, resultIndex);

            return FromIntToPoint(resultIndex, list);
        }

        //  цикл, на каждой итерации которого ищем самую правую точку (по часовой стрелке)
        //      из indexArray относительно последней вершины в resultIndex.
        //  цикл прерывается, когда текущей снова оказывается стартовая вершина
        public static void MostRightPoints(List<Point> list, List<int> indexArray, List<int> resultIndex)
        {
            while (true)
            {
                var right = 0;
                for (var i = 1; i < indexArray.Count; i++)
                {
                    if (Rotate(list[resultIndex.Last()], list[indexArray[right]], list[indexArray[i]]) < 0)
                        right = i;
                }
                //прерывается, когда текущей снова оказывается стартовая вершина
                if (indexArray[right] == resultIndex[0])
                    break;
                else
                {
                    //добавляем индекс в конечный список индексов
                    resultIndex.Add(indexArray[right]);
                    //удаляем его из исходного
                    indexArray.Remove(right);
                }
            }
        }

        //нахождение самое левой вершины в списке
        public static void FindLeft(List<Point> list, List<int> indexArray)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (list[indexArray[i]].X < list[indexArray[0]].X)
                    Swap(i, 0, indexArray);
            }
        }

        //список точек из списка индексов массива точек
        public static List<Point> FromIntToPoint(List<int> indexes, List<Point> points)
        {
            var res = new List<Point>();
            foreach (var elem in indexes)
                res.Add(points[elem]);
            return res;
        }

        //создание списка порядковых номер размеров n
        public static List<int> Range(int n)
        {
            var array = new List<int>();
            for (var i = 0; i < n; i++)
                array[i] = i;
            return array;
        }

        //ф-ция определяет, с какой стороны от вектора AB находится точка C 
        //положительное возвращаемое значение соответствует левой стороне, отрицательное — правой
        public static double Rotate(Point A, Point B, Point C)
        {
            return (B.X - A.X) * (C.Y - B.Y) - (B.Y - A.Y) * (C.X - B.X);
        }

        //замена местами двух элементов списка
        public static void Swap(int left, int right, List<int> array)
        {
            var temp = left;
            left = right;
            right = temp;
        }

        // нахождение оптимального опорного элемента
        public static int Partition(List<int> m, List<Point> points, int a, int b)
        {
            var i = a;
            // просматриваем с a по b
            for (var j = a; j <= b; j++)            
            {
                // если элемент m[j] не превосходит m[b],
                if (Rotate(points[m[0]], points[m[j]], points[m[b]]) <= 0)  
                {
                    Swap(m[i], m[j], m);            // меняем местами m[j] и m[i] и т.д.
                                                    // то есть переносим элементы меньшие m[b] в начало,
                                                    // а затем и сам m[b] «сверху»
                    i++;                            // таким образом последний обмен: m[b] и m[i], после чего i++
                }
            }
            return i - 1;                        // в индексе i хранится <новая позиция элемента m[b]> + 1
        }

        // быстрая сортировка
        // a - начало подмножества, b - конец
        public static void Quicksort(List<int> m, List<Point> points, int a, int b)
        {                                        
            if (a >= b) return;
            var c = Partition(m, points, a, b);
            Quicksort(m, points, a, c - 1);
            Quicksort(m, points, c + 1, b);
        }
    }
}
