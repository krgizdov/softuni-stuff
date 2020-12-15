using System;

namespace PermutationsWithoutRepetition
{
    class Program
    {
        private static string[] elements;
        private static string[] permutations;
        private static bool[] used;

        static void Main()
        {
            elements = Console.ReadLine().Split();
            permutations = new string[elements.Length];
            used = new bool[elements.Length];

            Permute(0);
        }

        private static void Permute(int permutationsIndx)
        {
            if (permutationsIndx >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            for (int elementsIndx = 0; elementsIndx < elements.Length; elementsIndx++)
            {
                if (!used[elementsIndx])
                {
                    used[elementsIndx] = true;
                    permutations[permutationsIndx] = elements[elementsIndx];
                    Permute(permutationsIndx + 1);
                    used[elementsIndx] = false;
                }
            }
        }
    }
}
