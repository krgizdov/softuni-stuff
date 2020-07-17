using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            const double waterResistenceDelay = 12.5;

            double recordSeconds = double.Parse(Console.ReadLine());
            double metersToSwim = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double totalSecondsDelay = Math.Floor(metersToSwim / 15) * waterResistenceDelay;

            double currentTime = metersToSwim * secondsPerMeter + totalSecondsDelay;

            if (currentTime < recordSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {currentTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {currentTime - recordSeconds:f2} seconds slower.");
            }
        }
    }
}
