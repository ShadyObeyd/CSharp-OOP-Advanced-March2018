using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fields)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

        object hacker = Activator.CreateInstance(classType, new object[] { });

        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"Class under investigation: {className}");

        foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
        {
            builder.AppendLine($"{field.Name} = {field.GetValue(hacker)}");
        }

        return builder.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

        StringBuilder builder = new StringBuilder();

        foreach (FieldInfo field in fields)
        {
            builder.AppendLine($"{field.Name} must be private!");
        }

        PropertyInfo[] privateProperties = classType.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

        foreach (PropertyInfo property in privateProperties)
        {
            if (property.GetMethod?.IsPrivate == true)
            {
                builder.AppendLine($"{property.GetMethod.Name} have to be public!"); // has*
            }
        }

        PropertyInfo[] publicProperties = classType.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        foreach (PropertyInfo property in publicProperties)
        {
            if (property.SetMethod?.IsPublic == true)
            {
                builder.AppendLine($"{property.SetMethod.Name} have to be private!"); // has*
            }
        }

        return builder.ToString().TrimEnd();
    }
}