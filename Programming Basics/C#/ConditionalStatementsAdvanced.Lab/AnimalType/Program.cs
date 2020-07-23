using System;

namespace AnimalType
{
    class Program
    {
        static void Main(string[] args)
        {
            string animal = Console.ReadLine();

            string animalType;

            switch (animal)
            {
                case "dog":
                    animalType = "mammal";
                    break;
                case "crocodile":
                case "tortoise":
                case "snake":
                    animalType = "reptile";
                    break;
                default:
                    animalType = "unknown";
                    break;
            }

            Console.WriteLine(animalType);

            #region Some other way
            //if (animal == "dog")
            //    animalType = "mammal";
            //else if (animal == "crocodile" || animal == "tortoise" || animal == "snake")
            //    animalType = "reptile";
            //else
            //    animalType = "unknown";
            #endregion
        }
    }
}
