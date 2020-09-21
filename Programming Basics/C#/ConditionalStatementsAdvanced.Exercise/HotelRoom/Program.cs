using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double apartmentPrice = 0;

            if (month == "May" || month == "October")
            {
                studioPrice = 50;
                apartmentPrice = 65;
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 75.20;
                apartmentPrice = 68.70;
            }
            else if (month == "July" || month == "August")
            {
                studioPrice = 76;
                apartmentPrice = 77;
            }

            studioPrice *= nights;
            apartmentPrice *= nights;

            if (nights > 14)
            {
                apartmentPrice *= 0.9;

                if (month == "June" || month == "September")
                {
                    studioPrice *= 0.8;
                }
                else if (month == "May" || month == "October")
                {
                    studioPrice *= 0.7;
                }
            }
            else if (nights > 7 && month == "May" || month == "October")
            {
                studioPrice *= 0.95;
            }

            Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.\r\nStudio: {studioPrice:f2} lv.");
        }
    }
}
