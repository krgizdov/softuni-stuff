using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int depositTerm = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());

            double sumToGet = deposit + depositTerm * (deposit * interest / 100 / 12);

            Console.WriteLine(sumToGet);
        }
    }
}
