using System;

namespace CombinationsWithRepetition
{
    class Program
    {
        private static string[] elements;
        private static string[] combinations;
        static void Main()
        {
            elements = Console.ReadLine().Split();
            int k = int.Parse(Console.ReadLine());

            combinations = new string[k];

            Combinations(0, 0);
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
                Combinations(combIdx + 1, i);
            }
        }
    }
}
