using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Human
{
    private const int FIRST_NAME_MIN_LENGHT = 4;
    private const int LAST_NAME_MIN_LENGHT = 3;
    private string firstName;
    private string lastName;

    public string FirstName
    {
        get { return firstName; }
        set
        {
            firstName = ValidateName(value,"firstName");
        }
    }

    public string LastName
    {
        get { return lastName; }
        set
        {
            lastName = ValidateName(value, "lastName");
        }
    }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    private string ValidateName(string name, string kindOfName)
    {
        if (!char.IsUpper(name.First()))
        {
            throw new ArgumentException($"Expected upper case letter! Argument: {kindOfName}");
        }
        switch (kindOfName)
        {
            case "firstName":
                if (name.Length < FIRST_NAME_MIN_LENGHT)
                {
                    throw new ArgumentException($"Expected length at least {FIRST_NAME_MIN_LENGHT} symbols! Argument: {kindOfName}");
                }
                break;
            case "lastName":
                if (name.Length < LAST_NAME_MIN_LENGHT)
                {
                    throw new ArgumentException($"Expected length at least {LAST_NAME_MIN_LENGHT} symbols! Argument: {kindOfName}");
                }
                break;
        }
    
        return name;
    }

    public override string ToString()
    {
        StringBuilder outputBuildHuman = new StringBuilder();
        outputBuildHuman.AppendLine($"First Name: {this.FirstName}");
        outputBuildHuman.AppendLine($"Last Name: {this.LastName}");
        string result = outputBuildHuman.ToString().TrimEnd();

        return result;
    }
}

