using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberToConvert = double.Parse(Console.ReadLine());
            string inputMetric = Console.ReadLine();
            string outputMetric = Console.ReadLine();

            numberToConvert = ConvertNumberToMeter(numberToConvert, inputMetric);

            string result = ConvertNumberToOutputMetric(numberToConvert, outputMetric);

            Console.WriteLine(result);
        }

        public static double ConvertNumberToMeter(double numberToConvert, string inputMetric)
        {
            if (inputMetric == "mm")
            {
                return numberToConvert * 0.001;
            }
            else if (inputMetric == "cm")
            {
                return numberToConvert * 0.01;
            }

            return numberToConvert;
        }

        public static string ConvertNumberToOutputMetric(double numberToConvert, string outputMetric)
        {
            if (outputMetric == "mm")
            {
                return $"{numberToConvert * 1000:f3}";
            }
            else if (outputMetric == "cm")
            {
                return $"{numberToConvert * 100:f3}";
            }

            return $"{numberToConvert:f3}";
        }
    }
}
