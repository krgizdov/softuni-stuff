using System;
using System.Collections.Generic;

namespace LongestStringChain
{
    class Program
    {
        static void Main()
        {
            var words = Console.ReadLine().Split();

            var numbers = new int[words.Length];

            for (int w = 0; w < words.Length; w++)
            {
                numbers[w] = words[w].Length;
            }

            var len = new int[numbers.Length];
            var prev = new int[numbers.Length];
            Array.Fill(prev, -1);

            var bestLen = 0;
            var lastIdx = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];
                var currentBestSeq = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    var prevNumber = numbers[j];

                    if (prevNumber < currentNumber &&
                        len[j] + 1 >= currentBestSeq)
                    {
                        currentBestSeq = len[j] + 1;
                        prev[i] = j;
                    }
                }

                if (currentBestSeq > bestLen)
                {
                    bestLen = currentBestSeq;
                    lastIdx = i;
                }

                len[i] = currentBestSeq;
            }

            var stack = new Stack<string>();

            while (lastIdx != -1)
            {
                stack.Push(words[lastIdx]);
                lastIdx = prev[lastIdx];
            }

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
