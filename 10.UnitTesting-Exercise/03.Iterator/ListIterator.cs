using System;
using System.Collections.Generic;

public class ListIterator
{
    private int index;

    public ListIterator(params string[] parameters)
    {
        if (parameters == null)
        {
            throw new ArgumentException("Collection cannot be null!");
        }

        this.Collection = new List<string>(parameters);
        this.index = 0;
    }

    public List<string> Collection { get; private set; }

    public bool Move()
    {
        if (this.index < this.Collection.Count - 1)
        {
            index++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        if (index < this.Collection.Count - 1)
        {
            return true;
        }

        return false;
    }

    public string Print()
    {
        if (this.Collection.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

       return this.Collection[index];
    }

}