using System;
using System.Linq;

namespace RodCutting
{
    class Program
    {
        private static int[] _bestPrices;
        private static int[] _combo;

        static void Main()
        {
            var prices = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var length = int.Parse(Console.ReadLine());

            _bestPrices = new int[length + 1];
            _combo = new int[length + 1];

            Console.WriteLine(CutRod(length, prices));

            while (length != 0)
            {
                Console.Write($"{_combo[length]} ");
                length -= _combo[length];
            }
        }

        private static int CutRod(int length, int[] prices)
        {
            //if (length == 0)
            //{
            //    return 0;
            //}

            if (_bestPrices[length] != 0)
            {
                return _bestPrices[length];
            }

            var bestPrice = prices[length];
            var bestCombo = length;

            for (int i = 1; i < length; i++)
            {
                var currentPrice = prices[i] + CutRod(length - i, prices);

                if (currentPrice > bestPrice)
                {
                    bestPrice = currentPrice;
                    bestCombo = i;
                }
            }

            _bestPrices[length] = bestPrice;
            _combo[length] = bestCombo;

            return bestPrice;
        }
    }
}
