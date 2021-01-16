using System;
using System.Linq;

namespace ConnectingCables
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var positions = new int[numbers.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = i + 1;
            }

            var table = new int[numbers.Length + 1, numbers.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (numbers[r - 1] == positions[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r, c - 1], table[r - 1, c]);
                    }
                }
            }

            Console.WriteLine($"Maximum pairs connected: {table[numbers.Length, positions.Length]}");

            #region This is how you can get the pairs
            //var row = numbers.Length;
            //var col = numbers.Length;

            //var pairs = new Stack<int>();

            //while (row > 0 && col > 0)
            //{
            //    if (numbers[row - 1] == positions[col - 1])
            //    {
            //        pairs.Push(numbers[row - 1]);
            //        row--;
            //        col--;
            //    }
            //    else if (table[row - 1, col] > table[row, col - 1])
            //    {
            //        row--;
            //    }
            //    else
            //    {
            //        col--;
            //    }
            //}

            //Console.WriteLine(string.Join(" ", pairs));
            #endregion
        }
    }
}
