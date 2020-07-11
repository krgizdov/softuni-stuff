using System;

namespace InchesToCentimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            const double oneInchCms = 2.54;

            double inches = double.Parse(Console.ReadLine());
            double centimeters = inches * oneInchCms;

            Console.WriteLine(centimeters);
        }
    }
}
