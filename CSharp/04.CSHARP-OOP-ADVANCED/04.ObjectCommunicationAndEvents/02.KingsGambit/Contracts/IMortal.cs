namespace _02KingsGambit.Contracts
{
    public interface IMortal : INameble
    {
        string Action { get; }

        bool IsAlive { get; }

        void Die();

        void ReactToAttack();
    }
}
