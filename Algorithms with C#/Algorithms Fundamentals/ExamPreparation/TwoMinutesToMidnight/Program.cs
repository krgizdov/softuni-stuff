using System;
using System.Collections.Generic;

namespace TwoMinutesToMidnight
{
    class Program
    {
        private static readonly Dictionary<string, long> _cache = new Dictionary<string, long>();

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            var ways = GetBinom(n, k);

            Console.WriteLine(ways);
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
