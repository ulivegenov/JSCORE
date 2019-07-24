using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Models.Gems
{
    public abstract class Gem : IGem
    {
        protected Gem(ClarityEnum clarity, int baseStrength, int baseAgility, int baseVitality)
        {
            this.Clarity = clarity;
            this.BaseStrength = baseStrength;
            this.BaseAgility = baseAgility;
            this.BaseVitality = baseVitality;
        }

        public ClarityEnum Clarity { get; private set; }

        public int BaseStrength { get; private set; }

        public int BaseAgility { get; private set; }

        public int BaseVitality { get; private set; }

        public int Strength
        {
            get
            {
                return this.BaseStrength + (int)this.Clarity;
            }
        }

        public int Agility
        {
            get
            {
                return this.BaseAgility + (int)this.Clarity;
            }
        }

        public int Vitality
        {
            get
            {
                return this.BaseVitality + (int)this.Clarity;
            }
        }
    }
}
