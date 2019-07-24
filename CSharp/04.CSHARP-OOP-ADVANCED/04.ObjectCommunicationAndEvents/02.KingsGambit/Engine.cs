namespace _02KingsGambit
{
    using System;
    using System.Linq;
    using Contracts;

    public class Engine
    {
        private IKing king;

        public Engine(IKing king)
        {
            this.king = king;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                if (command == "Attack")
                {
                    king.GetAttacked();
                }
                else if (command == "Kill")
                {
                    string mortalName = tokens[1];
                    IMortal mortal = king.Mortals.First(m => m.Name == mortalName);
                    mortal.Die();
                }
            }
        }
    }
}
