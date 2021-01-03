using System;
using System.Linq;
using System.Text;

namespace SumOfCoins
{
    class Program
    {
        static void Main()
        {
            var coins = Console.ReadLine().Split(", ").Select(int.Parse).OrderByDescending(n => n).ToArray();
            var target = int.Parse(Console.ReadLine());

            var counter = 0;
            var coinsIndex = 0;
            var sb = new StringBuilder();

            while (target > 0 && coinsIndex < coins.Length)
            {
                var currentCoin = coins[coinsIndex++];
                var coinsCount = target / currentCoin;

                if (coinsCount > 0)
                {
                    counter += coinsCount;
                    target -= currentCoin * coinsCount;
                    sb.AppendLine($"{coinsCount} coin(s) with value {currentCoin}");
                }
            }

            if (target != 0)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine($"Number of coins to take: {counter}");
                Console.WriteLine(sb.ToString());
            }
        }
        #region Another Implementation using Dictionary to store coins
        //private static int FindCoins(int[] arr, int sumToGet)
        //{
        // private static readonly Dictionary<int, int> _coins = new Dictionary<int, int>();

        //    for (int i = arr.Length - 1; i >= 0; i--)
        //    {
        //        if (sumToGet / arr[i] >= 1)
        //        {
        //            var timesCoinFits = sumToGet / arr[i];
        //            sumToGet -= arr[i] * timesCoinFits;

        //            if (!_coins.ContainsKey(arr[i]))
        //            {
        //                _coins[arr[i]] = timesCoinFits;
        //            }
        //        }

        //        if (sumToGet == 0)
        //        {
        //            return sumToGet;
        //        }
        //    }
        //    var sum = FindCoins(arr, sumToGet);

        //    if (sum != 0)
        //    {
        //        Console.WriteLine("Error");
        //        return;
        //    }

        //    Console.WriteLine($"Number of coins to take: {_coins.Values.Sum()}");
        //    foreach (var coin in _coins)
        //    {
        //        Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
        //    }

        //    return sumToGet;
        //}
        #endregion
    }
}
