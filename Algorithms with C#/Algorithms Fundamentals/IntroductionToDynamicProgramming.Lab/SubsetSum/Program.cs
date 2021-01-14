using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetSum
{
    class Program
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());

            //var sums = GetAllSums(nums);
            var sumsSet = GetTargetSumSubset(nums);

            if (sumsSet.ContainsKey(target))
            {
                while (target != 0)
                {
                    var number = sumsSet[target];
                    target -= number;
                    Console.WriteLine(number);
                }
            }
        }

        #region Get subset used to get a target sum.
        private static Dictionary<int, int> GetTargetSumSubset(int[] nums)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var num in nums)
            {
                var currentSums = sums.Keys.ToArray();
                foreach (var sum in currentSums)
                {
                    var newSum = sum + num;

                    if (!sums.ContainsKey(newSum))
                    {
                        sums.Add(newSum, num);
                    }
                }
            }

            return sums;
        }
        #endregion

        #region Get all possible sums with a given set.
        private static HashSet<int> GetAllSums(int[] nums)
        {
            var sums = new HashSet<int> { 0 };

            foreach (var num in nums)
            {
                var newSums = new HashSet<int>();

                foreach (var sum in sums)
                {
                    var newSum = sum + num;
                    newSums.Add(newSum);
                }

                sums.UnionWith(newSums);
            }

            return sums;
        }
        #endregion
    }
}
