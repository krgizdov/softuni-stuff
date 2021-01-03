using System;
using System.Linq;

namespace SelectionSort
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SelectionSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIdx = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIdx])
                    {
                        minIdx = j;
                    }
                }

                if (minIdx != i)
                {
                    Swap(i, minIdx, arr);
                }
            }
        }

        private static void Swap(int first, int second, int[] arr)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
