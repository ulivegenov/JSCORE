using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Enums;
using _07InfernoInfinity.Models.Gems;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        public Axe(RarityEnum rarity, string name) : base(rarity, name, 5, 10, 4)
        {
        }
    }
}
