using System;
using System.Collections.Generic;
using System.Text;


public class Dog:Animal
{
    public override string Type { get => "Dog"; }

    public Dog(string name, int age, string gender):base(name, age, gender)
    {
        
    }
}

