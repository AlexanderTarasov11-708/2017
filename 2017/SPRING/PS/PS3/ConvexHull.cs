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
            QuickSort(indexArray, list, 1, n - 1);

            //создаём стек
            var resList = new List<int>();
            resList.Add(indexArray[0]);
            resList.Add(indexArray[1]);
            //проходимся по всем вершинам и удаляем те из них, в которых 
            //  новая выбранная точка левее линии, образованной последними 2 точками в результирующем списке
            for (var i = 2; i < n; i++)
            {
                while (Rotate(list[resList.ElementAt(resList.Count - 2)], list[resList.ElementAt(resList.Count - 1)], list[indexArray[i]]) < 0)
                {
                    resList.Remove(resList.Last());
                    if (resList.Count == 1)
                        break;
                }
                resList.Add(indexArray[i]);
            }

            return FromIntToPoint(resList, list);
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
                    indexArray.RemoveAt(right);
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
                array.Add(i);
            return array;
        }

        //ф-ция определяет, с какой стороны от вектора AB находится точка C 
        //положительное возвращаемое значение соответствует правой стороне, отрицательное — левой (по часовой стрелке)
        public static double Rotate(Point A, Point B, Point C)
        {
            var res = (B.X - A.X) * (C.Y - B.Y) - (B.Y - A.Y) * (C.X - B.X);
            return res;
        }

        //замена местами двух элементов списка
        public static void Swap(int left, int right, List<int> array)
        {
            var temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }

        //быстрая сортировка
        public static void QuickSort(List<int> arr, List<Point> points, int first, int last)
        {
            //опорный элемент
            var p = (last - first) / 2 + first;
            var i = first;
            var j = last;
            while (i <= j)
            {
                //сортируем элементы левее опорного
                while (Rotate(points[arr[0]], points[arr[p]], points[arr[i]]) < 0 && i <= last)
                    ++i;
                //...правее опорного
                while (Rotate(points[arr[0]], points[arr[p]], points[arr[j]]) > 0 && j >= first)
                    --j;
                if (i <= j)
                {
                    Swap(i, j, arr);
                    ++i; --j;
                }
            }
            //рекурсивно сортируем до итогового вида
            if (j > first) QuickSort(arr, points, first, j);
            if (i < last) QuickSort(arr, points, i, last);
        }
    }
}
