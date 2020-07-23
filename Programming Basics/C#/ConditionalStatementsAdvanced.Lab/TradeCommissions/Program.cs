﻿using System;

namespace TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            double commission = 0;

            if (sales >= 0 && sales <= 500)
            {
                if (town == "Sofia")
                    commission = sales * 0.05;
                else if (town == "Varna")
                    commission = sales * 0.045;
                else if (town == "Plovdiv")
                    commission = sales * 0.055;
            }
            else if (sales > 500 && sales <= 1000)
            {
                if (town == "Sofia")
                    commission = sales * 0.07;
                else if (town == "Varna")
                    commission = sales * 0.075;
                else if (town == "Plovdiv")
                    commission = sales * 0.08;
            }
            else if (sales > 1000 && sales <= 10000)
            {
                if (town == "Sofia")
                    commission = sales * 0.08;
                else if (town == "Varna")
                    commission = sales * 0.1;
                else if (town == "Plovdiv")
                    commission = sales * 0.12;

            }
            else if (sales > 10000)
            {
                if (town == "Sofia")
                    commission = sales * 0.12;
                else if (town == "Varna")
                    commission = sales * 0.13;
                else if (town == "Plovdiv")
                    commission = sales * 0.145;
            }

            if (commission != 0)
                Console.WriteLine($"{commission:f2}");
            else
                Console.WriteLine("error");
        }
    }
}
