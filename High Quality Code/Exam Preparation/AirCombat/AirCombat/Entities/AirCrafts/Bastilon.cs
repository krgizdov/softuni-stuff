﻿using AirCombat.Entities.Miscellaneous.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirCombat.Entities.AirCrafts
{
    public class Bastilon : AirCraft
    {
        public Bastilon(string model, double weight, decimal price, int attack, int defense, int hitPoints, IAssembler assembler) 
            : base(model, weight, price, attack, defense, hitPoints, assembler)
        {
        }
    }
}
