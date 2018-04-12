public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

public class Dispatcher
{
    public event NameChangeEventHandler NameChange;
    private string name;

    public Dispatcher(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.OnNameChange(new NameChangeEventArgs(value));
            name = value;
        }
    }

    public void OnNameChange(NameChangeEventArgs args)
    {
        if (this.NameChange != null)
        {
            this.NameChange.Invoke(this, args);
        }
    }

}