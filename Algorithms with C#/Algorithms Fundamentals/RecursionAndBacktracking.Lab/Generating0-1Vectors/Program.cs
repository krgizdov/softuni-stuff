using System;

namespace Generating0_1Vectors
{
    class Program
    {
        static void Main()
        {
            int amount = int.Parse(Console.ReadLine());

            var array = new int[amount];

            GenerateVectors(array, 0);
        }

        private static void GenerateVectors(int[] array, int index)
        {
            if (index > array.Length - 1)
            {
                Console.WriteLine(string.Join("", array));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                array[index] = i;
                GenerateVectors(array, index + 1);
            }
        }
    }
}
