using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _07InfernoInfinity.Contracts;

namespace _07InfernoInfinity.Commands
{
    class PrintCommand : Command
    {
        public PrintCommand(string data, IRepository repository) : base(data, repository)
        {
        }

        public override void Execute()
        {
            string[] commandArgs = this.Data.Split(';');
            string weaponName = commandArgs[0];
            IWeapon weapon = this.Repository.Weapons.FirstOrDefault(w => w.Name == weaponName);
            Console.WriteLine(weapon);
        }
    }
}
