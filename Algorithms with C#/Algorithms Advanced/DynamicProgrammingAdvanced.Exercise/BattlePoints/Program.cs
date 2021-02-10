using System;
using System.Linq;

namespace BattlePoints
{
    class Enemy
    {
        public Enemy(int cost, int reward)
        {
            Cost = cost;
            Reward = reward;
        }

        public int Cost { get; set; }

        public int Reward { get; set; }
    }

    class Program
    {
        //private static bool[,] _included;

        static void Main()
        {
            var enemies = ReadEnemies();

            var maxEnergy = int.Parse(Console.ReadLine());

            var table = new int[enemies.Length + 1, maxEnergy + 1];
            //_included = new bool[enemies.Length + 1, maxEnergy + 1];

            PickBestRewards(enemies, table);

            //PrintChosenEnemies(enemies, maxEnergy);

            Console.WriteLine(table[enemies.Length, maxEnergy]);
        }

        //private static void PrintChosenEnemies(Enemy[] enemies, int maxEnergy)
        //{
        //    var currentEnergy = maxEnergy;

        //    for (int row = enemies.Length; row >= 0; row--)
        //    {
        //        if (_included[row, currentEnergy])
        //        {
        //            Console.WriteLine(row - 1);
        //            currentEnergy -= enemies[row - 1].Cost;

        //            if (currentEnergy == 0)
        //            {
        //                break;
        //            }
        //        }
        //    }
        //}

        private static void PickBestRewards(Enemy[] enemies, int[,] table)
        {
            for (int row = 1; row < table.GetLength(0); row++)
            {
                var currentEnemy = enemies[row - 1];

                for (int energy = 1; energy < table.GetLength(1); energy++)
                {
                    var skip = table[row - 1, energy];

                    if (currentEnemy.Cost > energy)
                    {
                        table[row, energy] = skip;
                        continue;
                    }

                    var take = table[row - 1, energy - currentEnemy.Cost] + currentEnemy.Reward;

                    if (take > skip)
                    {
                        table[row, energy] = take;
                        //_included[row, energy] = true;
                    }
                    else
                    {
                        table[row, energy] = skip;
                    }
                }
            }
        }

        private static Enemy[] ReadEnemies()
        {
            var enemyCosts = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray(); 
            
            var enemyRewards = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            var enemies = new Enemy[enemyCosts.Length];

            for (int e = 0; e < enemyCosts.Length; e++)
            {
                enemies[e] = new Enemy(enemyCosts[e], enemyRewards[e]);
            }

            return enemies;
        }
    }
}
