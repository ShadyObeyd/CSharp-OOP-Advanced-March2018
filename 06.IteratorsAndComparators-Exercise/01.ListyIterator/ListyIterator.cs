using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T>
{
    private List<T> list;
    private int index;

    public ListyIterator(params T[] data)
    {
        this.list = data.ToList();
        this.index = 0;
    }

    public bool Move()
    {
        if (this.index < this.list.Count - 1)
        {
            this.index++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        if (this.index < this.list.Count - 1)
        {
            return true;
        }
        return false;
    }

    public T Print()
    {
        if (!this.list.Any())
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        return this.list[index];
    }
}