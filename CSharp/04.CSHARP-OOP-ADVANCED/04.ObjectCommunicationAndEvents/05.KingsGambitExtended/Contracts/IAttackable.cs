namespace _05KingsGambit.Contracts
{
    public delegate void GetAttackedEventHandler();

    public interface IAttackable : INameble
    {
        event GetAttackedEventHandler GetAttackedEvent;

        void GetAttacked();
    }
}
