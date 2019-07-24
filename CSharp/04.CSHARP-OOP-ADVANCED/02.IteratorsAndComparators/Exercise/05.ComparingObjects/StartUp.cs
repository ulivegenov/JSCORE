using System;
using System.Collections.Generic;

class StartUp
{
    static void Main(string[] args)
    {
        List<Person> persons = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputArgs = input.Split();
            string name = inputArgs[0];
            int age = int.Parse(inputArgs[1]);
            string town = inputArgs[2];

            Person curentPerson = new Person(name, age, town);

            persons.Add(curentPerson);
        }

        int indexOfPersonToCompare = int.Parse(Console.ReadLine());

        int countOfEqualPersons = 1;
        for (int i = 0; i < persons.Count; i++)
        {
            if (persons[indexOfPersonToCompare - 1].CompareTo(persons[i]) == 0)
            {
                countOfEqualPersons++;
            }
        }
        countOfEqualPersons--;

        if (countOfEqualPersons == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{countOfEqualPersons} {persons.Count - countOfEqualPersons} {persons.Count}");
        }
    }
}

