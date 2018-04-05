using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        TrafficLight[] trafficLights = GetTraficLights(input);

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            foreach (var item in trafficLights)
            {
                item.SetColor();
            }

            Console.WriteLine(string.Join(" ", trafficLights.ToList()));
        }
        
    }

    private static TrafficLight[] GetTraficLights(string[] input)
    {
        TrafficLight[] traficLights = new TrafficLight[input.Length];

        for (int i = 0; i < traficLights.Length; i++)
        {
            Color color = Enum.Parse<Color>(input[i]);
            traficLights[i] = new TrafficLight(color);
        }

        return traficLights;
    }
}