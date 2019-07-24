using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Models.Gems
{
    public class Emerald : Gem
    {
        public Emerald(ClarityEnum clarity) : base(clarity, 1, 4, 9)
        {
        }
    }
}
