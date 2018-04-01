using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string classToInvestigate, params string[] fields)
    {
        Type classType = Type.GetType(classToInvestigate);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

        object hacker = Activator.CreateInstance(classType, new object[] { });

        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"Class under investigation: {classToInvestigate}");

        foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
        {
            builder.AppendLine($"{field.Name} = {field.GetValue(hacker)}");
        }

        return builder.ToString().TrimEnd();
    }
}