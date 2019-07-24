using System;
using System.Collections.Generic;
using System.Text;


class Person
{
    private string firstName;

    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }

    private string lastName;

    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }

    private int age;

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public Person(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} is {this.Age} yers old.";
    }

}


