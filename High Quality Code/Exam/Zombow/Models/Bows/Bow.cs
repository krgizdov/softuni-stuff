using System;
using Zombow.Models.Bows.Contracts;

namespace Zombow.Models.Bows
{
    public abstract class Bow : IBow
    {
        private string name;
        private int quiverCapacity;
        private int totalArrows;

        protected Bow(string name,int quiverCapacity, int totalArrows)
        {
            this.name = name;
            this.QuiverCapacity = quiverCapacity;
            this.TotalArrows = totalArrows;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    //Might want to take a look
                    throw new ArgumentNullException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public int QuiverCapacity
        {
            get
            {
                return this.quiverCapacity;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Arrows cannot be below zero!");
                }
                this.quiverCapacity = value;
            }
        }

        public int TotalArrows
        {
            get
            {
                return this.totalArrows;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total arrows cannot be below zero!");
                }
                this.totalArrows = value;
            }
        }

        public bool CanShoot => this.TotalArrows > 0;

        public abstract int Shoot();
    }
}