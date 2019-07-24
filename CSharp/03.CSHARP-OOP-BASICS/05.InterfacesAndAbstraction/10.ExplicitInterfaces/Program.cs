using System;

public class Program
{
    static void Main(string[] args)
    {
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Citizen citizen = new Citizen(data[0], data[1], int.Parse(data[2]));

            Console.WriteLine(((IPerson)citizen).GetName());
            Console.WriteLine(((IResident)citizen).GetName());
        }
    }
}

