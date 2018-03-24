using System;

class StartUp
{
    static void Main()
    {
        string[] personInfo = Console.ReadLine().Split(' ');

        string fullName = $"{personInfo[0]} {personInfo[1]}";
        string address = personInfo[2];

        Tuple<string, string> personalInfo = new Tuple<string, string>(fullName, address);

        string[] personAndBeerCount = Console.ReadLine().Split(' ');

        string peronName = personAndBeerCount[0];
        int beerCount = int.Parse(personAndBeerCount[1]);

        Tuple<string, int> beerInfo = new Tuple<string, int>(peronName, beerCount);

        string[] numbers = Console.ReadLine().Split(' ');

        int intNum = int.Parse(numbers[0]);
        double doubleNum = double.Parse(numbers[1]);

        Tuple<int, double> numbersInfo = new Tuple<int, double>(intNum, doubleNum);

        Console.WriteLine(personalInfo);
        Console.WriteLine(beerInfo);
        Console.WriteLine(numbersInfo);
    }
}

