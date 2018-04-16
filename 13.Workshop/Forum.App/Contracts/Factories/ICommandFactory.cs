public interface ICommandFactory
{
    ICommand CreateCommand(string commandName);
}