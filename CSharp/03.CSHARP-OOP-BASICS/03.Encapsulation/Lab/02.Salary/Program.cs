using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int countOfPersons = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();

        for (int i = 0; i < countOfPersons; i++)
        {
            string[] data = Console.ReadLine().Split();
            try
            {
                Person person = new Person(data[0], data[1], int.Parse(data[2]), decimal.Parse(data[3]));
                persons.Add(person);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }

        decimal bonus = decimal.Parse(Console.ReadLine());
        persons.ForEach(p => p.IncreaseSalary(bonus));
        persons.ForEach(p => Console.WriteLine(p));
    }
}

