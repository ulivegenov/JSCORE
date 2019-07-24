using _07InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Models
{
    public class Repository : IRepository
    {
        public Repository()
        {
            this.Weapons = new List<IWeapon>();
        }

        public IList<IWeapon> Weapons { get; private set; }

        public void AddWeapon(IWeapon weapon)
        {
            this.Weapons.Add(weapon);
        }
    }
}
