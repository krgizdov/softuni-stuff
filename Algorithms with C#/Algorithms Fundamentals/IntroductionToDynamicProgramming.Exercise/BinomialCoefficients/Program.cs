using System;
using System.Collections.Generic;

namespace BinomialCoefficients
{
    class Program
    {
        private static readonly Dictionary<string, long> _cache = new Dictionary<string, long>();

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            var result = GetBinom(n, k);

            Console.WriteLine(result);
        }

        private static long GetBinom(int n, int k)
        {
            var id = $"{n} {k}";

            if (_cache.ContainsKey(id))
            {
                return _cache[id];
            }

            if (k == 0 || k == n)
            {
                return 1;
            }

            var result = GetBinom(n - 1, k) + GetBinom(n - 1, k - 1);

            _cache[id] = result;

            return result;
        }
    }
}
