using System;
using System.Linq;

namespace MergeSortOptimised
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var sorted = MergeSort(arr);

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return arr;
            }

            var copy = new int[arr.Length];
            Array.Copy(arr, copy, arr.Length);

            MergeSortHelper(arr, copy, 0, arr.Length - 1);

            return arr;
        }

        private static void MergeSortHelper(int[] source, int[] copy, int leftIdx, int rightIdx)
        {
            if (leftIdx >= rightIdx)
            {
                return;
            }

            var middleIdx = (leftIdx + rightIdx) / 2;

            MergeSortHelper(copy, source, leftIdx, middleIdx);
            MergeSortHelper(copy, source, middleIdx + 1, rightIdx);

            MergeArrays(source, copy, leftIdx, middleIdx, rightIdx);
        }

        public static void MergeArrays(int[] source, int[] copy, int startIdx, int middleIdx, int endIdx)
        {
            var sourceIdx = startIdx;
            var leftIdx = startIdx;
            var rightIdx = middleIdx + 1;

            while (leftIdx <= middleIdx && rightIdx <= endIdx)
            {
                if (copy[leftIdx] < copy[rightIdx])
                {
                    source[sourceIdx++] = copy[leftIdx++];
                }
                else
                {
                    source[sourceIdx++] = copy[rightIdx++];
                }
            }

            while (leftIdx <= middleIdx)
            {
                source[sourceIdx] = copy[leftIdx];
                leftIdx += 1;
                sourceIdx += 1;
            }

            while (rightIdx <= endIdx)
            {
                source[sourceIdx] = copy[rightIdx];
                rightIdx += 1;
                sourceIdx += 1;
            }
        }
    }
}
