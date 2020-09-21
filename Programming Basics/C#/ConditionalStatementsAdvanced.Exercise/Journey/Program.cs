using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination;
            string vacationType;
            double price = 0;

            if (budget <= 100)
            {
                destination = "Bulgaria";

                if (season == "summer")
                {
                    price = budget * 0.3;
                }
                else if (season == "winter")
                {
                    price = budget * 0.7;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";

                if (season == "summer")
                {
                    price = budget * 0.4;
                }
                else if (season == "winter")
                {
                    price = budget * 0.8;
                }
            }
            else
            {
                destination = "Europe";

                price = budget * 0.9;
            }

            if (season == "winter" || destination == "Europe")
            {
                vacationType = "Hotel";
            }
            else
            {
                vacationType = "Camp";
            }

            Console.WriteLine($"Somewhere in {destination}\r\n{vacationType} - {price:f2}");
        }
    }
}
