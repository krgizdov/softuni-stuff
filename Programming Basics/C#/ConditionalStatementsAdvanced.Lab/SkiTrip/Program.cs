using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            const double roomForOnePrice = 18;
            const double apartmentPrice = 25;
            const double presidentApartmentPrice = 35;

            int vacationDays = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string vacationGrade = Console.ReadLine();

            double vacationPrice = 0;

            if (roomType == "room for one person")
                vacationPrice = CalculateRoomPrice(vacationDays, roomForOnePrice);
            else if (roomType == "apartment")
            {
                vacationPrice = CalculateRoomPrice(vacationDays, apartmentPrice);

                if (vacationDays < 10)
                    vacationPrice *= 0.7;
                else if (vacationDays <= 15)
                    vacationPrice *= 0.65;
                else
                    vacationPrice *= 0.5;
            }
            else if (roomType == "president apartment")
            {
                vacationPrice = CalculateRoomPrice(vacationDays, presidentApartmentPrice);

                if (vacationDays < 10)
                    vacationPrice *= 0.9;
                else if (vacationDays <= 15)
                    vacationPrice *= 0.85;
                else
                    vacationPrice *= 0.8;
            }

            if (vacationGrade == "positive")
                vacationPrice *= 1.25;
            else if (vacationGrade == "negative")
                vacationPrice *= 0.9;

            Console.WriteLine($"{vacationPrice:f2}");
        }

        public static double CalculateRoomPrice(int vacationDays, double roomTypePrice)
        {
            return (vacationDays - 1) * roomTypePrice;
        }
    }
}
