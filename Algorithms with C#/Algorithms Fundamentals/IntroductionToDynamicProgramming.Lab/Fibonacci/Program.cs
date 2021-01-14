using System;
using System.Collections.Generic;

namespace Fibonacci
{
    class Program
    {
        private static readonly Dictionary<int, long> _cache = new Dictionary<int, long>();

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var nthFibonacci = Fibonacci(n);

            Console.WriteLine(nthFibonacci);
        }

        private static long Fibonacci(int n)
        {
            if (_cache.ContainsKey(n))
            {
                return _cache[n];
            }

            if (n == 0)
            {
                return 0;
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            var result = Fibonacci(n - 2) + Fibonacci(n - 1);
            _cache[n] = result;

            return result;
        }
    }
}
