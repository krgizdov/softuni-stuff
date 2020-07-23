using System;

namespace CinemaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayOfTheWeek = Console.ReadLine();

            int price = 0;

            if (dayOfTheWeek == "Monday" || dayOfTheWeek == "Tuesday" || dayOfTheWeek == "Friday")
            {
                price = 12;
            }
            else if (dayOfTheWeek == "Wednesday" || dayOfTheWeek == "Thursday")
            {
                price = 14;
            }
            else if (dayOfTheWeek == "Saturday" || dayOfTheWeek == "Sunday")
            {
                price = 16; 
            }

            Console.WriteLine(price);
        }
    }
}
