using System;

namespace RadiansToDegrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double radians = double.Parse(Console.ReadLine());

            double degrees = ConvertRadiansToDegrees(radians);

            Console.WriteLine(Math.Round(degrees));
        }

        public static double ConvertRadiansToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }
    }
}
