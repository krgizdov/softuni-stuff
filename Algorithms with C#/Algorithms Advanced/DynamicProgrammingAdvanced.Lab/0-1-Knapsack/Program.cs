using System;
using System.Collections.Generic;

namespace _0_1_Knapsack
{
    class Item
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int Value { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var maxCapacity = int.Parse(Console.ReadLine());

            var items = ReadItems();

            var table = new int[items.Count + 1, maxCapacity + 1];

            PickBestItems(items, table);

            PrintChosenItems(items, table);
        }

        private static void PrintChosenItems(List<Item> items, int[,] table)
        {
            var selectedItems = new SortedSet<string>();
            var usedWeight = 0;
            var totalValue = 0;

            var row = table.GetLength(0) - 1;
            var col = table.GetLength(1) - 1;

            while (row > 0 && col > 0)
            {
                if (table[row, col] != table[row - 1, col])
                {
                    var selectedItem = items[row - 1];

                    selectedItems.Add(selectedItem.Name);
                    usedWeight += selectedItem.Weight;
                    totalValue += selectedItem.Value;

                    col -= selectedItem.Weight;
                }

                row--;
            }

            Console.WriteLine($"Total Weight: {usedWeight}");
            Console.WriteLine($"Total Value: {totalValue}");
            foreach (var item in selectedItems)
            {
                Console.WriteLine(item);
            }
        }

        private static void PickBestItems(List<Item> items, int[,] table)
        {
            for (int row = 1; row < table.GetLength(0); row++)
            {
                var currentItem = items[row - 1];

                for (int capacity = 1; capacity < table.GetLength(1); capacity++)
                {
                    if (currentItem.Weight > capacity)
                    {
                        table[row, capacity] = table[row - 1, capacity];
                    }
                    else
                    {
                        table[row, capacity] = Math.Max(
                            table[row - 1, capacity],
                            table[row - 1, capacity - currentItem.Weight] + currentItem.Value);
                    }
                }
            }
        }

        private static List<Item> ReadItems()
        {
            var items = new List<Item>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                var itemData = line.Split();

                var name = itemData[0];
                var weight = int.Parse(itemData[1]);
                var value = int.Parse(itemData[2]);

                var item = new Item
                {
                    Name = name,
                    Weight = weight,
                    Value = value
                };

                items.Add(item);
            }

            return items;
        }
    }
}
