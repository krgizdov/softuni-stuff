using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            const double premierePrice = 12.00;
            const double normalPrice = 7.50;
            const double discountPrice = 5.00;

            string projectionType = Console.ReadLine();
            int roomRows = int.Parse(Console.ReadLine());
            int roomColumns = int.Parse(Console.ReadLine());

            double income = 0;

            if (projectionType == "Premiere")
            {
                income = CalculateTotalIncome(premierePrice, roomRows, roomColumns);
            }
            else if (projectionType == "Normal")
            {
                income = CalculateTotalIncome(normalPrice, roomRows, roomColumns);
            }
            else if (projectionType == "Discount")
            {
                income = CalculateTotalIncome(discountPrice, roomRows, roomColumns);
            }

            Console.WriteLine($"{income:f2} leva");
        }

        public static double CalculateTotalIncome(double projectionType, int roomRows, int roomColumns)
        {
            return projectionType * roomRows * roomColumns;
        }
    }
}
