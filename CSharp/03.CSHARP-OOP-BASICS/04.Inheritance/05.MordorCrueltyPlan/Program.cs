using System;


public class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(new char[] {' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

        int tottalPointsOfHappiness = 0;

        foreach (var item in input)
        {
            FoodFactory foodFactory = new FoodFactory();
            Food currentFood = foodFactory.GetFood(item);
            tottalPointsOfHappiness += currentFood.PointsOfHappines;
        }

        MoodFactory moodFactory = new MoodFactory();
        
        Console.WriteLine(tottalPointsOfHappiness);
        Console.WriteLine(moodFactory.GetMood(tottalPointsOfHappiness));
    }
}

