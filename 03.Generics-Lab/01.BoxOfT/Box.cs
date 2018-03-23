using System.Collections.Generic;

public class Box<T>
{
    private List<T> items;

    public Box()
    {
        this.items = new List<T>();
    }

    public int Count => this.items.Count;

    public void Add(T item)
    {
        this.items.Add(item);
    }

    public T Remove()
    {
        T item = this.items[items.Count - 1];
        this.items.RemoveAt(items.Count - 1);

        return item;
    }
}