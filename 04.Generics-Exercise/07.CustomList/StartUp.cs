using System;

class StartUp
{
    static void Main()
    {
        string input = Console.ReadLine();

        CustomList<string> list = new CustomList<string>();

        while (input != "END")
        {
            string[] commandTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (commandTokens[0])
            {
                case "Add":
                    list.Add(commandTokens[1]);
                    break;
                case "Remove":
                    list.Remove(int.Parse(commandTokens[1]));
                    break;
                case "Contains":
                    Console.WriteLine(list.Contains(commandTokens[1]));
                    break;
                case "Swap":
                    list.Swap(int.Parse(commandTokens[1]), int.Parse(commandTokens[2]));
                    break;
                case "Greater":
                    Console.WriteLine(list.CountGreaterThan(commandTokens[1]));
                    break;
                case "Max":
                    Console.WriteLine(list.Max());
                    break;
                case "Min":
                    Console.WriteLine(list.Min());
                    break;
                case "Print":
                    Console.WriteLine(list);
                    break;
            }

            input = Console.ReadLine();
        }
    }
}