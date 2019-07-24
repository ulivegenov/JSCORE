using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<IBirthday> birthdates = new List<IBirthday>();
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] data = input.Split(' ');

            switch (data[0])
            {
                case "Citizen":
                    IBirthday citizen = new Citizen(data[4]);
                    birthdates.Add(citizen);
                    break;
                case "Pet":
                    IBirthday pet = new Pet(data[2]);
                    birthdates.Add(pet);
                    break;
            }
        }

        string year = Console.ReadLine();


        foreach (var item in birthdates)
        {
            if (item.Birthdate.Substring(item.Birthdate.Length - year.Length) == year)
            {
                Console.WriteLine(item.Birthdate);
            }
        }

    }
}

