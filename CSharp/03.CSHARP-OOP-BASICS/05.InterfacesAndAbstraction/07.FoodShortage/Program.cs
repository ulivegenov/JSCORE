using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int countOfPeople = int.Parse(Console.ReadLine());
        List<IBuyer> buyers = new List<IBuyer>();

        for (int i = 0; i < countOfPeople; i++)
        {
            string[] inpit = Console.ReadLine().Split(' ');

            if (inpit.Length == 4)
            {
                IBuyer citizen = new Citizen(inpit[0]);
                buyers.Add(citizen);
            }
            else if (inpit.Length == 3)
            {
                IBuyer rebel = new Rebel(inpit[0]);
                buyers.Add(rebel);
            }
        }

        string buyerName;

        while ((buyerName = Console.ReadLine()) != "End")
        {
            if (buyers.Any(b => b.Name == buyerName))
            {
                buyers.Find(b => b.Name == buyerName).BuyFood();
            }   
        }

        int tottalAmountFoodPurchase = 0;

        foreach (var buyer in buyers)
        {
            tottalAmountFoodPurchase += buyer.Food;
        }

        Console.WriteLine(tottalAmountFoodPurchase);
    }
}

