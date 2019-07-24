using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    string name;
    int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Person()
    {
        this.name = name;
        this.age = age;
    }

    public Person(string name, int age):this()
    {
        this.name = name;
        this.age = age;
    }
}

