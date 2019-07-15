using System;

namespace _08.CaloriesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int totalCalories = 0;

            for (int currentIngredient = 0; currentIngredient < num; currentIngredient++)
            {
                string nameOfIngredient = Console.ReadLine().ToLower();

                if (nameOfIngredient == "cheese")
                {
                    totalCalories += 500;
                }
                else if (nameOfIngredient == "tomato sauce")
                {
                    totalCalories += 150;
                }
                else if (nameOfIngredient == "salami")
                {
                    totalCalories += 600;
                }
                else if (nameOfIngredient == "pepper")
                {
                    totalCalories += 50;
                }
            }

            Console.WriteLine($"Total calories: {totalCalories}");
        }
    }
}
