using System;

class StartUp
{
    static void Main()
    {
        string[] strings = ArrayCreator.Create(5, "Pesho");
        int[] integers = ArrayCreator.Create(10, 33);

        foreach (string str in strings)
        {
            Console.WriteLine(str);
        }

        foreach (int integer in integers)
        {
            Console.WriteLine(integer);
        }
    }
}