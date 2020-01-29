using System;
using System.Collections.Generic;
using System.Text;
using Zombow.Models.Bows;

namespace ViceCity.Models.Bows
{
    public class Recurve : Bow
    {
        private const int quiverCapacity = 10;
        private const int totalArrows = 100;
        private const int damage = 1;

        public Recurve(string name) 
            : base(name, quiverCapacity, totalArrows)
        {
        }

        public override int Shoot()
        {
            if (this.QuiverCapacity == 0)
            {
                this.QuiverCapacity += quiverCapacity;
                this.TotalArrows -= quiverCapacity;

                if (!this.CanShoot)
                {
                    return 0;
                }
            }
            this.QuiverCapacity--;
            return damage;
        }
    }
}
