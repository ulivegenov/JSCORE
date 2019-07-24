using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<ITraveler> travelers = new List<ITraveler>();
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] data = input.Split(' ');

            if (data.Length == 3)
            {
                ITraveler traveler = new Cititzen(data[2]);
                travelers.Add(traveler);
            }
            else if(data.Length == 2)
            {
                ITraveler traveler = new Robot(data[1]);
                travelers.Add(traveler);
            }
        }

        string lastDigits = Console.ReadLine();

        foreach (var traveler in travelers)
        {
            if (traveler.Id.Substring(traveler.Id.Length-lastDigits.Length) == lastDigits)
            {
                Console.WriteLine(traveler.Id);
            }
        }
    }
}

