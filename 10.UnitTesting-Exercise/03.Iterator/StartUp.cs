using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        string input = Console.ReadLine();

        ListIterator iterator = null;

        while (input != "END")
        {
            try
            {
                string[] inputTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (inputTokens[0])
                {
                    case "Create":
                        string[] methodArgs = inputTokens.Skip(1).ToArray();
                        iterator = new ListIterator(methodArgs);
                        break;
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "Print":
                        Console.WriteLine(iterator.Print());
                        break;
                }
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
            catch(InvalidOperationException invEx)
            {
                Console.WriteLine(invEx.Message);
            }
            input = Console.ReadLine();
        }
    }
}