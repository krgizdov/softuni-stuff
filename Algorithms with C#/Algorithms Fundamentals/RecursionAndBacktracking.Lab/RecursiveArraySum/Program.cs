using System;
using System.Linq;

namespace RecursiveArraySum
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Console.WriteLine(GetArraySum(numbers, 0));
        }

        private static int GetArraySum(int[] numbers, int startIndex)
        {
            if (startIndex < numbers.Length)
            {
                return numbers[startIndex] + GetArraySum(numbers, startIndex + 1);
            }

            return 0;
        }
    }
}
