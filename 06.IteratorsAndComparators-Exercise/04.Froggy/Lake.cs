using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lake<T> : IEnumerable<T>
{
    private List<T> list;

    public Lake(params T[] parameters)
    {
        this.list = parameters.ToList();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.list.Count; i++)
        {
            if (i % 2 == 0)
            {
                yield return list[i];
            }
        }

        for (int i = this.list.Count - 1; i >= 0; i--)
        {
            if (i % 2 != 0)
            {
                yield return list[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}