using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class HarvestingFieldsTest
{
    public void Print(string command)
    {
        Type classToInvestigate = Type.GetType("HarvestingFields");
        string result = null;

        switch (command)
        {
            case "private":
                result = PrintPrivate(classToInvestigate);
                break;
            case "protected":
                result = PrintProtected(classToInvestigate);
                break;
            case "public":
                result = PrintPublic(classToInvestigate);
                break;
            case "all":
                result = PrintAll(classToInvestigate);
                break;
            default:
                break;
        }

        Console.WriteLine(result); ;
    }

    private string PrintPrivate(Type classToInvestigate)
    {
        FieldInfo[] fields = classToInvestigate.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
        StringBuilder sb = new StringBuilder();

        foreach (var field in fields)
        {
            if (field.IsPrivate)
            {
                sb.AppendLine($"{"private"} {field.FieldType.Name} {field.Name}");
            }
        }

        return sb.ToString().Trim();
    }

    private string PrintProtected(Type classToInvestigate)
    {
        FieldInfo[] fields = classToInvestigate.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
        StringBuilder sb = new StringBuilder();

        foreach (var field in fields)
        {
            if (field.IsFamily)
            {
                sb.AppendLine($"{"protected"} {field.FieldType.Name} {field.Name}");
            }
        }

        return sb.ToString().Trim();
    }

    private string PrintPublic(Type classToInvestigate)
    {
        FieldInfo[] fields = classToInvestigate.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
        StringBuilder sb = new StringBuilder();

        foreach (var field in fields)
        {
            sb.AppendLine($"{"public"} {field.FieldType.Name} {field.Name}");
        }

        return sb.ToString().Trim();
    }

    private string PrintAll(Type classToInvestigate)
    {
        FieldInfo[] fields = classToInvestigate.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        StringBuilder sb = new StringBuilder();

        foreach (var field in fields)
        {
            if (field.IsFamily)
            {
                sb.AppendLine($"{"protected"} {field.FieldType.Name} {field.Name}");
            }
            else
            {
                sb.AppendLine($"{(field.Attributes).ToString().ToLower()} {field.FieldType.Name} {field.Name}");
            }
            
        }

        return sb.ToString().Trim();
    }
}

