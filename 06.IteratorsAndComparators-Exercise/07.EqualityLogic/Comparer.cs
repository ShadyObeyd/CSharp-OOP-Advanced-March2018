using System.Collections.Generic;

public class Comparer : IEqualityComparer<Person>
{
    public bool Equals(Person x, Person y)
    {
        return x.CompareTo(y) == 0;
    }

    public int GetHashCode(Person person)
    {
        return $"{person.Name} {person.Age}".GetHashCode();
    }
}