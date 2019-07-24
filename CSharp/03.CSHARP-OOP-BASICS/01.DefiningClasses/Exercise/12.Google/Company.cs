using System;
using System.Collections.Generic;
using System.Text;


class Company
{
    private string name;
    private decimal salary;
    private string department;

    public Company(string name, decimal salary, string department)
    {
        this.name = name;
        this.salary = salary;
        this.department = department;
    }

    public override string ToString()
    {
        return $"{this.name} {this.department} {this.salary:F2}";
    }
}

