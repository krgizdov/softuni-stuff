using System;

namespace FruitOrVegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            string food = Console.ReadLine();

            string foodType = "unknown";

            if (food == "banana" || food == "apple" || food == "kiwi" ||
                food == "cherry" || food == "lemon" || food == "grapes")
            {
                foodType = "fruit";
            }
            else if (food == "tomato" || food == "cucumber" || food == "pepper" || food == "carrot")
            {
                foodType = "vegetable";
            }

            Console.WriteLine(foodType);
        }
    }
}
