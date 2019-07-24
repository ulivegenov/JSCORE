namespace _02KingsGambit.Models
{
    using System;
    using Contracts;

    public abstract class Mortal : IMortal
    {
        public Mortal(string name, string action)
        {
            this.Name = name;
            this.IsAlive = true;
            this.Action = action;
        }

        public string Name { get; private set; }

        public string Action { get; private set; }

        public bool IsAlive { get; private set; }

        public void Die()
        {
            this.IsAlive = false;
        }

        public virtual void ReactToAttack()
        {
            if (this.IsAlive)
            {
                Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");
            }  
        }
    }
}
