using System;
using System.Linq;

namespace SubsetSumWithRepetition
{
    class Program
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());

            var sums = new bool[target + 1];
            sums[0] = true;

            for (int sum = 0; sum < sums.Length; sum++)
            {
                if (sums[sum])
                {
                    foreach (var num in nums)
                    {
                        var newSum = sum + num;

                        if (newSum <= target)
                        {
                            sums[newSum] = true;
                        }
                    }
                }
            }

            while (target > 0)
            {
                foreach (var num in nums)
                {
                    var prev = target - num;

                    if (prev >= 0 && sums[prev])
                    {
                        Console.WriteLine(num);
                        target = prev;
                    }
                }
            }
        }
    }
}
