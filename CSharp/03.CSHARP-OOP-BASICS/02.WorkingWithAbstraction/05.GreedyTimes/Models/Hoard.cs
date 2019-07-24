using System;
using System.Collections.Generic;
using System.Text;

namespace _05GreedyTimes.Models
{
    public abstract class Hoard
    {
        public Hoard(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"##{this.Name} - {this.Quantity}"; 
        }
    }
}
