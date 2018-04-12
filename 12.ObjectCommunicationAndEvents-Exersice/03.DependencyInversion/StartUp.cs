using System;

class StartUp
{
    static void Main()
    {
        PrimitiveCalculator calculator = new PrimitiveCalculator();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] commandTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (commandTokens[0] == "mode")
            {
                ICalculatable strategy = null;
                switch (commandTokens[1])
                {
                    case "+":
                        strategy = new AdditionStrategy();
                        break;
                    case "-":
                        strategy = new SubtractionStrategy();
                        break;
                    case "*":
                        strategy = new MultiplyStrategy();
                        break;
                    case "/":
                        strategy = new DivisionStrategy();
                        break;
                }

                calculator.ChangeStrategy(strategy);
            }
            else
            {
                int leftOperand = int.Parse(commandTokens[0]);
                int rightOperand = int.Parse(commandTokens[1]);

                int result = calculator.PerformCalculation(leftOperand, rightOperand);

                Console.WriteLine(result);
            }

            input = Console.ReadLine();
        }
    }
}