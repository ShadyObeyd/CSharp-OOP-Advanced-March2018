using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<string> list = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            list.Add(input);
        }

        string compareStr = Console.ReadLine();

        int result = Compare(list, compareStr);

        Console.WriteLine(result);
    }

    public static int Compare<T>(List<T> list, string compareStr)
        where T : IComparable
    {
        int cntr = 0;

        foreach (T item in list)
        {
            if (item.CompareTo(compareStr) > 0)
            {
                cntr++;
            }
        }

        return cntr;
    }
}