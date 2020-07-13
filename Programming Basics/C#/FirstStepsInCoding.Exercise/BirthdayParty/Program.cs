using System;

namespace BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double hallRent = double.Parse(Console.ReadLine());

            double cakePrice = hallRent * 0.2;
            double beveragePrice = cakePrice * 0.55;
            double animatorPrice = hallRent / 3;

            double totalPrice = cakePrice + beveragePrice + animatorPrice + hallRent;

            Console.WriteLine(totalPrice);
        }
    }
}
