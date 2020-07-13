using System;

namespace FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberryPrice = double.Parse(Console.ReadLine());
            double bananasKg = double.Parse(Console.ReadLine());
            double orangesKg = double.Parse(Console.ReadLine());
            double raspberryKg = double.Parse(Console.ReadLine());
            double strawberryKg = double.Parse(Console.ReadLine());

            double raspberryPrice = strawberryPrice / 2;

            double strawberryTotal = strawberryKg * strawberryPrice;
            double raspberryTotal = raspberryPrice * raspberryKg;
            double orangesTotal = raspberryPrice * 0.6 * orangesKg;
            double bananasTotal = raspberryPrice * 0.2 * bananasKg;

            double totalPrice = strawberryTotal + raspberryTotal + orangesTotal + bananasTotal;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
