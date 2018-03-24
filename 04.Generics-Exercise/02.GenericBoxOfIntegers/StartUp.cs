using System;

class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int input = int.Parse(Console.ReadLine());

            Box<int> stringBox = new Box<int>(input);
            Console.WriteLine(stringBox);
        }
    }
}