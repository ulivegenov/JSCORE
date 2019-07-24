using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Spy
{
    public string StealFieldInfo(string classToInvestigate, params string[] fildsToInvestigate)
    {
        Type classType = Type.GetType(classToInvestigate);
        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static |
                                                 BindingFlags.Public | BindingFlags.NonPublic);
        object classInstance = Activator.CreateInstance(classType, new object[] { });

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {classToInvestigate}");

        foreach (var field in fields.Where(f => fildsToInvestigate.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fieldsToInvestigate = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (var field in fieldsToInvestigate)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }
        foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }
       

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] classPrivateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        Type baseClassName = classType.BaseType;

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {baseClassName.Name}");

        foreach (var privateMethod in classPrivateMethods)
        {
            sb.AppendLine(privateMethod.Name);
        }

        return sb.ToString().Trim();
    }

    public string ColectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);
        PropertyInfo[] proparties = classType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (var getter in proparties)
        {
            if (getter.GetMethod != null)
            {
                sb.AppendLine($"{getter.GetMethod.Name} will return {getter.GetMethod.ReturnType}");
            }
        }

        foreach (var setter in proparties)
        {
            if (setter.SetMethod != null)
            {
                sb.AppendLine($"{setter.SetMethod.Name} will set field of {setter.PropertyType}");
            }  
        }

        return sb.ToString().Trim();
    }
}

