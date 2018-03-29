using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        SortedSet<Person> nameSet = new SortedSet<Person>(new NameComparator());
        SortedSet<Person> ageSet = new SortedSet<Person>(new AgeComparator());

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] personTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = personTokens[0];
            int age = int.Parse(personTokens[1]);

            nameSet.Add(new Person(name, age));
            ageSet.Add(new Person(name, age));
        }

        foreach (Person person in nameSet)
        {
            Console.WriteLine(person);
        }

        foreach (Person person in ageSet)
        {
            Console.WriteLine(person);
        }
    }
}