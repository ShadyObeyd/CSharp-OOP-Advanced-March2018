using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        HashSet<Person> normalSet = new HashSet<Person>(new Comparer());
        SortedSet<Person> sortedSet = new SortedSet<Person>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] personTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = personTokens[0];
            int age = int.Parse(personTokens[1]);

            Person person = new Person(name, age);

            normalSet.Add(person);
            sortedSet.Add(person);
        }

        Console.WriteLine(sortedSet.Count);
        Console.WriteLine(normalSet.Count);
    }
}