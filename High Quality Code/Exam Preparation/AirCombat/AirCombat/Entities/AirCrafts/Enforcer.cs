﻿using AirCombat.Entities.Miscellaneous.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirCombat.Entities.AirCrafts
{
    public class Enforcer : AirCraft
    {
        public Enforcer(string model, double weight, decimal price, int attack, int defense, int hitPoints, IAssembler assembler) 
            : base(model, weight, price, attack, defense, hitPoints, assembler)
        {
        }
    }
}
