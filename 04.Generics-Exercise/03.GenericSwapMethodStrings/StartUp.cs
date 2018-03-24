using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Box<string>> list = new List<Box<string>>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            Box<string> stringBox = new Box<string>(input);

            list.Add(stringBox);
        }

        int[] indexes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int firstIndex = indexes[0];
        int secondIndex = indexes[1];

        Swap(list, firstIndex, secondIndex);
    }

    public static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
    {
        T value = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = value;

        foreach (T item in list)
        {
            Console.WriteLine(item);
        }
    }
}