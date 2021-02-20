using System;
using System.Collections.Generic;
using System.Linq;

namespace Boxes
{
    class Box
    {
        public int Width { get; set; }

        public int Depth { get; set; }

        public int Height { get; set; }

        public override string ToString()
        {
            return $"{Width} {Depth} {Height}";
        }
    }

    class Program
    {
        static void Main()
        {
            var boxesAmount = int.Parse(Console.ReadLine());
            var boxes = ReadBoxData(boxesAmount);

            var len = new int[boxes.Length];
            var prev = new int[boxes.Length];
            Array.Fill(prev, -1);

            var bestLen = 0;
            var lastIdx = 0;

            for (int i = 0; i < boxes.Length; i++)
            {
                var currentBox = boxes[i];
                var currentBestSeq = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    var prevBox = boxes[j];

                    if (prevBox.Height < currentBox.Height &&
                        prevBox.Depth < currentBox.Depth &&
                        prevBox.Width < currentBox.Width &&
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
                stack.Push($"{boxes[lastIdx]}");
                lastIdx = prev[lastIdx];
            }

            Console.WriteLine(string.Join("\r\n", stack));
        }

        private static Box[] ReadBoxData(int boxesAmount)
        {
            var boxes = new Box[boxesAmount];

            for (int i = 0; i < boxesAmount; i++)
            {
                var boxData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                boxes[i] = new Box
                {
                    Width = boxData[0],
                    Depth = boxData[1],
                    Height = boxData[2]
                };
            }

            return boxes;
        }
    }
}
