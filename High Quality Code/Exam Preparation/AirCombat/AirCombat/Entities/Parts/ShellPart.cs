using AirCombat.Entities.Parts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirCombat.Entities.Parts
{
    public class ShellPart : Part, IDefenseModifyingPart
    {
        private int defenseModifier;
        public ShellPart(string model, double weight, decimal price, int modifier)
            : base(model, weight, price)
        {
            this.DefenseModifier = modifier;
        }

        public int DefenseModifier
        {
            get
            {
                return this.defenseModifier;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Defense cannot be less than zero!");
                }

                this.defenseModifier = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"+{this.DefenseModifier} Defense";
        }
    }
}
