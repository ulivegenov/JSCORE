namespace _05KingsGambit
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IKing king = SetUpKing();

            Engine engine = new Engine(king);
            engine.Run();
        }

        private static IKing SetUpKing()
        {
            string kingName = Console.ReadLine();
            IKing king = new King(kingName, new List<IMortal>());

            string[] royalGuardNames = Console.ReadLine().Split();
            foreach (var royalGuardName in royalGuardNames)
            {
                king.AddMortal(new RoyalGuard(royalGuardName));
            }

            string[] footmanNames = Console.ReadLine().Split();
            foreach (var footmanName in footmanNames)
            {
                king.AddMortal(new Footman(footmanName));
            }

            return king;
        }
    }
}
