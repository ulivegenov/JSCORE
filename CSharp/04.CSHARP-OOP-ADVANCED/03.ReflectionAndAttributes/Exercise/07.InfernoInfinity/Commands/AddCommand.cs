using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Enums;
using _07InfernoInfinity.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _07InfernoInfinity.Commands
{
    public class AddCommand : Command
    {
        public AddCommand(string data, IRepository repository):base(data, repository)
        {
        }

        public override void Execute()
        {
            string[] commandArgs = this.Data.Split(';');
            string weaponName = commandArgs[0];
            int slotIndex = int.Parse(commandArgs[1]);
            string[] gemArgs = commandArgs[2].Split();
            ClarityEnum clarity = (ClarityEnum)Enum.Parse(typeof(ClarityEnum), gemArgs[0], true);
            string gemName = gemArgs[1];

            GemFactory gemFactory = new GemFactory();
            IGem gem = gemFactory.CreateGem(clarity, gemName);

            this.Repository.Weapons
                           .FirstOrDefault(w => w.Name == weaponName)
                           .AddGem(slotIndex, gem);
        }
    }
}
