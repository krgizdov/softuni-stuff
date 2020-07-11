using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            const double dogFoodPrice = 2.5;
            const int otherAnimalFoodPrice = 4;

            int dogAmount = int.Parse(Console.ReadLine());
            int otherAnimals = int.Parse(Console.ReadLine());

            var totalPrice = dogAmount * dogFoodPrice + otherAnimals * otherAnimalFoodPrice;

            Console.WriteLine($"{totalPrice} lv.");
        }
    }
}
