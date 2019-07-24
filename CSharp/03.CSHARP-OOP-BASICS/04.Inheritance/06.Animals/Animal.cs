using System;
using System.Collections.Generic;
using System.Text;


public class Animal
{
    private string name;
    private int age;
    private string gender;
    private string type;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            else
            {
                name = value;
            }
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            else
            {
                age = value;
            }
        }
    }

    public virtual string Gender
    {
        get { return gender; }
        set
        {
            if ((string.IsNullOrWhiteSpace(value)))
            {
                throw new ArgumentException("Invalid input!");
            }
            else
            {
                gender = value;
            }
        }
    }

    public virtual string Type
    {
        get { return type; }
        set
        {
            type = value;
        }
    }

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string ProduceSound(string animalType)
    {
        string sound = null;
        switch (animalType)
        {
            case "Dog":
                sound = "Woof!";
                break;
            case "Cat":
                sound = "Meow meow";
                break;
            case "Kitten":
                sound = "Meow";
                break;
            case "Tomcat":
                sound = "MEOW";
                break;
            case "Frog":
                sound = "Ribbit";
                break;
        }
        return sound;
    }

    public override string ToString()
    {
        return $"{this.Type}{Environment.NewLine}{this.Name} {this.Age} {this.Gender}{Environment.NewLine}{this.ProduceSound(this.Type)}";
    }
}

