using System;

namespace TimePlus15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            var date = new DateTime(2020, 1, 1, hour, minutes, 0);
            date = date.AddMinutes(15);

            ///var timeSpan = new TimeSpan(hour, minutes, 0);
            ///timeSpan = timeSpan.Add(new TimeSpan(0, 15, 0));

            Console.WriteLine($"{date.Hour}:{date.Minute:d2}");
            ///Console.WriteLine($"{timeSpan.Hours}:{timeSpan.Minutes:d2}");
        }
    }
}
