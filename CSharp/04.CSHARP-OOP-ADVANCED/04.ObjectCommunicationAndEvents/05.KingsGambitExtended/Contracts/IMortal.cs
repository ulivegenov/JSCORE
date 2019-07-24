namespace _05KingsGambit.Contracts
{
    public delegate void MortalDeathEventHandler(object sender);

    public interface IMortal : INameble
    {
        int HitPoints { get; }

        string Action { get; }

        bool IsAlive { get; }

        event MortalDeathEventHandler DeathEvent;

        void GetHit();

        void ReactToAttack();
    }
}
