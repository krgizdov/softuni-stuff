using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int tankLength = int.Parse(Console.ReadLine());
            int tankWidth = int.Parse(Console.ReadLine());
            int tankHeight = int.Parse(Console.ReadLine());
            double tankFullness = double.Parse(Console.ReadLine());

            int tankVolume = tankLength * tankWidth * tankHeight;
            double litersToFill = tankVolume * 0.001;
            double litersForAccessories = tankFullness * 0.01;

            double totalLitersNeeded = litersToFill * (1 - litersForAccessories);

            Console.WriteLine(totalLitersNeeded);
        }
    }
}
