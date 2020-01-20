using AirCombat.Entities.Parts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirCombat.Entities.Parts
{
    public class EndurancePart : Part, IHitPointsModifyingPart
    {
        private int hitPointsModifier;
        public EndurancePart(string model, double weight, decimal price, int modifier)
            : base(model, weight, price)
        {
            this.HitPointsModifier = modifier;
        }

        public int HitPointsModifier
        {
            get
            {
                return this.hitPointsModifier;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("HitPoints cannot be less than zero!");
                }

                this.hitPointsModifier = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"+{this.HitPointsModifier} HitPoints";
        }
    }
}
