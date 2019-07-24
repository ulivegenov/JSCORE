using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _05GreedyTimes.Models
{
    public class Bag
    {
        private List<Hoard> goldItmes;
        private List<Hoard> gemItems;
        private List<Hoard> cashItems;
        private long goldQuantity = 0;
        private long gemQuantity = 0;
        private long cashQuantity = 0;

        public Bag(long capacity)
        {
            this.Capacity = capacity;
            this.goldItmes = new List<Hoard>();
            this.gemItems = new List<Hoard>();
            this.cashItems = new List<Hoard>();
        }

        public long Capacity { get; set; }

        public void AddGoldItem(Hoard goldItem)
        {
            if (goldItem.Quantity <= this.Capacity)
            {
                this.goldItmes.Add(goldItem);
                this.Capacity -= goldItem.Quantity;
                this.goldQuantity += goldItem.Quantity;
            }
        }

        public void AddGemItem(Hoard gemItem)
        {
            if (gemItem.Quantity <= this.Capacity && ((gemItem.Quantity + this.gemQuantity) <= this.goldQuantity))
            {
                this.gemItems.Add(gemItem);
                this.Capacity -= gemItem.Quantity;
                this.gemQuantity += gemItem.Quantity;
            }
        }

        public void AddCashItem(Hoard cashItem)
        {
            if (cashItem.Quantity <= this.Capacity && (cashItem.Quantity + this.cashQuantity) <= this.gemQuantity)
            {
                this.cashItems.Add(cashItem);
                this.Capacity -= cashItem.Quantity;
                this.cashQuantity += cashItem.Quantity;
            }
        }

        public override string ToString()
        {
            string output;

            this.gemItems = this.gemItems.OrderByDescending(g => g.Name).ThenBy(g => g.Quantity).ToList();
            this.cashItems = this.cashItems.OrderByDescending(g => g.Name).ThenBy(g => g.Quantity).ToList();

            if (this.cashQuantity > 0)
            {
                output = $"<Gold> ${this.goldQuantity}{Environment.NewLine}" +
                         $"##Gold - {this.goldQuantity}{Environment.NewLine}" +
                         $"<Gem> ${this.gemQuantity}{Environment.NewLine}" +
                         $"{string.Join(Environment.NewLine, this.gemItems)}{Environment.NewLine}" +
                         $"<Cash> ${this.cashQuantity}{Environment.NewLine}" +
                         $"{string.Join(Environment.NewLine, this.cashItems)}";
            }
            else if (this.gemQuantity > 0)
            {
                output = $"<Gold> ${this.goldQuantity}{Environment.NewLine}" +
                         $"##Gold - {this.goldQuantity}{Environment.NewLine}" +
                         $"<Gem> ${this.gemQuantity}{Environment.NewLine}" +
                         $"{string.Join(Environment.NewLine, this.gemItems)}{Environment.NewLine}";
            }
            else
            {
                output = $"<Gold> ${this.goldQuantity}{Environment.NewLine}" +
                         $"##Gold - {this.goldQuantity}{Environment.NewLine}";
            }

            return output;
        }
    }
}
