using System;
using System.Collections.Generic;
using System.Text;


public class Frog:Animal
{
    public override string Type { get => "Frog"; }

    public Frog(string name, int age, string gender) : base(name, age, gender)
    {

    }
}

