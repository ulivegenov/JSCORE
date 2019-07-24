using System;
using System.Collections.Generic;
using System.Text;

public class Kitten:Cat
{
    public override string Type { get => "Kitten"; }
    public override string Gender { get => "Female"; }

    public Kitten(string name, int age, string gender) : base(name, age, gender)
    {
        
    }
}

