using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main(string[] args)
    {
        SortedSet<Person> personsSorted = new SortedSet<Person>();
        HashSet<Person> persons = new HashSet<Person>(new PersonsComparator());

        int countOfPersons = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfPersons; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int age = int.Parse(input[1]);

            Person person = new Person(name, age);

            personsSorted.Add(person);
            persons.Add(person);
        }

        Console.WriteLine(personsSorted.Count);
        Console.WriteLine(persons.Count);
    }
}

