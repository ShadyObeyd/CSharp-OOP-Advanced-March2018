using System;

public class Database
{
    private const int DATABASE_CAPACITY = 16;

    private int[] database;

    public Database(params int[] integers)
    {
        this.StoredData = integers;
    }

    public int[] StoredData
    {
        get
        {
            return this.database;
        }
        private set
        {
            if (value.Length > DATABASE_CAPACITY)
            {
                throw new InvalidOperationException("The sequence cannot contain more than 16 parameters!");
            }
            this.database = value;
        }
    }

    public void Add(int element)
    {
        if (this.database.Length == DATABASE_CAPACITY)
        {
            throw new InvalidOperationException("Cannot add element - sequence limit reached!");
        }

        int[] newDatabase = new int[this.database.Length + 1];

        for (int i = 0; i < newDatabase.Length - 1; i++)
        {
            newDatabase[i] = this.database[i];
        }

        newDatabase[newDatabase.Length - 1] = element;

        this.database = newDatabase;
    }

    public int Remove()
    {
        if (this.database.Length == 0)
        {
            throw new InvalidOperationException("Cannot remove element from an empty sequence!");
        }

        int elementToRemove = this.database[this.database.Length - 1];

        int[] newDatabase = new int[this.database.Length - 1];

        for (int i = 0; i < newDatabase.Length; i++)
        {
            newDatabase[i] = this.database[i];
        }

        this.database = newDatabase;

        return elementToRemove;
    }

    public int[] Fetch()
    {
        return this.StoredData;
    }

}