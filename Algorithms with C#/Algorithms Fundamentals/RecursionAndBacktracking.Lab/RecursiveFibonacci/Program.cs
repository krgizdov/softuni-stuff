using System;
using System.Collections.Generic;
using System.Numerics;

namespace RecursiveFibonacci
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            //Saving the values in a dictionary/array to reduce the amount of operations!

            var calculated = new Dictionary<BigInteger, BigInteger>();
            //var calculated = new BigInteger[number + 1];

            Console.WriteLine(GetFibonacci(number, calculated)); 
        }

        private static BigInteger GetFibonacci(int number, /*BigInteger[] calculated*/ Dictionary<BigInteger, BigInteger> calculated)
        {
            if (number <= 1)
            {
                return 1;
            }

            #region Regarding the sequence.
            //To pass in SoftUni judge system it must return 1 both when the number is 0 and 1!
            //To make it like the official Fibonacci numbers we must return 1 when the number is 1 and 0 when the number is 0
            //if (number == 0)
            //{
            //    return 0;
            //}
            #endregion

            #region With Dictionary
            if (calculated.ContainsKey(number))
            {
                return calculated[number];
            }

            calculated[number] = GetFibonacci(number - 1, calculated) + GetFibonacci(number - 2, calculated);

            return calculated[number];
            #endregion

            #region With Array
            //if (calculated[number] != 0)
            //{
            //    return calculated[number];
            //}

            //calculated[number] = GetFibonacci(number - 1, calculated) + GetFibonacci(number - 2, calculated);

            //return calculated[number];
            #endregion
        }
    }
}
