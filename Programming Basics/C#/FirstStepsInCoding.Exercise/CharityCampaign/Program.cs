using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            const int cakePrice = 45;
            const double wafflePrice = 5.80;
            const double pancakePrice = 3.20;

            int campaignDays = int.Parse(Console.ReadLine());
            int confectioners = int.Parse(Console.ReadLine());
            int cakesAmount = int.Parse(Console.ReadLine());
            int wafflesAmount = int.Parse(Console.ReadLine());
            int pancakesAmount = int.Parse(Console.ReadLine());

            double dailyCakeMoney = cakesAmount * cakePrice;
            double dailyWaffleMoney = wafflesAmount * wafflePrice;
            double dailyPancakeMoney = pancakesAmount * pancakePrice;

            double totalCampaignMoney = confectioners * (dailyCakeMoney + dailyWaffleMoney + dailyPancakeMoney) * campaignDays;
            double expenses = totalCampaignMoney * 0.125;

            Console.WriteLine(totalCampaignMoney - expenses);
        }
    }
}
