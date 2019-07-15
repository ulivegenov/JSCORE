using System;

namespace _07.CakeIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string ingredient = Console.ReadLine();
            int countOfingredients = 0;

            while (ingredient != "Bake!")
            {
                countOfingredients++;
                Console.WriteLine($"Adding ingredient {ingredient}.");
                ingredient = Console.ReadLine();
            }

            Console.WriteLine($"Preparing cake with {countOfingredients} ingredients.");
        }
    }
}
