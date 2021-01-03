using System;
using System.Linq;

namespace BubbleSort
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            BubbleSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j < arr.Length - i; j++)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        Swap(j, j - 1, arr);
                    }
                }
            }

            #region A way with a while loop
            //var isSorted = false;
            //var i = 0;
            //while (!isSorted)
            //{
            //    isSorted = true;

            //    for (int j = 1; j < arr.Length - i; j++)
            //    {
            //        if (arr[j - 1] > arr[j])
            //        {
            //            isSorted = false;
            //            Swap(j, j - 1, arr);
            //        }
            //    }

            //    i++;
            //}
            #endregion
        }

        private static void Swap(int first, int second, int[] arr)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
