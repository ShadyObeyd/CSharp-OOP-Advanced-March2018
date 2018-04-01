using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class Tracker
{
    public static BindingFlags BiningFlags { get; private set; }

    public static void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);

        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        foreach (MethodInfo method in methods)
        {
            IEnumerable<SoftUniAttribute> attributes = method.GetCustomAttributes<SoftUniAttribute>();

            foreach (SoftUniAttribute attribute in attributes)
            {
                Console.WriteLine($"{method.Name} is written by {attribute.Name}");
            }
        }
    }
}