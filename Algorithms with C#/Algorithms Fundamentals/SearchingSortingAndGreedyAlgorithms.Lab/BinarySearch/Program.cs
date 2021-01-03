using System;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int key = int.Parse(Console.ReadLine());

            var idxOfKey = BinarySearch(arr, key);

            Console.WriteLine(idxOfKey);
        }

        private static int BinarySearch(int[] arr, int key)
        {
            var left = 0;
            var right = arr.Length - 1;

            while (left <= right)
            {
                var midPoint = (left + right) / 2;

                var element = arr[midPoint];

                if (element == key)
                {
                    return midPoint;
                }

                if (key > element)
                {
                    left = midPoint + 1;
                }
                else
                {
                    right = midPoint - 1;
                }
            }

            return -1;
        }
    }
}
