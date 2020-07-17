using System;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstCompetitorTime = int.Parse(Console.ReadLine());
            int secondCompetitorTime = int.Parse(Console.ReadLine());
            int thirdCompetitorTime = int.Parse(Console.ReadLine());

            int totalTime = firstCompetitorTime + secondCompetitorTime + thirdCompetitorTime;

            int minutes = totalTime / 60;
            int seconds = totalTime % 60;

            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
