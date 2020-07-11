using System;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            const double pricePerSquareMeter = 7.61;
            const double discount = 0.18;

            double squareMeters = double.Parse(Console.ReadLine());

            var totalPrice = squareMeters * pricePerSquareMeter;
            var discountAmount = totalPrice * discount;

            Console.WriteLine($"The final price is: {totalPrice - discountAmount} lv." +
                $"\r\nThe discount is: {discountAmount}");
        }
    }
}
