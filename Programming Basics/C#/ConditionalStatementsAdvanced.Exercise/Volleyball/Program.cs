using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            const int yearWeekendsAvailable = 48;

            string yearType = Console.ReadLine();
            int yearHolidays = int.Parse(Console.ReadLine());
            int weekendsAtHome = int.Parse(Console.ReadLine());

            double daysToPlay = (yearWeekendsAvailable - weekendsAtHome) * 0.75;
            double holidayPlayDays = (double)yearHolidays * 2 / 3;

            daysToPlay += holidayPlayDays + weekendsAtHome;

            if (yearType == "leap")
            {
                daysToPlay *= 1.15;
            }

            Console.WriteLine(Math.Floor(daysToPlay));
        }
    }
}
