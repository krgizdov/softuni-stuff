using System;

namespace CombinationsWithoutRepetition
{
    class Program
    {
        private static int[] combinations;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            combinations = new int[k];

            Combinations(0, 1, n);
        }

        private static void Combinations(int index, int combIdx, int n)
        {
            if (index == combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = combIdx; i <= n; i++)
            {
                combinations[index] = i;
                Combinations(index + 1, i + 1, n);
            }
        }
    }
}
