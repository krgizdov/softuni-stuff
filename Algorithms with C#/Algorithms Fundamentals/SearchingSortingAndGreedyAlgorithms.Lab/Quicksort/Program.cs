using System;
using System.Linq;

namespace Quicksort
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Quicksort(arr, 0, arr.Length - 1);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Quicksort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = start;
            var left = start + 1;
            var right = end;

            while (left <= right)
            {
                if (arr[left] > arr[pivot] && 
                    arr[right] < arr[pivot])
                {
                    Swap(left, right, arr);
                }

                if (arr[left] <= arr[pivot])
                {
                    left++;
                }

                if (arr[right] >= arr[pivot])
                {
                    right--;
                }
            }

            Swap(pivot, right, arr);

            var isLeftSubArraySmaller = right - 1 - start < end - right + 1;

            if (isLeftSubArraySmaller)
            {
                Quicksort(arr, start, right - 1);
                Quicksort(arr, right + 1, end);
            }
            else
            {
                Quicksort(arr, right + 1, end);
                Quicksort(arr, start, right - 1);
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
