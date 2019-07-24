using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        public Knife(RarityEnum rarity, string name) : base(rarity, name, 3, 4, 2)
        {
        }
    }
}
