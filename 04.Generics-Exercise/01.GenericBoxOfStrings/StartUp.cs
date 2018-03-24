using System;

class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            Box<string> stringBox = new Box<string>(input);
            Console.WriteLine(stringBox);
        }
    }
}