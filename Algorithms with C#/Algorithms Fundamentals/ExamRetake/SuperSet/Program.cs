using System;
using System.Linq;

namespace SuperSet
{
    class Program
    {
        private static int[] elements;
        private static int[] combinations;

        static void Main()
        {
            elements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            for (int i = 1; i <= elements.Length; i++)
            {
                combinations = new int[i];

                Combinations(0, 0);
            }
        }

        private static void Combinations(int combIdx, int elementsStartIdx)
        {
            if (combIdx >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementsStartIdx; i < elements.Length; i++)
            {
                combinations[combIdx] = elements[i];
                Combinations(combIdx + 1, i + 1);
            }
        }
    }
}
