using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _07InfernoInfinity.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(RarityEnum Rarity, string weaponType, string weaponName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == weaponType);

            if (type == null)
            {
                throw new ArgumentException("Invalid Weapon Type!");
            }

            if (!(typeof(IWeapon).IsAssignableFrom(type)))
            {
                throw new ArgumentException($"{type} is not a Weapon!");
            }

            return (IWeapon)Activator.CreateInstance(type,new object[] {Rarity, weaponName });
        }
    }
}
