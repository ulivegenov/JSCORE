namespace _02KingsGambit.Contracts
{
    using System.Collections.Generic;

    public interface IBoss
    {
        IReadOnlyCollection<IMortal> Mortals { get; }

        void AddMortal(IMortal mortal);
    }
}
