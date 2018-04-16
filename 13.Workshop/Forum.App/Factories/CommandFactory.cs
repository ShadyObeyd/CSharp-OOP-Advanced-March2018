using System;
using System.Linq;
using System.Reflection;

public class CommandFactory : ICommandFactory
{
    IServiceProvider serviceProvider;

    public CommandFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public ICommand CreateCommand(string commandName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");

        if (commandType == null)
        {
            throw new InvalidOperationException("Command not found!");
        }

        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new InvalidOperationException($"{commandType.Name} is not a command");
        }

        ParameterInfo[] ctrorParams = commandType.GetConstructors().First().GetParameters();

        object[] args = new object[ctrorParams.Length];

        for (int i = 0; i < args.Length; i++)
        {
            args[i] = this.serviceProvider.GetService(ctrorParams[i].ParameterType);
        }

        ICommand command = (ICommand)Activator.CreateInstance(commandType, args);

        return command;
    }
}