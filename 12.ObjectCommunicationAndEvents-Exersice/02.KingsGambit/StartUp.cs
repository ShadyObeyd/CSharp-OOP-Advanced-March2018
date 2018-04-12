using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        King king = SetupKing();

        string input = Console.ReadLine();

        while (input != "End")
        { 
            string[] commandTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (commandTokens[0])
            {
                case "Attack":
                    king.GetAttacked();
                    break;
                case "Kill":
                    Subject subject = king.Subjects.First(s => s.Name == commandTokens[1]);
                    subject.Die();
                    king.KillSubject(subject);
                    break;
            }

            input = Console.ReadLine();
        }
    }

    private static King SetupKing()
    {
        string kingName = Console.ReadLine();
        King king = new King(kingName, new List<Subject>());

        string[] royalGurards = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string guardName in royalGurards)
        {
            RoyalGuard guard = new RoyalGuard(guardName);

            king.AddSubject(guard);
        }

        string[] footmen = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string footmanName in footmen)
        {
            Footman footman = new Footman(footmanName);

            king.AddSubject(footman);
        }

        return king;
    }
}

