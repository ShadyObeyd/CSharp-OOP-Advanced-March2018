using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();

        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] commandTokens = input.Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries);

            switch (commandTokens[0])
            {
                case "Push":
                    int[] parameters = commandTokens.Skip(1).Select(int.Parse).ToArray();
                    stack.Push(parameters);
                    break;
                case "Pop":
                    stack.Pop();
                    break;
            }
            input = Console.ReadLine();
        }

        stack.Print();
        stack.Print();
    }
}