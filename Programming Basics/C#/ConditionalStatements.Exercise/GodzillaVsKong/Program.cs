using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double movieBudget = double.Parse(Console.ReadLine());
            int extras = int.Parse(Console.ReadLine());
            double clothingPricePerExtra = double.Parse(Console.ReadLine());

            double movieDecor = movieBudget * 0.1;

            if (extras > 150)
            {
                clothingPricePerExtra *= 0.9;
            }

            double totalPrice = extras * clothingPricePerExtra + movieDecor;

            CalculateIfBudgedIsEnough(totalPrice, movieBudget);
        }
        public static void CalculateIfBudgedIsEnough(double totalPrice, double movieBudget)
        {
            if (movieBudget >= totalPrice)
            {
                Console.WriteLine($"Action!\r\nWingard starts filming with {movieBudget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money!\r\nWingard needs {totalPrice - movieBudget:f2} leva more.");
            }
        }
    }
}
