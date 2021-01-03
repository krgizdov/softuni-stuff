using System;
using System.Linq;

namespace InsertionSort
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            InsertionSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                var j = i;

                while (j > 0 && arr[j] < arr[j - 1])
                {
                    Swap(j, j - 1, arr);
                    j--;
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
