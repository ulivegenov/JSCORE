using System;

public class Person : IComparable<Person>
{
    public string Name { get; set; }

    public int Age { get; set; }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public int CompareTo(Person otherPerson)
    {
        if (this.Name.CompareTo(otherPerson.Name) == 0)
        {
            return this.Age.CompareTo(otherPerson.Age);
        }

        return this.Name.CompareTo(otherPerson.Name);
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }
}

