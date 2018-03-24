using System;

class StartUp
{
    static void Main()
    {
        string[] personInfo = Console.ReadLine().Split(' ');

        string fullName = $"{personInfo[0]} {personInfo[1]}";
        string address = personInfo[2];
        string town = personInfo[3];

        var personalInfo = new Threeuple<string, string, string>(fullName, address, town);

        Console.WriteLine(personalInfo);

        string[] personAndBeerCount = Console.ReadLine().Split(' ');

        string beerDrinker = personAndBeerCount[0];
        int beerCount = int.Parse(personAndBeerCount[1]);
        bool isDrunk = personAndBeerCount[2] == "drunk";

        var beerInfo = new Threeuple<string, int, bool>(beerDrinker, beerCount, isDrunk);

        Console.WriteLine(beerInfo);

        string[] bankInput = Console.ReadLine().Split(' ');

        string bankDepositer = bankInput[0];
        double balance = double.Parse(bankInput[1]);
        string bankName = bankInput[2];

        var bankInfo = new Threeuple<string, double, string>(bankDepositer, balance, bankName);

        Console.WriteLine(bankInfo);
    }
}