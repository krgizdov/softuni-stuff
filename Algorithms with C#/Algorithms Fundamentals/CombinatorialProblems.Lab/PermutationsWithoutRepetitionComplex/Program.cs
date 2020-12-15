using System;

namespace PermutationsWithoutRepetitionComplex
{
    class Program
    {
        private static string[] elements;

        static void Main()
        {
            elements = Console.ReadLine().Split();

            Permute(0);
        }

        private static void Permute(int permutationsIndx)
        {
            if (permutationsIndx >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(permutationsIndx + 1);

            for (int i = permutationsIndx + 1; i < elements.Length; i++)
            {
                Swap(permutationsIndx, i);
                Permute(permutationsIndx + 1);
                Swap(permutationsIndx, i);
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
