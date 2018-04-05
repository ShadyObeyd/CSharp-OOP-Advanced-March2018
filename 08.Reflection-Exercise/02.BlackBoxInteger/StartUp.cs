using System;
using System.Reflection;

class StartUp
{
    static void Main()
    {
        Type classType = typeof(BlackBoxInteger);

        object classInstanse = Activator.CreateInstance(classType, true);

        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] commandTokens = input.Split('_', StringSplitOptions.RemoveEmptyEntries);

            string command = commandTokens[0];
            int value = int.Parse(commandTokens[1]);

            MethodInfo method = classType.GetMethod(command, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            method.Invoke(classInstanse, new object[] { value });

            FieldInfo field = classType.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            Console.WriteLine(field.GetValue(classInstanse));

            input = Console.ReadLine();
        }
    }
}