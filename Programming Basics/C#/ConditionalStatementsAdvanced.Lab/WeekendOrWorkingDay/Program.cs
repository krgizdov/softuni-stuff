using System;

namespace WeekendOrWorkingDay
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayOfTheWeek = Console.ReadLine();

            string dayType;

            switch (dayOfTheWeek)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    dayType = "Working day";
                    break;
                case "Saturday":
                case "Sunday":
                    dayType = "Weekend";
                    break;
                default:
                    dayType = "Error";
                    break;
            }

            Console.WriteLine(dayType);
            #region Some Other ways

            //var dict = new Dictionary<string, string>();
            //dict.Add("Monday", "Working day");
            //dict.Add("Tuesday", "Working day");
            //dict.Add("Wednesday", "Working day");
            //dict.Add("Thursday", "Working day");
            //dict.Add("Friday", "Working day");
            //dict.Add("Saturday", "Weekend");
            //dict.Add("Sunday", "Weekend");

            //if (dict.ContainsKey(dayOfTheWeek))
            //{
            //    Console.WriteLine(dict[dayOfTheWeek]);
            //}
            //else
            //{
            //    Console.WriteLine("Error");
            //}

            //------------------------------------

            //if (dayOfTheWeek == "Monday" || dayOfTheWeek == "Tuesday" || dayOfTheWeek == "Wednesday" 
            //    || dayOfTheWeek == "Thursday" || dayOfTheWeek == "Friday")
            //{
            //    Console.WriteLine("Working day");
            //}
            //else if (dayOfTheWeek == "Saturday" || dayOfTheWeek == "Sunday")
            //{
            //    Console.WriteLine("Weekend");
            //}
            //else
            //{
            //    Console.WriteLine("Error");
            //}
            #endregion
        }
    }
}
