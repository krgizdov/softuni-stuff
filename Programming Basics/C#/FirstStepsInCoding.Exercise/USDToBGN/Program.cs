using System;

namespace USDToBGN
{
    class Program
    {
        static void Main(string[] args)
        {
            const double usdToBgnCourse = 1.79549;

            double dollars = double.Parse(Console.ReadLine());

            double levs = dollars * usdToBgnCourse;

            Console.WriteLine($"{levs:f2}");
        }
    }
}
