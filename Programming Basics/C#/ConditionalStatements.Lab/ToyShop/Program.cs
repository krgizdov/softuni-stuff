using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            const double puzzlePrice = 2.60;
            const double dollPrice = 3;
            const double teddyBearPrice = 4.10;
            const double minionPrice = 8.20;
            const double truckPrice = 2;

            double vacationPrice = double.Parse(Console.ReadLine());
            int puzzlesAmount = int.Parse(Console.ReadLine());
            int dollsAmount = int.Parse(Console.ReadLine());
            int teddyBearsAmount = int.Parse(Console.ReadLine());
            int minionsAmount = int.Parse(Console.ReadLine());
            int trucksAmount = int.Parse(Console.ReadLine());

            double totalEarnings = puzzlesAmount * puzzlePrice + dollsAmount * dollPrice + 
                teddyBearsAmount * teddyBearPrice + minionsAmount * minionPrice + trucksAmount * truckPrice;

            int toysBought = puzzlesAmount + dollsAmount + teddyBearsAmount + minionsAmount + trucksAmount;

            if (toysBought >= 50)
            {
                totalEarnings *= 0.75;
            }

            totalEarnings *= 0.9;

            CheckIfEarningsAreEnough(totalEarnings, vacationPrice);
        }

        public static void CheckIfEarningsAreEnough(double totalEarnings, double vacationPrice)
        {
            if (totalEarnings >= vacationPrice)
            {
                Console.WriteLine($"Yes! {totalEarnings - vacationPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {vacationPrice - totalEarnings:f2} lv needed.");
            }
        }
    }
}
