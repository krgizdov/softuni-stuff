using System;
using System.Collections.Generic;
using System.Linq;

namespace SetCover
{
    class Program
    {
        static void Main()
        {
            var universe = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            var setAmount = int.Parse(Console.ReadLine());

            var sets = new List<int[]>();
            for (int i = 0; i < setAmount; i++)
            {
                sets.Add(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            }

            var selectedSets = new List<int[]>();
            while (universe.Count > 0)
            {
                var currentSet = sets
                  .OrderByDescending(s => s.Count(e => universe.Contains(e)))
                  .FirstOrDefault();

                foreach (var number in currentSet)
                {
                    universe.Remove(number);
                }

                sets.Remove(currentSet);
                selectedSets.Add(currentSet);
            }

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (var set in selectedSets)
            {
                Console.WriteLine(string.Join(", ", set));
            }
        }
    }
}
