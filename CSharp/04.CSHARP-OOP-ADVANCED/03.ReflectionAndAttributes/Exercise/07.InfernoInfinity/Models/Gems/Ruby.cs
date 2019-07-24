using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        public Ruby(ClarityEnum clarity) : base(clarity, 7, 2, 5)
        {
        }
    }
}
