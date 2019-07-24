using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Enums;
using _07InfernoInfinity.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Commands
{
    public class CreateCommand : Command
    {
        public CreateCommand(string data, IRepository repository):base(data, repository)
        {
        }

        public override void Execute()
        {
            string[] commandArgs = this.Data.Split(';');
            string[] weaponArgs = commandArgs[0].Split();
            RarityEnum rarity = (RarityEnum)Enum.Parse(typeof(RarityEnum), weaponArgs[0], true);
            string weaponType = weaponArgs[1];
            string weaponName = commandArgs[1];

            WeaponFactory weaponFactory = new WeaponFactory();
            IWeapon weapon = weaponFactory.CreateWeapon(rarity, weaponType, weaponName);
            this.Repository.AddWeapon(weapon);
        }
    }
}
