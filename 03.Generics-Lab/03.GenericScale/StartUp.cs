using System;

class StartUp
{
    static void Main()
    {
        Scale<int> scale = new Scale<int>(6, 5);

        Console.WriteLine(scale.GetHeavier());
    }
}

