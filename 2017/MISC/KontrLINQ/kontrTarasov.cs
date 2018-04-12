using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kontrTarasov
{
    class Program
    {
        //Task14
        //Method syntax
        public static IEnumerable<string> Task14Method(IEnumerable<string> a, IEnumerable<string> b)
        {
            return a
                .SelectMany(q => b.Where(
                                    w => w.Where(x => x == 'q') == q.Where(y => y == 'q')) //проверка на одинаковое кол-во 'q'
                                    .Select(w => q + "." + w))
                                    .SelectMany(q => b.Where(
                           w => w.Where(x => x == 'q') != q.Where(y => y == 'q'))           //проверка на неодинаковое кол-во 'q'
                                    .Select(w => q + ".!"))
                      .OrderByDescending(x => x);           //сортировка в обратном порядке
        }

        //Query syntax
        public static IEnumerable<string> Task14Query(IEnumerable<string> a, IEnumerable<string> b)
        {
            return from e1 in a         //строки (е1) из а
                   from char1 in e1        //символы из е1
                   where char1 == 'q'      //строки e1 только с q

                   from e2 in b            //строки (е2) из b
                   from char2 in e2        //символы из е2
                   where char2 == 'q'      //строки e2 только с q

                   where e2.Contains(e1)   //строки е2 содержащие одинаковое колво q 
                   select e1 + "." + e2
                   ?? e1 + ".!";

                   //неправильное решение
        }

        //Task24
        public static IEnumerable<Tuple<T, T>> Partition<T>(IEnumerable<T> a, Func<Tuple<T, T>, bool> func)
        {
            return a
                .SelectMany
                    (q => a.Select(w => Tuple.Create(q, w))) //сначала создаются пары
                .Where(w => func(w));                       //отбираются пары по функции
        }

        //Task31
        static IEnumerable<int> Task31(IEnumerable<int> a)
        {
            return a
                .Take()
                .Concat(
                    
                );
        }


        static void Main(string[] args)
        {
        }
    }
}
