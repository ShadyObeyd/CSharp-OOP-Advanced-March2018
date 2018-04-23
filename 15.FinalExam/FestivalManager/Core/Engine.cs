
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers.Contracts;
    using FestivalManager.Core.IO;
    using IO.Contracts;

	public class Engine : IEngine
	{
        private const string EndCommand = "END";
        private const string ErrorMessage = "ERROR: ";

	    private IReader reader;
	    private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IFestivalController festivalController, ISetController setController)
        {
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

		public void Run()
		{
            string input = this.reader.ReadLine();

            string result = string.Empty;

			while (input != EndCommand)
			{
				try
				{
                    result = this.ProcessCommand(input);
				}
				catch (InvalidOperationException ex)
				{
                    result = ErrorMessage + ex.Message;
				}

                this.writer.WriteLine(result);

                input = this.reader.ReadLine();
			}

			var outputResult = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(outputResult);
		}

        public string ProcessCommand(string input)
        {
            string[] commandTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = commandTokens[0];

            string[] commandArgs = commandTokens.Skip(1).ToArray();

            string result = string.Empty;

            switch (command)
            {
                case "RegisterSet":
                    result = this.festivalCоntroller.RegisterSet(commandArgs);
                    break;
                case "SignUpPerformer":
                    result = this.festivalCоntroller.SignUpPerformer(commandArgs);
                    break;
                case "RegisterSong":
                    result = this.festivalCоntroller.RegisterSong(commandArgs);
                    break;
                case "AddSongToSet":
                    result = this.festivalCоntroller.AddSongToSet(commandArgs);
                    break;
                case "AddPerformerToSet":
                    result = this.festivalCоntroller.AddPerformerToSet(commandArgs);
                    break;
                case "RepairInstruments":
                    result = this.festivalCоntroller.RepairInstruments(commandArgs);
                    break;
                case "LetsRock":
                    result = this.setCоntroller.PerformSets();
                    break;
            }

            return result;
        }
    }
}