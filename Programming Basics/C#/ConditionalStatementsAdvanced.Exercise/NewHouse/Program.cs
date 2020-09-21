using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            const double rosePrice = 5;
            const double dahliaPrice = 3.80;
            const double tulipPrice = 2.80;
            const double narcissusPrice = 3;
            const double gladiolusPrice = 2.50;

            string flowerType = Console.ReadLine();
            int flowersAmount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double flowerPrice = 0;

            if (flowerType == "Roses")
            {
                flowerPrice = CalculateFlowerPrice(flowersAmount, rosePrice);

                if (flowersAmount > 80)
                {
                    flowerPrice *= 0.9;
                }
            }
            else if (flowerType == "Dahlias")
            {
                flowerPrice = CalculateFlowerPrice(flowersAmount, dahliaPrice);

                if (flowersAmount > 90)
                {
                    flowerPrice *= 0.85;
                }
            }
            else if (flowerType == "Tulips")
            {
                flowerPrice = CalculateFlowerPrice(flowersAmount, tulipPrice);

                if (flowersAmount > 80)
                {
                    flowerPrice *= 0.85;
                }
            }
            else if (flowerType == "Narcissus")
            {
                flowerPrice = CalculateFlowerPrice(flowersAmount, narcissusPrice);

                if (flowersAmount < 120)
                {
                    flowerPrice *= 1.15;
                }
            }
            else if (flowerType == "Gladiolus")
            {
                flowerPrice = CalculateFlowerPrice(flowersAmount, gladiolusPrice);

                if (flowersAmount < 80)
                {
                    flowerPrice *= 1.2;
                }
            }
    
            double moneyLeft = budget - flowerPrice;

            if (moneyLeft < 0)
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(moneyLeft):f2} leva more.");
            }
            else
            {
                Console.WriteLine($"Hey, you have a great garden with " +
                    $"{flowersAmount} {flowerType} and {moneyLeft:f2} leva left.");
            }
        }

        public static double CalculateFlowerPrice(int flowerAmount, double flowerPrice)
        {
            return flowerAmount * flowerPrice;
        }
    }
}
