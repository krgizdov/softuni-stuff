using System;

namespace ReverseArray
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split();

            PrintArrayReversed(arr, 0);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void PrintArrayReversed(string[] arr, int index)
        {
            if (index < arr.Length / 2)
            {
                var temp = arr[index];
                arr[index] = arr[^(1 + index)];
                arr[^(1 + index)] = temp;

                PrintArrayReversed(arr, index + 1);
            }
        }
    }
}
