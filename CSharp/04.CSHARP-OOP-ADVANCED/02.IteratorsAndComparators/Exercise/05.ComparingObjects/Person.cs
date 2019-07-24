using System;
using System.Collections.Generic;
using System.Text;


public class Person : IComparable<Person>
{
    private string name;

    private int age;

    private string town;

    public Person(string name, int age, string town)
    {
        this.name = name;
        this.age = age;
        this.town = town;
    }

    public int CompareTo(Person otherPerson)
    {
        if (this.name.CompareTo(otherPerson.name) == 0)
        {
            if (this.age.CompareTo(otherPerson.age) == 0)
            {
                return this.town.CompareTo(otherPerson.town);
            }

            return this.age.CompareTo(otherPerson.age);
        }

        return this.name.CompareTo(otherPerson.name);
    }
}

