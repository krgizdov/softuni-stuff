using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());

            string result;

            if (averageGrade < 4.50 || (minimalSalary < income && averageGrade < 5.50))
            {
                result = "You cannot get a scholarship!";
            }
            else if (averageGrade < 5.50)
            {
                result = $"You get a Social scholarship {CalculateSocialScholarship(minimalSalary)} BGN";
            }
            else if (minimalSalary < income)
            {
                result = $"You get a scholarship for excellent results {CalculateExcellentScholarship(averageGrade)} BGN";
            }
            else
            {
                double socialScholarship = CalculateSocialScholarship(minimalSalary);
                double excellentScholarship = CalculateExcellentScholarship(averageGrade);

                if (socialScholarship > excellentScholarship)
                {
                    result = $"You get a Social scholarship {socialScholarship} BGN";
                }
                else
                {
                    result = $"You get a scholarship for excellent results {excellentScholarship} BGN";
                }
            }

            Console.WriteLine(result);
        }
        public static double CalculateSocialScholarship(double minimalSalary)
        {
            return Math.Floor(minimalSalary * 0.35);
        }

        public static double CalculateExcellentScholarship(double averageGrade)
        {
            return Math.Floor(averageGrade * 25);
        }
    }
}
