using System;

namespace _05.CharacterStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string gameCharacterName = Console.ReadLine();
            int currentHealth = int.Parse(Console.ReadLine());
            int maxHealth = int.Parse(Console.ReadLine());
            int currentEnergy = int.Parse(Console.ReadLine());
            int maxEnergy = int.Parse(Console.ReadLine());

            char pipe = '|';
            char point = '.';

            string currentHealthPipes = new string(pipe, currentHealth + 1);
            string currentHealthPoints = new string(point, maxHealth - currentHealth);
            string currentEnergyPipes = new string(pipe, currentEnergy + 1);
            string currentEnergyPoints = new string(point, maxEnergy - currentEnergy);

            Console.WriteLine($"Name: {gameCharacterName}");
            Console.WriteLine($"Health: {currentHealthPipes}{currentHealthPoints}{pipe}");
            Console.WriteLine($"Energy: {currentEnergyPipes}{currentEnergyPoints}{pipe}");
        }
    }
}
