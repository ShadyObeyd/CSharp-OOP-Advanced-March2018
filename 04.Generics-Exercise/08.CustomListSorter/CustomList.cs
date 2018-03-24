using System;
using System.Collections.Generic;

public class CustomList<T> : List<T>
    where T : IComparable
{
    public void Remove(int index)
    {
        this.RemoveAt(index);
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        T element = this[firstIndex];
        this[firstIndex] = this[secondIndex];
        this[secondIndex] = element;
    }

    public int CountGreaterThan(T element)
    {
        int cntr = 0;
        foreach (T item in this)
        {
            if (item.CompareTo(element) > 0)
            {
                cntr++;
            }
        }

        return cntr;
    }

    public T Max()
    {
        T maxElement = default(T);

        foreach (T item in this)
        {
            if (item.CompareTo(maxElement) > 0)
            {
                maxElement = item;
            }
        }

        return maxElement;
    }

    public T Min()
    {
        T minElement = this.Max();

        foreach (T item in this)
        {
            if (item.CompareTo(minElement) < 0)
            {
                minElement = item;
            }
        }

        return minElement;
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, this);
    }
}