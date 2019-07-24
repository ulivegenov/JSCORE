using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        int countOfPeople = int.Parse(Console.ReadLine());
        SortedDictionary<string, int> overThirthyList = new SortedDictionary<string, int>();
        OverThirty overThirthy = new OverThirty();

        for (int i = 0; i < countOfPeople; i++)
        {
            string[] input = Console.ReadLine().Split();
            Person currentPerson = new Person();
            currentPerson.Name = input[0];
            currentPerson.Age = int.Parse(input[1]);
            overThirthy.AddMember(overThirthyList, currentPerson);
        }

        foreach (var person in overThirthyList)
        {
            Console.WriteLine($"{person.Key} - {person.Value}");
        }
    }
}

