using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestZigzagSubsequence
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var table = new int[2, numbers.Length];

            table[0, 0] = 1;
            table[1, 0] = 1;

            var parent = new int[2, numbers.Length];

            parent[0, 0] = -1;
            parent[1, 0] = -1;

            var bestSize = 0;
            var lastRowIdx = 0;
            var lastColIdx = 0;

            for (int current = 0; current < numbers.Length; current++)
            {
                var currentNumber = numbers[current];

                for (int prev = current - 1; prev >= 0; prev--)
                {
                    var prevNumber = numbers[prev];

                    if (currentNumber > prevNumber &&
                        table[1, prev] + 1 >= table[0, current])
                    {
                        table[0, current] = table[1, prev] + 1;
                        parent[0, current] = prev;
                    }

                    if (currentNumber < prevNumber &&
                        table[0, prev] + 1 >= table[1, current])
                    {
                        table[1, current] = table[0, prev] + 1;
                        parent[1, current] = prev;
                    }
                }

                if (table[0, current] > bestSize)
                {
                    bestSize = table[0, current];
                    lastRowIdx = 0;
                    lastColIdx = current;
                }

                if (table[1, current] > bestSize)
                {
                    bestSize = table[1, current];
                    lastRowIdx = 1;
                    lastColIdx = current;
                }
            }

            var zigZagSeq = new Stack<int>();

            while (lastColIdx != -1)
            {
                zigZagSeq.Push(numbers[lastColIdx]);

                lastColIdx = parent[lastRowIdx, lastColIdx];

                if (lastRowIdx == 0)
                {
                    lastRowIdx = 1;
                }
                else
                {
                    lastRowIdx = 0;
                }
            }

            Console.WriteLine(string.Join(" ", zigZagSeq));
        }
    }
}
