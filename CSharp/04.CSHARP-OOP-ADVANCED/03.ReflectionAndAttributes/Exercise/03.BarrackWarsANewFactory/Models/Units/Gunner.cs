namespace _03BarracksFactory.Models.Units
{
    class Gunner : Unit
    {
        private const int DefaultHealth = 40;
        private const int DefaultDamage = 13;

        public Gunner():base(DefaultHealth, DefaultDamage)
        {
        }
    }
}
