using System;
using System.Collections.Generic;
using System.Text;


class Pokemon
{
    private string name;
    private string type;

    public Pokemon(string name, string type)
    {
        this.name = name;
        this.type = type;
    }

    public override string ToString()
    {
        return $"{this.name} {this.type}";
    }
}

