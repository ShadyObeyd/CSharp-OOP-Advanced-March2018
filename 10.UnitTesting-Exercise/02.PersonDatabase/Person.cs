public class Person
{
    public Person(string name, long id)
    {
        this.Name = name;
        this.Id = id;
    }

    public string Name { get; private set; }

    public long Id { get; private set; }

    public override string ToString()
    {
        return $"{this.Name} -> {this.Id}";
    }
}