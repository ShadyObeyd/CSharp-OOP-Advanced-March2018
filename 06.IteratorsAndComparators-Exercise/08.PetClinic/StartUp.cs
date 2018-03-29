using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        List<Clinic> clinics = new List<Clinic>();
        List<Pet> pets = new List<Pet>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] commandTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Pet pet = null;
            Clinic clinic = null;

            switch (commandTokens[0])
            {
                case "Create":
                    if (commandTokens[1] == "Pet")
                    {
                        string petName = commandTokens[2];
                        int petAge = int.Parse(commandTokens[3]);
                        string kind = commandTokens[4];

                        pet = new Pet(petName, petAge, kind);
                        pets.Add(pet);
                    }
                    else if (commandTokens[1] == "Clinic")
                    {
                        string clinicName = commandTokens[2];
                        int roomsCount = int.Parse(commandTokens[3]);

                        try
                        {
                            clinic = new Clinic(clinicName, roomsCount);
                            clinics.Add(clinic);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;
                case "Add":
                    pet = pets.FirstOrDefault(p => p.Name == commandTokens[1]);
                    clinic = clinics.FirstOrDefault(c => c.Name == commandTokens[2]);

                    Console.WriteLine(clinic.Add(pet));
                    break;
                case "Release":
                    clinic = clinics.FirstOrDefault(c => c.Name == commandTokens[1]);

                    Console.WriteLine(clinic.Release());
                    break;
                case "HasEmptyRooms":
                    clinic = clinics.FirstOrDefault(c => c.Name == commandTokens[1]);

                    Console.WriteLine(clinic.HasEmptyRooms());
                    break;

                case "Print":
                    if (commandTokens.Length == 2)
                    {
                        clinic = clinics.FirstOrDefault(c => c.Name == commandTokens[1]);

                        clinic.Print();
                    }
                    else if (commandTokens.Length == 3)
                    {
                        clinic = clinics.FirstOrDefault(c => c.Name == commandTokens[1]);
                        int roomNum = int.Parse(commandTokens[2]);

                        clinic.Print(roomNum);
                    }
                    break;
            }
        }
    }
}