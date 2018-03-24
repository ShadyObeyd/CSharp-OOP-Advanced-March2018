using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<double> list = new List<double>();

        for (int i = 0; i < n; i++)
        {
            double input = double.Parse(Console.ReadLine());

            list.Add(input);
        }

        double compareNum = double.Parse(Console.ReadLine());

        int result = Compare(list, compareNum);

        Console.WriteLine(result);
    }

    public static int Compare<T>(List<T> list, double compareNum)
        where T : IComparable
    {
        int cntr = 0;

        foreach (T item in list)
        {
            if (item.CompareTo(compareNum) > 0)
            {
                cntr++;
            }
        }

        return cntr;
    }
}