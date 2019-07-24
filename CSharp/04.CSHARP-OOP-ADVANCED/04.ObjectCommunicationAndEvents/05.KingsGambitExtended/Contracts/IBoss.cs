namespace _05KingsGambit.Contracts
{
    using System.Collections.Generic;

    public interface IBoss
    {
        IReadOnlyCollection<IMortal> Mortals { get; }

        void AddMortal(IMortal mortal);

        void OnMortalDeath(object sender);
    }
}
