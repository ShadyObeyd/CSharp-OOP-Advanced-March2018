using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T> : IEnumerable<T>
{
    private List<T> list;
    private int index;

    public ListyIterator(params T[] data)
    {
        this.list = data.ToList();
        this.index = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.list.Count; i++)
        {
            yield return list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
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

    public string PrintAll()
    {
        return string.Join(" ", this);
    }
}