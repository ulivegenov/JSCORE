using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main(string[] args)
    {
        SortedSet<Person> personsByName = new SortedSet<Person>(new NameComparator());
        SortedSet<Person> personsByAge = new SortedSet<Person>(new AgeComparator());

        int countOfPersons = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfPersons; i++)
        {
            string[] inputArgs = Console.ReadLine().Split();
            string name = inputArgs[0];
            int age = int.Parse(inputArgs[1]);
            Person currentPerson = new Person(name, age);

            personsByName.Add(currentPerson);
            personsByAge.Add(currentPerson);
        }

        foreach (var person in personsByName)
        {
            Console.WriteLine(person);
        }

        foreach (var person in personsByAge)
        {
            Console.WriteLine(person);
        }
    }
}

