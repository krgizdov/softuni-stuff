using System;
using System.Linq;

namespace RoadTrip
{
    class Item
    {
        public Item(int value, int space)
        {
            Value = value;
            Space = space;
        }

        public int Value { get; set; }

        public int Space { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var items = ReadItems();

            var maxCapacity = int.Parse(Console.ReadLine());

            var table = new int[items.Length + 1, maxCapacity + 1];

            PickBestItems(items, table);

            Console.WriteLine($"Maximum value: {table[items.Length, maxCapacity]}");
        }

        private static void PickBestItems(Item[] items, int[,] table)
        {
            for (int row = 1; row < table.GetLength(0); row++)
            {
                var currentItem = items[row - 1];

                for (int capacity = 1; capacity < table.GetLength(1); capacity++)
                {
                    var skip = table[row - 1, capacity];

                    if (currentItem.Space > capacity)
                    {
                        table[row, capacity] = skip;
                        continue;
                    }

                    var take = table[row - 1, capacity - currentItem.Space] + currentItem.Value;

                    if (take > skip)
                    {
                        table[row, capacity] = take;
                    }
                    else
                    {
                        table[row, capacity] = skip;
                    }
                }
            }
        }

        private static Item[] ReadItems()
        {
            var itemValues = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var itemCosts = Console.ReadLine()
                 .Split(", ")
                 .Select(int.Parse)
                 .ToArray();

            var items = new Item[itemValues.Length];

            for (int e = 0; e < itemValues.Length; e++)
            {
                items[e] = new Item(itemValues[e], itemCosts[e]);
            }

            return items;
        }
    }
}
