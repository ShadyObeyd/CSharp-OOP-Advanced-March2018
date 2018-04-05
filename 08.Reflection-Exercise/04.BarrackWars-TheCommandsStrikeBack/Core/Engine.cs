namespace _03BarracksFactory.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private string InterpredCommand(string[] data, string commandName)
        {
            if (commandName == "fight")
            {
                Environment.Exit(0);
            }

            Type commandType = Type.GetType($"_03.BarraksWars.Core.Commands.{commandName}", false, true);

            if (commandType == null)
            {
                throw new ArgumentException("Invalid Command!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"Unexpected command: {commandName}!");
            }

            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, new object[] { data, this.repository, this.unitFactory});

            MethodInfo method = commandType.GetMethod("Execute", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            string result = (string)method.Invoke(command, new object[] { });

            return result;
        }
    }
}
