using System;

namespace VariationsWithoutRepetition
{
    class Program
    {
        private static string[] elements;
        private static bool[] used;
        private static string[] variations;

        static void Main()
        {
            elements = Console.ReadLine().Split();
            int k = int.Parse(Console.ReadLine());

            variations = new string[k];
            used = new bool[elements.Length];

            Variations(0);
        }

        private static void Variations(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[index] = elements[i];
                    Variations(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
