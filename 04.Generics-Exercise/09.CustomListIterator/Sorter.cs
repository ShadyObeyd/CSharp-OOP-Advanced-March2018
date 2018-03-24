using System;
using System.Collections.Generic;
using System.Linq;

public static class Sorter
{
    public static void Sort<T>(CustomList<T> list)
        where T : IComparable
    {
        list.Sort();
    }
}