using NUnit.Framework;
using System.Linq;
using System;

public class DatabaseTests
{
    [Test]
    public void DatabaseInitializesWithLessThanLimitParameters()
    {
        Person[] people = { new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036) };

        Database database = new Database(people);

        Assert.That(database.People, Is.EqualTo(people));
    }

    [Test]
    public void DatabaseInitializesNoParameters()
    {
        Database database = new Database();

        Assert.That(database.People, Is.EqualTo(new Person[] { }));
    }

    [Test]
    public void DatabaseThrowsExceptionWhenInitializedWithMoreThanLimitParameters()
    {
        Person[] people =
        {
            new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036), new Person("Stamat", 33333432423),
            new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036), new Person("Stamat", 33333432423),
            new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036), new Person("Stamat", 33333432423),
            new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036), new Person("Stamat", 33333432423),
            new Person("Stamat", 33333432423)
        };

        Assert.That(() => new Database(people), Throws.InvalidOperationException.With.Message.EqualTo("The sequence cannot contain more than 16 parameters!"));
    }

    [Test]
    public void AddsPersonCorrectly()
    {
        Person[] people = { new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036) };

        Database database = new Database(people);

        Person personToAdd = new Person("Stamat", 1000);

        database.Add(personToAdd);

        Assert.That(database.People.Last, Is.EqualTo(personToAdd));
    }

    [Test]
    public void ThrowsExceptionWhenCapacityReachedIfTryToAdd()
    {
        Person[] people =
        {
            new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036), new Person("Stamat", 33333432423),
            new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036), new Person("Stamat", 33333432423),
            new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036), new Person("Stamat", 33333432423),
            new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036), new Person("Stamat", 33333432423),
        };
    
        Database database = new Database(people);

        Assert.That(() => database.Add(new Person("Ivailo", 10000)), Throws.InvalidOperationException.With.Message.EqualTo("Cannot add element - sequence limit reached!"));
    }

    [Test]
    public void AddThrowsExceptionIfDatabaseContainsPersonWithSameName()
    {
        Person[] people = { new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036) };

        Database database = new Database(people);

        Person personToadd = new Person("Gosho", 100);

        Assert.That(() => database.Add(personToadd), Throws.InvalidOperationException.With.Message.EqualTo($"Database already contains a user with name {personToadd.Name}"));
    }

    [Test]
    public void AddThrowsExceptionIfDatabaseContainsPersonWithSameId()
    {
        Person[] people = { new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036) };

        Database database = new Database(people);

        Person personToadd = new Person("Stamat", 1093);

        Assert.That(() => database.Add(personToadd), Throws.InvalidOperationException.With.Message.EqualTo($"Database already contains a user with Id {personToadd.Id}"));
    }

    [Test]
    public void RemovesPersonCorrectly()
    {
        Person[] people = { new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036) };

        Database database = new Database(people);

        Person expectedLastPerson = people[people.Length - 2];

        database.Remove();

        Assert.That(database.People.Last(), Is.EqualTo(expectedLastPerson));
    }

    [Test]
    public void RemoveReturnsCorrectElement()
    {
        Person[] people = { new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036) };

        Database database = new Database(people);

        Person expectedLastPerson = people[people.Length - 1];

        Assert.That(() => database.Remove(), Is.EqualTo(expectedLastPerson));
    }

    [Test]
    public void RemoveThrowsExceptionIfCollectionEmpty()
    {
        Database database = new Database();

        Assert.That(() => database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("Cannot remove element from an empty sequence!"));
    }

    [Test]
    public void FetchReturnsTheCorrectCollection()
    {
        Person[] people = { new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036) };

        Database database = new Database(people);

        Assert.That(() => database.Fetch(), Is.EqualTo(people));
    }

    [Test]
    public void FindByUsernameReturnsCorrectPerson()
    {
        Person[] people = { new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036) };

        Database database = new Database(people);

        Person expectedResult = people[people.Length - 2];

        string usernameParameter = "Gosho";

        Assert.That(database.FindByUsername(usernameParameter), Is.EqualTo(expectedResult));
    }

    [Test]
    public void FindByUsernameThrowsExceptionIfParameterIsNull()
    {
        Person[] people = { new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036) };

        Database database = new Database(people);

        Assert.That(() => database.FindByUsername(null), Throws.ArgumentNullException.With.Message.EqualTo("Invalid name to search for!"));
    }

    [Test]
    public void FindByUsernameThrowsExceptionIfNoPersonHasNameParameter()
    {
        Person[] people = { new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036) };

        Database database = new Database(people);

        string usernameParameter = "Ivailo";

        Assert.That(() => database.FindByUsername(usernameParameter), Throws.InvalidOperationException.With.Message.EqualTo($"Database doesn't contain a person with name: {usernameParameter}"));
    }

    [Test]
    public void FindByIdReturnsCorrectPerson()
    {
        Person[] people = { new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036) };

        Database database = new Database(people);

        Person expectedResult = people[people.Length - 2];

        long idParameter = 1093;

        Assert.That(database.FindById(idParameter), Is.EqualTo(expectedResult));
    }

    [Test]
    public void FindByIdThrowsExceptionIfParameterIsNegative()
    {
        Person[] people = { new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036) };

        Database database = new Database(people);

        long idParameter = -1093;

        Assert.That(() => database.FindById(idParameter), Throws.Exception.TypeOf<ArgumentOutOfRangeException>().With.Message.EqualTo("Id cannot be negative!"));
    }

    [Test]
    public void FindByIdThrowsExceptionIfNoPersonWithParameterIsContained()
    {
        Person[] people = { new Person("Pesho", 90), new Person("Gosho", 1093), new Person("Balkan", 1036) };

        Database database = new Database(people);

        long idParameter = 33333;

        Assert.That(() => database.FindById(idParameter), Throws.InvalidOperationException.With.Message.EqualTo($"Database doesn't contain a person with Id: {idParameter}"));
    }
}