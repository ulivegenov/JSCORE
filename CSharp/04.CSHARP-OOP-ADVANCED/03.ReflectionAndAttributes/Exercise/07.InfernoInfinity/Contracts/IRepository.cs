using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Contracts
{
    public interface IRepository
    {
        IList<IWeapon> Weapons { get; }

        void AddWeapon(IWeapon weapon);
    }
}
