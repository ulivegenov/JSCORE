using System;
using System.Collections.Generic;
using System.Text;

namespace _07Hack
{
    public class Hack : IHack
    {
        public Hack(double negativeDouble)
        {
            this.NegativeDoubleValue = negativeDouble;
        }

        public double NegativeDoubleValue { get; private set; }

        public double AfterMathAbsValue()
        {
            return Math.Abs(this.NegativeDoubleValue);
        }

        public double AfterMathFloorValue()
        {
            return Math.Floor(this.NegativeDoubleValue);
        }
    }
}
