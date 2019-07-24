using System;
using System.Collections.Generic;
using System.Text;


class Dough
{
    const double BASE_CALORIES_PER_GRAM = 2;

    private Dictionary<string, double> typeModifiers = new Dictionary<string, double>
    {
        ["white"] = 1.5 ,
        ["wholegrain"] = 1.0
    };

    private Dictionary<string, double> bakingTechniqueModifiers = new Dictionary<string, double>
    {
        ["crispy"] = 0.9,
        ["chewy"] = 1.1,
        ["homemade"] = 1.0
    };

    private string type;
    private int weight;
    private string bakingTechnique;
    public double flourModifier => typeModifiers[this.Type.ToLower()];
    public double bakingTechniqueModifier => bakingTechniqueModifiers[this.BakingTechnique.ToLower()];

    public string Type
    {
        get { return type; }
        set { type = ValidateDough(value, typeModifiers); }
    }

    public int Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            else
            {
                weight = value;
            }
        }
    }

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        set { bakingTechnique = ValidateDough(value, bakingTechniqueModifiers); }
    }

    public Dough(string type, int weight, string bakingTechnique)
    {
        this.Type = type;
        this.Weight = weight;
        this.BakingTechnique = bakingTechnique;
    }

    private string ValidateDough(string type, Dictionary<string, double> typeModifiers)
    {
        if (!typeModifiers.ContainsKey(type.ToLower()))
        {
            throw new ArgumentException("Invalid type of dough.");
        }
        else
        {
            return type;
        } 
    }
}

