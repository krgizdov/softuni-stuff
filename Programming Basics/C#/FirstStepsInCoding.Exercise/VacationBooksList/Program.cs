using System;

namespace VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int bookPages = int.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            int daysToReadBook = int.Parse(Console.ReadLine());

            double hoursToRead = bookPages / pagesPerHour / daysToReadBook;

            Console.WriteLine(hoursToRead);
        }
    }
}
