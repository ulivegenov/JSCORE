using _07InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07InfernoInfinity.Commands
{
    public class RemoveCommand : Command
    {
        public RemoveCommand(string data, IRepository repository) : base(data, repository)
        {
        }

        public override void Execute()
        {
            string[] commandArgs = this.Data.Split(';');
            string weaponName = commandArgs[0];
            int slotIndex = int.Parse(commandArgs[1]);

            this.Repository.Weapons.FirstOrDefault(w => w.Name == weaponName).RemoveGem(slotIndex);
        }
    }
}
