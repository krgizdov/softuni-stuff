using System;

namespace NestedLoops
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var arr = new int[n];

            PrintNestedLoops(0, arr);
        }

        private static void PrintNestedLoops(int index, int[] arr)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                arr[index] = i;
                PrintNestedLoops(index + 1, arr);
            }
        }
    }
}
