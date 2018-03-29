using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Stack<T> : IEnumerable<T>
{
    private List<T> list;

    public Stack()
    {
        this.list = new List<T>();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.list.Count - 1; i >= 0; i--)
        {
            yield return list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Push(params T[] data)
    {
        this.list.AddRange(data);
    }

    public void Pop()
    {
        if (this.list.Any())
        {
            list.RemoveAt(list.Count - 1);
        }
        else
        {
            Console.WriteLine("No elements");
        }
    }

    public void Print()
    {
        foreach (T item in this)
        {
            Console.WriteLine(item);
        }
    }
}