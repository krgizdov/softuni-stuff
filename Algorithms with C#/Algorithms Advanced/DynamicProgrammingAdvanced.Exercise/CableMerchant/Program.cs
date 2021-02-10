using System;
using System.Collections.Generic;
using System.Linq;

namespace CableMerchant
{
    class Program
    {
        private static int[] _bestPrices;

        static void Main()
        {
            var prices = new List<int> { 0 };

            prices.AddRange(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            var connectorPrice = int.Parse(Console.ReadLine());

            _bestPrices = new int[prices.Count];

            for (int length = 1; length < prices.Count; length++)
            {
                var bestPriceForLength = CutCable(length, prices, connectorPrice * 2);

                Console.Write($"{bestPriceForLength} ");
            }
        }

        private static int CutCable(int length, List<int> prices, int connectorPrice)
        {
            if (length == 0)
            {
               return 0;
            }

            if (_bestPrices[length] != 0)
            {
                return _bestPrices[length];
            }

            var bestPrice = prices[length];

            for (int i = 1; i < length; i++)
            {
                var currentPrice = prices[i] + CutCable(length - i, prices, connectorPrice) - connectorPrice;

                if (currentPrice > bestPrice)
                {
                    bestPrice = currentPrice;
                }
            }

            _bestPrices[length] = bestPrice;

            return bestPrice;
        }
    }
}
