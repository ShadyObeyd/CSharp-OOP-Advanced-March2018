using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        string input = Console.ReadLine();

        ListyIterator<string> listIterator = null;

        while (input != "END")
        {
            string[] commandTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] parameters = commandTokens.Skip(1).ToArray();

            string command = commandTokens[0];

            try
            {
                switch (command)
                {
                    case "Create":
                        string[] parameters = commandTokens.Skip(1).ToArray();
                        listIterator = new ListyIterator<string>(parameters);
                        break;
                    case "Move":
                        Console.WriteLine(listIterator.Move());
                        break;
                    case "Print":
                        Console.WriteLine(listIterator.Print());
                        break;
                    case "HasNext":
                        Console.WriteLine(listIterator.HasNext());
                        break;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            input = Console.ReadLine();
        }
    }
}