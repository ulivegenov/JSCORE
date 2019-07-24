using System;
using System.Collections.Generic;
using System.Text;

public class Employee
{
    string name;
    decimal selary;
    string position;
    string department;
    string email;
    int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public decimal Selary
    {
        get { return selary; }
        set { selary = value; }
    }
    public string Position
    {
        get { return position; }
        set { position = value; }
    }
    public string Department
    {
        get { return department; }
        set { department = value; }
    }
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    public Employee()
    {

    }
    public Employee(string name, decimal selary, string position, string department):this()
    {
        this.name = name;
        this.selary = selary;
        this.position = position;
        this.department = department;
    }
    public Employee(string name, decimal selary, string position, string department, string email, int age)
                    :this(name,selary,position,department)
    {
        this.email = email;
        this.age = age;
    }
}

