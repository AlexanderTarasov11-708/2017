namespace ps
{
    class Sorts
    {
        //подсчёт итераций
        public static int ShellSortIterations = 0;
        public static int InsertionSortIterations = 0;

        //сортировка Шелла
        public static void ShellSort(int[] array)
        {
            int j;
            //сравнение элементов на расстоянии
            int distance = array.Length / 2;
            //пока distance не сузится до 0
            while (distance > 0)
            {
                for (var i = 0; i < (array.Length - distance); i++)
                {
                    j = i;
                    while ((j >= 0) && (array[j] > array[j + distance]))
                    {
                        //перемена местами элементов, если первый > второго
                        Swap(array[j], array[j + distance]);
                        j -= distance;
                        //инкрементирование итерации в самом вложенном цикле
                        ShellSortIterations++;
                    }
                }
                distance = distance / 2;
            }
        }

        //сортировка вставками
        public static void InsertionSort(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                //вложенный цикл
                var j = i;
                while (j > 0)
                {
                    if (array[j - 1] > array[j])
                    {
                        //перемена местами элементов, если первый > второго
                        Swap(array[j - 1], array[j]);
                        j--;
                        //инкрементирование итерации в самом вложенном цикле
                        InsertionSortIterations++;
                    }
                    else
                        break;
                }
            }
        }

        //перестановка 2 элементов местами
        public static void Swap(int a, int b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
    }

}
