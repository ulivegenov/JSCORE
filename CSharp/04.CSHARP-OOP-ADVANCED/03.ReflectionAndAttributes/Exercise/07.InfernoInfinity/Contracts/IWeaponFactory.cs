using _07InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(RarityEnum Rarity, string weaponType, string weaponName);
    }
}
