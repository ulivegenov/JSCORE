using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();

        for (int i = 0; i < lines; i++)
        {
            string[] data = Console.ReadLine().Split();
            Person person = new Person(data[0], data[1], int.Parse(data[2]));
            persons.Add(person);
        }

        persons.OrderBy(p => p.FirstName)
                   .ThenBy(p => p.Age)
                   .ToList()
                   .ForEach(p => Console.WriteLine(p.ToString()));
    }
}

