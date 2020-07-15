using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine();

            if (figureType == "square")
            {
                double side = double.Parse(Console.ReadLine());

                PrintResult(Math.Pow(side, 2));
            }
            else if (figureType == "rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());

                PrintResult(sideA * sideB);
            }
            else if (figureType == "circle")
            {
                double radius = double.Parse(Console.ReadLine());

                PrintResult(Math.PI * Math.Pow(radius, 2));
            }
            else
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                PrintResult(side * height / 2);
            }
        }
        public static void PrintResult(double result)
        {
            Console.WriteLine($"{result}:f2");
        }
    }
}
