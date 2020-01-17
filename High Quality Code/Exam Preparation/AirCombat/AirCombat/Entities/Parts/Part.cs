namespace AirCombat.Entities.Parts
{
    using System;

    using Contracts;

    public abstract class Part : IPart
    {
        private string model;
        private double weight;
        private decimal price;

        public Part(string type, string model, double weight, decimal price, int modifier)
        {
            this.Model = model;
            this.Weight = weight;
            this.Price = price;
            this.Type = type;
            this.Modifier = modifier;
        }

        public string Type { get; private set; }

        public int Modifier { get; private set; }

        public string Model
        {
            get
            {
                return this.model;
            }
             set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or white space!");
                }

                this.model = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Weight cannot be less or equal to zero!");
                }

                this.weight = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }

                this.price = value;
            }
        }

        //public override string ToString()
        //{
        //    string partName = this.GetType().Name.Replace("Part", "");
        //    string result = $"{partName} Part - {this.Model}";

        //    if (this.Type == "ArsenalPart")
        //    {
        //        result += $"+{this.Modifier} Attack";
        //    }
        //    else if (this.Type == "EndurancePart")
        //    {
        //        result += $"+{this.Modifier} HitPoints";
        //    }
        //    else if (this.Type == "ShellPart")
        //    {
        //        result += $"+{this.Modifier} Defense";
        //    }

        //    return result;
        //}
    }
}