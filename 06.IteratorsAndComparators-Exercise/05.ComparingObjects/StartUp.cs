using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        List<Person> people = new List<Person>();

        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] personTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = personTokens[0];
            int age = int.Parse(personTokens[1]);
            string town = personTokens[2];

            people.Add(new Person(name, age, town));

            input = Console.ReadLine();
        }

        int personNum = int.Parse(Console.ReadLine()) - 1;

        Person wantedPerson = people[personNum];

        int equalPeopleCntr = 1;
        int diffPeopleCntr = 0;

        for (int i = 0; i < people.Count; i++)
        {
            if (i == personNum)
            {
                continue;
            }

            if (wantedPerson.CompareTo(people[i]) == 0)
            {
                equalPeopleCntr++;
            }
            else
            {
                diffPeopleCntr++;
            }
        }

        if (equalPeopleCntr == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equalPeopleCntr} {diffPeopleCntr} {people.Count}");
        }
    }
}