using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Clinic> clinics = new List<Clinic>();
        List<Pet> pets = new List<Pet>();

        int countOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfCommands; i++)
        {
            string[] inputArgs = Console.ReadLine().Split();
            string command = inputArgs[0];

            switch (command)
            {
                case "Create":
                    if (inputArgs[1] == "Clinic")
                    {
                        string name = inputArgs[2];
                        int countOfRooms = int.Parse(inputArgs[3]);
                        try
                        {
                            Clinic currentClinic = new Clinic(name, countOfRooms);
                            clinics.Add(currentClinic);
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        string name = inputArgs[2];
                        int age = int.Parse(inputArgs[3]);
                        string kind = inputArgs[4];

                        Pet currentPet = new Pet(name, age, kind);
                        pets.Add(currentPet);
                    }
                    break;
                case "Add":
                    foreach (var clinic in clinics)
                    {
                        if (clinic.Name == inputArgs[2])
                        {
                            foreach (var pet in pets)
                            {
                                if (pet.Name == inputArgs[1])
                                {
                                    Console.WriteLine(clinic.Add(pet, clinic));
                                }
                            }
                        }
                    }
                    break;
                case "Release":
                    foreach (var clinic in clinics)
                    {
                        if (clinic.Name == inputArgs[1])
                        {
                            Console.WriteLine(clinic.Release());
                        }
                    }
                    break;
                case "HasEmptyRooms":
                    foreach (var clinic in clinics.Where(n => n.Name == inputArgs[1]))
                    {
                        Console.WriteLine(clinic.HasEmptyRooms(clinic));
                    }
                    break;
                case "Print":
                    foreach (var clinic in clinics)
                    {
                        if (clinic.Name == inputArgs[1])
                        {
                            if (inputArgs.Length == 2)
                            {
                                clinic.Print(clinic);
                            }
                            else
                            {
                                clinic.Print(clinic, int.Parse(inputArgs[2]));
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

