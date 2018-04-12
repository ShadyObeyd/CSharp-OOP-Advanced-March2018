public abstract class Unit
{
    protected Unit(string name)
    {
        this.Name = name;
    }

    public string Name { get; protected set; }
}