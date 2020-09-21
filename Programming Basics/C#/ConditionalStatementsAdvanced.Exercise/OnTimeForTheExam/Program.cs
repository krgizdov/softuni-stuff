using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            TimeSpan examTime = new TimeSpan(examHour, examMinutes, 0);
            TimeSpan arrivalTime = new TimeSpan(arrivalHour, arrivalMinutes, 0);

            var timeDifference = examTime.Subtract(arrivalTime);

            string result;

            if (timeDifference.TotalMinutes >= 0 && timeDifference.TotalMinutes <= 30)
            {
                result = "On time";

                if (timeDifference.TotalMinutes != 0)
                {
                    result += $"\r\n{timeDifference.Minutes} minutes before the start";
                }
            }
            else if (timeDifference.TotalMinutes < 0)
            {
                result = "Late";

                if (timeDifference.Hours != 0)
                {
                    result += $"\r\n{Math.Abs(timeDifference.Hours)}:{Math.Abs(timeDifference.Minutes):d2} hours after the start";
                }
                else
                {
                    result += $"\r\n{Math.Abs(timeDifference.Minutes)} minutes after the start";
                }
            }
            else 
            {
                result = "Early";

                if (timeDifference.Hours != 0)
                {
                    result += $"\r\n{timeDifference.Hours}:{timeDifference.Minutes:d2} hours before the start";
                }
                else
                {
                    result += $"\r\n{timeDifference.Minutes} minutes before the start";
                }
            }

            Console.WriteLine(result);
        }
    }
}
