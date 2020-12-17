using System;
using System.Collections.Generic;

namespace SchoolTeams
{
    class Program
    {
        private const int girlTeamCount = 3;
        private const int boyTeamCount = 2;
        static void Main()
        {
            var girls = Console.ReadLine().Split(", ");
            var boys = Console.ReadLine().Split(", ");

            var girlCombs = new string[girlTeamCount];
            List<string> girlCombsList = new List<string>();
            Comb(0, 0, girls, girlCombs, girlCombsList);

            var boyCombs = new string[boyTeamCount];
            List<string> boyCombsList = new List<string>();
            Comb(0, 0, boys, boyCombs, boyCombsList);

            PrintCombs(girlCombsList, boyCombsList);
        }

        private static void Comb(
            int combIdx, int elementsStartIdx,
            string[] elements, string[] combs, List<string> listToAdd)
        {
            if (combIdx >= combs.Length)
            {
                listToAdd.Add(string.Join(", ", combs));
                return;
            }

            for (int i = elementsStartIdx; i < elements.Length; i++)
            {
                combs[combIdx] = elements[i];
                Comb(combIdx + 1, i + 1, elements, combs, listToAdd);
            }
        }

        private static void PrintCombs(List<string> girlCombsList, List<string> boyCombsList)
        {
            foreach (var girlComb in girlCombsList)
            {
                foreach (var boyComb in boyCombsList)
                {
                    Console.WriteLine($"{girlComb}, {boyComb}");
                }
            }
        }
    }
}
