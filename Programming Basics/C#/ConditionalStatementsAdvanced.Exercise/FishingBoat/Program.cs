using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            const double springPrice = 3000;
            const double summerAutumnPrice = 4200;
            const double winterPrice = 2600;

            int groupBudget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int groupSize = int.Parse(Console.ReadLine());

            double price = 0;

            if (season == "Spring")
            {
                price = springPrice;
            }
            else if (season == "Summer" || season == "Autumn")
            {
                price = summerAutumnPrice;
            }
            else if (season == "Winter")
            {
                price = winterPrice;
            }

            if (groupSize <= 6)
            {
                price *= 0.9;
            }
            else if (groupSize <= 11)
            {
                price *= 0.85;
            }
            else
            {
                price *= 0.75;
            }

            if (groupSize % 2 == 0 && season != "Autumn")
            {
                price *= 0.95;
            }

            double finalPrice = groupBudget - price;

            if (finalPrice < 0)
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(finalPrice):f2} leva.");
            }
            else
            {
                Console.WriteLine($"Yes! You have {finalPrice:f2} leva left.");
            }
        }
    }
}
