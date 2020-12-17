using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema
{
    class Program
    {
        private static List<string> names = new List<string>();
        private static readonly HashSet<int> lockedSeats = new HashSet<int>();
        private static string[] seats;

        static void Main()
        {
            names = Console.ReadLine().Split(", ").ToList();

            seats = new string[names.Count];

            FillSeats();

            Permute(0);
        }

        private static void FillSeats()
        {
            string line;
            while ((line = Console.ReadLine()) != "generate")
            {
                var nameSeatPair = line.Split(" - ");
                var name = nameSeatPair[0];
                var seat = int.Parse(nameSeatPair[1]) - 1;

                seats[seat] = name;
                lockedSeats.Add(seat);
                names.Remove(name);
            }
        }

        private static void Permute(int index)
        {
            if (index >= names.Count)
            {
                var nameIdx = 0;
                for (int i = 0; i < seats.Length; i++)
                {
                    if (!lockedSeats.Contains(i))
                    {
                        seats[i] = names[nameIdx];
                        nameIdx++;
                    }
                }

                Console.WriteLine(string.Join(" ", seats));
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < names.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = names[first];
            names[first] = names[second];
            names[second] = temp;
        }
    }
}
