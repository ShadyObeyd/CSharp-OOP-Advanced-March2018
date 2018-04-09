using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        try
        {
            Bubble bubble = new Bubble(input);
            Console.WriteLine(string.Join(" ", bubble.SortArr()));
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}