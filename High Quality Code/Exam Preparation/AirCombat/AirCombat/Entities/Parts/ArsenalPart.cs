using AirCombat.Entities.Parts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirCombat.Entities.Parts
{
    public class ArsenalPart : Part, IAttackModifyingPart
    {
        private int attackModifier;
        public ArsenalPart(string model, double weight, decimal price, int modifier)
            : base(model, weight, price)
        {
            this.AttackModifier = modifier;
        }

        public int AttackModifier
        {
            get
            {
                return this.attackModifier;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Attack cannot be less than zero!");
                }

                this.attackModifier = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"+{this.AttackModifier} Attack";
        }
    }
}
