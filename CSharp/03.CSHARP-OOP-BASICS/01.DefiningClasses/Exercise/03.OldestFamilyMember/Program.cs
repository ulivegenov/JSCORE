using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        int countOfPeople = int.Parse(Console.ReadLine());
        Dictionary<string, int> familyMembers = new Dictionary<string, int>();
        Family currentMember = new Family();

        for (int i = 0; i < countOfPeople; i++)
        {
            string[] inptut = Console.ReadLine().Split();
            Person currentPerson = new Person();
            currentPerson.Name = inptut[0];
            currentPerson.Age = int.Parse(inptut[1]);
            currentMember.AddMember(familyMembers, currentPerson);
        }

        Person oldestMember = new Person();
        oldestMember = currentMember.GetOldestMember(familyMembers);
        Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
    }
}

