namespace _05KingsGambit.Models
{
    using System;
    using Contracts;

    public abstract class Mortal : IMortal
    {
        public Mortal(string name, string action, int hitPoints)
        {
            this.Name = name;
            this.HitPoints = hitPoints;
            this.IsAlive = true;
            this.Action = action;
        }

        public string Name { get; private set; }

        public int HitPoints { get; private set; }

        public string Action { get; private set; }

        public bool IsAlive { get; private set; }

        public event MortalDeathEventHandler DeathEvent;

        public void GetHit()
        {
            this.HitPoints--;

            if (this.HitPoints <= 0)
            {
                this.IsAlive = false;

                if (this.DeathEvent != null)
                {
                    this.DeathEvent.Invoke(this);
                }
            }
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
