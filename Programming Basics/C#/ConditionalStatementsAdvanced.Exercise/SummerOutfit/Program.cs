using System;

namespace SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            string outfit = string.Empty;

            if (timeOfDay == "Evening")
            {
                outfit = "Shirt and Moccasins";
            }
            else if (timeOfDay == "Afternoon")
            {
                if (degrees >= 25)
                {
                    outfit = "Swim Suit and Barefoot";
                }
                else if (degrees > 18)
                {
                    outfit = "T-Shirt and Sandals";
                }
                else if (degrees >= 10)
                {
                    outfit = "Shirt and Moccasins";
                }
            }
            else if (timeOfDay == "Morning")
            {
                if (degrees >= 25)
                {
                    outfit = "T-Shirt and Sandals";
                }
                else if (degrees > 18)
                {
                    outfit = "Shirt and Moccasins";
                }
                else if (degrees >= 10)
                {
                    outfit = "Sweatshirt and Sneakers";
                }
            }

            Console.WriteLine($"It's {degrees} degrees, get your {outfit}.");
        }
    }
}
