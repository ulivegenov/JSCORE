using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Models.Gems
{
   public class Amethyst : Gem
   {
        public Amethyst(ClarityEnum clarity) : base(clarity, 2, 8, 4)
        {
        }
    }
}
