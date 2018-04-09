using System;
using System.Linq;

public class Database
{
    private const int DATABASE_CAPACITY = 16;

    private Person[] people;

    public Database(params Person[] people)
    {
        this.People = people;
    }

    public Person[] People
    {
        get
        {
            return this.people;
        }
        private set
        {
            if (value.Length > DATABASE_CAPACITY)
            {
                throw new InvalidOperationException("The sequence cannot contain more than 16 parameters!");
            }
            this.people = value;
        }
    }

    public void Add(Person person)
    {
        if (this.people.Length == DATABASE_CAPACITY)
        {
            throw new InvalidOperationException("Cannot add element - sequence limit reached!");
        }

        if (this.people.Any(p => p.Name == person.Name))
        {
            throw new InvalidOperationException($"Database already contains a user with name {person.Name}");
        }

        if (this.people.Any(p => p.Id == person.Id))
        {
            throw new InvalidOperationException($"Database already contains a user with Id {person.Id}");
        }

        Person[] newDatabase = new Person[this.people.Length + 1];

        for (int i = 0; i < newDatabase.Length - 1; i++)
        {
            newDatabase[i] = this.people[i];
        }

        newDatabase[newDatabase.Length - 1] = person;

        this.people = newDatabase;
    }

    public Person Remove()
    {
        if (this.people.Length == 0)
        {
            throw new InvalidOperationException("Cannot remove element from an empty sequence!");
        }

        Person elementToRemove = this.people[this.people.Length - 1];

        Person[] newDatabase = new Person[this.people.Length - 1];

        for (int i = 0; i < newDatabase.Length; i++)
        {
            newDatabase[i] = this.people[i];
        }

        this.people = newDatabase;

        return elementToRemove;
    }

    public Person[] Fetch()
    {
        return this.People;
    }

    public Person FindByUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentNullException("", "Invalid name to search for!");
        }

        if (!this.people.Any(p => p.Name == username))
        {
            throw new InvalidOperationException($"Database doesn't contain a person with name: {username}");
        }

        Person person = this.people.First(p => p.Name == username);

        return person;
    }

    public Person FindById(long id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException("", "Id cannot be negative!");
        }

        if (!this.people.Any(p => p.Id == id))
        {
            throw new InvalidOperationException($"Database doesn't contain a person with Id: {id}");
        }

        Person person = this.people.First(p => p.Id == id);

        return person;
    }

}