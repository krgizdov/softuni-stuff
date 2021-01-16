using System;
using System.Collections.Generic;
using System.Linq;

namespace SumWithLimitedCoins
{
    class Program
    {
        static void Main()
        {
            var coins = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());

            var sums = GetCount(coins);

            if (sums.ContainsKey(target))
            {
                Console.WriteLine(sums[target]);
            }
        }
        private static Dictionary<int, int> GetCount(int[] numbers)
        {
            var result = new Dictionary<int, int> { { 0, 1 } };

            foreach (var num in numbers)
            {
                var sums = result.Keys.ToArray();

                foreach (var sum in sums)
                {
                    var newSum = sum + num;
                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, 0);
                    }

                    result[newSum]++;
                }
            }

            return result;
        }

        #region Another implementation with HashSet
        //private static int GetCount(int[] numbers, int target)
        //{
        //    var sums = new HashSet<int> { 0 };
        //    var count = 0;

        //    foreach (var num in numbers)
        //    {
        //        var newSums = new HashSet<int>();

        //        foreach (var sum in sums)
        //        {
        //            var newSum = sum + num;
        //            newSums.Add(newSum);

        //            if (newSum == target)
        //            {
        //                count++;
        //            }
        //        }

        //        sums.UnionWith(newSums);
        //    }

        //    return count;
        //}
        #endregion
    }
}
