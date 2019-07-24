namespace _05KingsGambit.Models
{
    using System;

    public class RoyalGuard : Mortal
    {
        public RoyalGuard(string name):base(name, "defending", 3)
        {
        }

        public override void ReactToAttack()
        {
            if (this.IsAlive)
            {
                Console.WriteLine($"Royal Guard {this.Name} is {this.Action}!");
            }
        }
    }
}
