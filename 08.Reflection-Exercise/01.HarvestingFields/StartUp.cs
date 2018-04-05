using System;
using System.Linq;
using System.Reflection;

class StartUp
{
    static void Main()
    {
        Type classType = typeof(HarvestingFields);

        FieldInfo[] allFields = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        FieldInfo[] privateFields = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(f => f.IsPrivate).ToArray();
        FieldInfo[] protectedFields = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(f => f.IsFamily).ToArray();
        FieldInfo[] publicFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance);

        string input = Console.ReadLine();

        while (input != "HARVEST")
        {
            switch (input)
            {
                case "private":
                    PrintCollection(privateFields);
                    break;
                case "public":
                    PrintCollection(publicFields);
                    break;
                case "protected":
                    PrintCollection(protectedFields);
                    break;
                case "all":
                    PrintCollection(allFields);
                    break;
            }

            input = Console.ReadLine();
        }
    }

    private static void PrintCollection(FieldInfo[] collection)
    {
        foreach (FieldInfo field in collection)
        {
            string result = string.Empty;

            if (field.IsPrivate)
            {
                result = "private";
            }
            else if (field.IsPublic)
            {
                result = "public";
            }
            else
            {
                result = "protected";
            }

            Console.WriteLine($"{result} {field.FieldType.Name} {field.Name}");
        }
    }
}