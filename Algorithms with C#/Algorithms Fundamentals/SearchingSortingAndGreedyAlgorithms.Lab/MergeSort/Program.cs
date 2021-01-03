﻿using System;
using System.Linq;

namespace MergeSort
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
            if (arr.Length == 1)
            {
                return arr;
            }

            var left = arr.Take(arr.Length / 2).ToArray();
            var right = arr.Skip(arr.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var merged = new int[left.Length + right.Length];

            var mergedIdx = 0;
            var leftIdx = 0;
            var rightIdx = 0;

            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] < right[rightIdx])
                {
                    merged[mergedIdx] = left[leftIdx];
                    leftIdx++;
                }
                else
                {
                    merged[mergedIdx] = right[rightIdx];
                    rightIdx++;
                }

                mergedIdx++;
            }

            while (leftIdx < left.Length)
            {
                merged[mergedIdx] = left[leftIdx];
                leftIdx++;
                mergedIdx++;
            }

            while (rightIdx < right.Length)
            {
                merged[mergedIdx] = right[rightIdx];
                rightIdx++;
                mergedIdx++;
            }   

            return merged;
        }
    }
}
