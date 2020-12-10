using System;
using System.Numerics;

namespace RecursiveFactorial
{
    class Program
    {
        static void Main()
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());

            if (number < 0)
            {
                throw new ArgumentException("Number should be more than or equal zero!");
            }

            Console.WriteLine(GetFactorial(number));
        }

        private static BigInteger GetFactorial(BigInteger number)
        {
            if (number == 0) 
            { 
                return 1;
            }

            return number * GetFactorial(number - 1);
        }
    }
}
