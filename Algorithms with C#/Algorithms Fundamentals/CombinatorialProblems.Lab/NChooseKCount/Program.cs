using System;

namespace NChooseKCount
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            var arr = new int[n + 1][];
            arr[0] = new int[] { 1 };
            arr[1] = new int[] { 1, 1 };

            for (int i = 2; i < n + 1; i++)
            {
                arr[i] = new int[i + 1];
                arr[i][0] = 1;
                arr[i][^1] = 1;

                for (int j = 1; j < i; j++)
                {
                    arr[i][j] = arr[i - 1][j] + arr[i - 1][j - 1];
                }
            }

            Console.WriteLine(arr[n][k]);
        }
    }
}
