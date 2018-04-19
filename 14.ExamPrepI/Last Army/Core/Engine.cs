using System;
using System.Text;

public class Engine
{
    private const string END_MESSAGE = "Enough! Pull back!";
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        var input = this.reader.ReadLine();
        var gameController = new GameController(this.writer);

        while (!input.Equals(END_MESSAGE))
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                this.writer.AppendLine(arg.Message);
            }
            input = this.reader.ReadLine();
        }

        gameController.RequestResult();
        this.writer.WriteAll();
    }
}