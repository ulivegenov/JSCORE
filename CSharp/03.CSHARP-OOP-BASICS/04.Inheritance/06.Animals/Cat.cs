using System;
using System.Collections.Generic;
using System.Text;


public class Cat:Animal
{
    public override string Type { get => "Cat"; }

    public Cat(string name, int age, string gender) : base(name, age, gender)
    {

    }
}

