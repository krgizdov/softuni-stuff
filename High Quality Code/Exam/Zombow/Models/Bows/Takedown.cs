using System;
using System.Collections.Generic;
using System.Text;
using Zombow.Models.Bows;

namespace ViceCity.Models
{
    public class Takedown : Bow
    {
        private const int quiverCapacity = 50;
        private const int totalArrows = 500;
        private const int damage = 5;
        public Takedown(string name) 
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
