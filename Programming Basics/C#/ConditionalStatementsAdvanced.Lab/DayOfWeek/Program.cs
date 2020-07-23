using System;

namespace DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());

            string dayOfWeek = day switch
            {
                1 => "Monday",
                2 => "Tuesday",
                3 => "Wednesday",
                4 => "Thursday",
                5 => "Friday",
                6 => "Saturday",
                7 => "Sunday",
                _ => "Error"
            };

            Console.WriteLine(dayOfWeek);

            #region Other Possible Solutions
            //Normal Switch Case
            //switch (day)
            //{
            //    case 1: dayOfWeek = "Monday"; break;
            //    case 2: dayOfWeek = "Tuesday"; break;
            //    case 3: dayOfWeek = "Wednesday"; break;
            //    case 4: dayOfWeek = "Thursday"; break;
            //    case 5: dayOfWeek = "Friday"; break;
            //    case 6: dayOfWeek = "Saturday"; break;
            //    case 7: dayOfWeek = "Sunday"; break;
            //    default: dayOfWeek = "Error"; break;
            //}

            //If else

            //if (day == 1)
            //    dayOfWeek = "Monday";
            //else if (day == 2)
            //    dayOfWeek = "Tuesday";
            //else if (day == 3)
            //    dayOfWeek = "Wednesday";
            //else if (day == 4)
            //    dayOfWeek = "Thursday";
            //else if (day == 5)
            //    dayOfWeek = "Friday";
            //else if (day == 6)
            //    dayOfWeek = "Saturday";
            //else if (day == 7)
            //    dayOfWeek = "Sunday";
            //else
            //    dayOfWeek = "Error";
            #endregion
        }
    }
}