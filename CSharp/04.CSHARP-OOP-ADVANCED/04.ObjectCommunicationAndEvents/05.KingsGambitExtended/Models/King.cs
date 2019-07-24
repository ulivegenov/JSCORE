namespace _05KingsGambit.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class King : IKing
    {
        private ICollection<IMortal> mortals;

        public King(string name, ICollection<IMortal> mortals)
        {
            this.Name = name;
            this.mortals = mortals;
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<IMortal> Mortals => (IReadOnlyCollection<IMortal>)this.mortals;

        public event GetAttackedEventHandler GetAttackedEvent;

        public void AddMortal(IMortal mortal)
        {
            this.mortals.Add(mortal);
            this.GetAttackedEvent += mortal.ReactToAttack;
            mortal.DeathEvent += this.OnMortalDeath;
        }

        public void GetAttacked()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is under attack!");

            if (this.GetAttackedEvent != null)
            {
                this.GetAttackedEvent.Invoke();
            }
        }

        public void OnMortalDeath(object sender)
        {
            this.mortals.Remove((IMortal)sender);
        }
    }
}
