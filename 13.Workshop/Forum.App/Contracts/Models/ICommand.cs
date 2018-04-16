public interface ICommand
{
    IMenu Execute(params string[] args);
}