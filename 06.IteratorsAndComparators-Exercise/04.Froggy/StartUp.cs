using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        Lake<int> lake = new Lake<int>(input);

        Console.WriteLine(string.Join(", ", lake));
    }
}