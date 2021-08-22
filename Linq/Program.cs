using System;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main()
        {
            Exercise1();
            Exercise2();
            Exercise3();
        }

        private static void Exercise1()
        {
            var arr1 = new[] {3, 9, 2, 8, 6, 5};
            var query =
                from num in arr1
                where num * num > 20
                select new
                {
                    Number = num,
                    SqrNo = num * num
                };

            var method = arr1.Where(n => n * n > 20).Select(n => new {Number = n, SqrNo = n * n});
            Console.WriteLine("Query syntax:");
            foreach (var x in query)
            {
                Console.WriteLine($"Number: {x.Number}, SqrNo: {x.SqrNo}");
            }

            Console.WriteLine("Method syntax:");
            foreach (var x in method)
            {
                Console.WriteLine($"Number: {x.Number}, SqrNo: {x.SqrNo}");
            }
        }

        private static void Exercise2()
        {
            var letters = new[] { "X", "Y" };
            var numbers = new[] { 1, 2 };
            var colours = new[] { "Green", "Orange" };

            var productsByQuery = from l in letters
                from n in numbers
                from c in colours
                select new {l, n, c};

            var productsByMethod =
                letters.SelectMany(l => numbers.SelectMany(n => colours.Select(c => new {l, n, c})));

            Console.WriteLine("Query syntax:");
            foreach (var x in productsByQuery)
            {
                Console.WriteLine($"{x.l} {x.n} {x.c}");
            }

            Console.WriteLine("Method syntax:");
            foreach (var x in productsByMethod)
            {
                Console.WriteLine($"{x.l} {x.n} {x.c}");
            }
        }

        private static void Exercise3()
        {
            int[] arr1 = new int[] { 5, 9, 1, 5, 5, 9 };

            var query =
                from num in arr1
                group num by num into groups
                select new
                {
                    groups.Key,
                    Count = groups.Count()
                };

            var method = arr1.GroupBy(n => n).Select(group => new {group.Key, Count = group.Count()});

            Console.WriteLine("Query syntax:");
            foreach (var x in query)
            {
                Console.WriteLine($"Number: {x.Key}, Count: {x.Count}");
            }

            Console.WriteLine("Method syntax:");
            foreach (var x in method)
            {
                Console.WriteLine($"Number: {x.Key}, Count: {x.Count}");
            }
        }
    }
}
