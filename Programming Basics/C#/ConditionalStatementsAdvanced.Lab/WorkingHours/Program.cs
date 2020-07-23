using System;

namespace WorkingHours
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeOfDay = int.Parse(Console.ReadLine());
            string dayOfTheWeek = Console.ReadLine();

            if ((dayOfTheWeek == "Monday" || dayOfTheWeek == "Tuesday" ||
                dayOfTheWeek == "Wednesday" || dayOfTheWeek == "Thursday" ||
                dayOfTheWeek == "Friday" || dayOfTheWeek == "Saturday")
                && (timeOfDay >= 10 && timeOfDay <= 18))
            {
                Console.WriteLine("open");
            }
            else
            {
                Console.WriteLine("closed");
            }
            #region Other ways
            //List<string> workingDays = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            //if (timeOfDay >= 10 && timeOfDay <= 18 && workingDays.Contains(dayOfTheWeek))
            //{
            //    Console.WriteLine("open");
            //}
            //else
            //{
            //    Console.WriteLine("closed");
            //}
            #endregion
        }
    }
}
