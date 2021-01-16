using System;
using System.Collections.Generic;
using System.Linq;

namespace DividingPresents
{
    class Program
    {
        static void Main()
        {
            var presents = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var sums = GetAllSums(presents);

            var totalScore = presents.Sum();
            var bobScore = GetBobScore(totalScore, sums);
            var alanScore = totalScore - bobScore;

            var alanPresents = GetPresents(alanScore, sums);

            Console.WriteLine($"Difference: {bobScore - alanScore}");
            Console.WriteLine($"Alan:{alanScore} Bob:{bobScore}");
            Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
            Console.WriteLine("Bob takes the rest.");
        }

        private static List<int> GetPresents(int target, Dictionary<int, int> sums)
        {
            var presents = new List<int>();

            while (target != 0)
            {
                var present = sums[target];
                presents.Add(present);

                target -= present;
            }

            return presents;
        }

        private static int GetBobScore(int totalScore, Dictionary<int, int> sums)
        {
            var bobScore = (int)Math.Ceiling(totalScore / 2.0);

            while (!sums.ContainsKey(bobScore))
            {
                bobScore += 1;
            }

            return bobScore;
        }

        private static Dictionary<int, int> GetAllSums(int[] numbers)
        {
            var result = new Dictionary<int, int> { { 0, 0 } };

            foreach (var num in numbers)
            {
                var sums = result.Keys.ToArray();

                foreach (var sum in sums)
                {
                    var newSum = sum + num;
                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, num);
                    }
                }
            }

            return result;
        }
    }
}
