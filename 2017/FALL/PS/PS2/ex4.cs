using System;

namespace ex
{
    public class Program
    {
        //Тарасов Александр 11-708
        //Вариант 17
        //Задача 4
        static void Main()
        {
            //УСЛОВИЕ!!!
            //первое число(a) должно быть >= второго(b)
            Console.WriteLine();
        }

        //число в массив цифр
        public static int[] ToIntArray(int a)
        {
            int length = GetIntLength(a);
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = a % 10;
                a /= 10;
            }
            return array;
        }

        //количество цифр числа
        private static int GetIntLength(int a)
        {
            int length = 0;
            while (a > 0)
            {
                length++;
                a /= 10;
            }
            return length;
        }

        //наибольший общий делитель
        public static int[] GCD(int[] a, int[] b)
        {
            if (IsZero(b))
                return null;
            while (!IsZero(b))
            {
                var t = (int[])b.Clone();
                b = Divide(a, b).Item2;
                a = (int[])t.Clone();
            }
            return NewReversedArray(a);
        }

        //наименьшее общее кратное
        public static int[] LCM(int[] a, int[] b)
        {
            if (IsZero(b))
                return null;
            var multi = Multiplication(a, b);
            var gcd = NewReversedArray(GCD(a, b));
            var result = Divide(multi, gcd).Item1;
            return NewReversedArray(result);
        }

        //ноль ли a?
        static bool IsZero(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                if (a[i] != 0)
                    return false;
            return true;
        }

        //удаление ненужных нулей из массива
        static int[] RemoveZeros(int[] a)
        {
            if (!IsZero(a))
            {
                int k = 0;
                int i = a.Length - 1;
                while (a[i] == 0)
                {
                    k++;
                    i--;
                }
                if (k > 0)
                {
                    var array = new int[a.Length - k];
                    Array.Copy(a, array, a.Length - k);
                    return array;
                }
            }
            else
                return new[] { 0 }; //если a=0
            return a;
        }

        //произведение, массивы перевёрнутые
        public static int[] Multiplication(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length];
            for (int j = 0; j < b.Length; j++)
                for (int i = 0; i < a.Length; i++)
                {
                    var cr = a[i] * b[j];
                    var k = i + j;
                    while (cr > 0)
                    {
                        cr = cr + c[k];
                        c[k] = cr % 10;
                        cr = cr / 10;
                        k++;
                    }
                }
            c = RemoveZeros(c);
            return c;
        }

        //разность, массивы перевёрнутые
        static int[] Minus(int[] a, int[] b)
        {
            int[] curValue = (int[])a.Clone();
            for (int i = 0; i < b.Length; i++)
            {
                curValue[i] -= b[i];
                if (curValue[i] < 0)
                {
                    curValue[i] += 10;
                    curValue[i + 1]--;
                }
            }
            curValue = RemoveZeros(curValue);
            return curValue;
        }

        //нахождение остатка, массивы перевёрнутые
        public static Tuple<int[], int[]> Divide(int[] a, int[] b)
        {
            var result = new int[0];
            var copyA = (int[])a.Clone();
            int[] aRight;
            var quotient = new int[0];
            while (copyA.Length > 0)
            {
                if (result.Length > 0 && !IsZero(result))
                {   //если уже есть остаток
                    var tmp = b.Length - result.Length;
                    aRight = MergeArrays(PartArray(copyA, tmp), result);
                    copyA = RemoveArrayElements(copyA, tmp);
                }
                else
                {   //если ещё нет остатка
                    aRight = PartArray(copyA, b.Length);
                    if (aRight == null)
                    {
                        quotient = MergeArrays(new int[] { 0 }, quotient);
                        result = PartArray(copyA, 1);
                        break;
                    }
                    copyA = RemoveArrayElements(copyA, b.Length);
                }

                if (copyA.Length > 0 && !LessOrEqual(NewReversedArray(b), NewReversedArray(aRight)))
                {   //ищем необходимый делитель
                    aRight = MergeArrays(new int[] { copyA[copyA.Length - 1] }, aRight);
                    copyA = RemoveArrayElements(copyA, 1);
                }

                for (int j = 9; j >= 0; j--)
                {   //ищем частное
                    var tmp = Multiplication(b, new int[] { j });
                    if (LessOrEqual(NewReversedArray(tmp), NewReversedArray(aRight)))
                    {
                        result = Minus(aRight, tmp);
                        quotient = MergeArrays(new int[] { j }, quotient);
                        break;
                    }
                }
            }
            return Tuple.Create(quotient, result);
        }

        //удалить ненужные элементы
        static int[] RemoveArrayElements(int[] a, int n)
        {
            var array = new int[a.Length - n];
            for (int i = 0; i < a.Length - n; i++)
                array[i] = a[i];
            return array;
        }

        //соединить 2 массива в один
        static int[] MergeArrays(int[] a, int[] b)
        {
            var result = new int[a.Length + b.Length];
            for (int i = 0; i < a.Length; i++)
                result[i] = a[i];
            for (int j = 0; j < b.Length; j++)
                result[a.Length + j] = b[j];
            return result;
        }
        //создание отдельного массива, являющегося заданной частью данного
        static int[] PartArray(int[] a, int length)
        {
            int[] tmpArray = new int[length];
            if (a.Length < length)
                return null;
            Array.Copy(NewReversedArray(a), tmpArray, length);
            return NewReversedArray(tmpArray);
        }

        //создание отдельного массива обратного от данного
        static int[] NewReversedArray(int[] a)
        {
            var tmpArray = (int[])a.Clone();
            Array.Reverse(tmpArray);
            return tmpArray;
        }

        //меньше или равно для массивов в правильном порядке
        static bool LessOrEqual(int[] a, int[] b)
        {
            if (a.Length != b.Length)
                return a.Length < b.Length;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return a[i] < b[i];
            }
            return true;
        }
    }
}
