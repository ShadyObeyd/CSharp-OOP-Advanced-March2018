namespace _03BarracksFactory.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using _03.BarraksWars.Core.Commands;
    using Contracts;

    class Engine : IRunnable
    {
        private IServiceProvider provider;

        public Engine(IServiceProvider provider)
        {
            this.provider = provider;
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

            FieldInfo[] fieldsToInject = commandType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(c => c.AttributeType == typeof(InjectAttribute))).ToArray();

            object[] injectArgs = fieldsToInject.Select(f => this.provider.GetService(f.FieldType)).ToArray();

            object[] instanceArgs = new object[] { data }.Concat(injectArgs).ToArray();

            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, instanceArgs);

            MethodInfo method = commandType.GetMethod("Execute", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            string result = (string)method.Invoke(command, new object[] { });

            return result;
        }
    }
}
