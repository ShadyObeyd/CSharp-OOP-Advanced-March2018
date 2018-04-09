using NUnit.Framework;

public class DatabaseTests
{
    [Test]
    public void InitializesDatabaseWithLessThanLimitParameters()
    {
        int[] parameters = { 5, 10, 20, 35, 40 };

        Database database = new Database(parameters);

        Assert.That(database.StoredData, Is.EqualTo(parameters));
    }

    [Test]
    public void InitializesDatabaseWithNoParameters()
    {
        Database database = new Database();

        Assert.That(database.StoredData, Is.EqualTo(new int[] { }));
    }

    [Test]
    public void DatabaseIsNotSetIfSequenceLimitReached()
    {
        int[] parameters = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

        Assert.That(() => new Database(parameters), Throws.InvalidOperationException.With.Message.EqualTo("The sequence cannot contain more than 16 parameters!"));
    }

    [Test]
    public void AddsElementCorrectly()
    {
        int[] parameters = { 5, 10, 20, 35, 40 };
        int element = 5;

        Database database = new Database(parameters);

        database.Add(element);

        int databaseLastElement = database.StoredData[database.StoredData.Length - 1];

        Assert.That(databaseLastElement, Is.EqualTo(element));
    }

    [Test]
    public void ThrowsExceptionIfTryAddElementIfCapacityReached()
    {
        int[] parameters = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, };
        int element = 5;

        Database database = new Database(parameters);

        Assert.That(() => database.Add(element), Throws.InvalidOperationException.With.Message.EqualTo("Cannot add element - sequence limit reached!"));
    }

    [Test]
    public void RemovesElementCorrectly()
    {
        int[] parameters = { 5, 10, 20, 35, 40 };

        Database database = new Database(parameters);

        database.Remove();

        int[] expectedParameters = { 5, 10, 20, 35 };

        Assert.That(database.StoredData, Is.EqualTo(expectedParameters));
    }

    [Test]
    public void ReturnsCorrectElementWhenRemove()
    {
        int[] parameters = { 5, 10, 20, 35, 40 };

        Database database = new Database(parameters);

        int expectedResult = 40;

        Assert.That(database.Remove(), Is.EqualTo(expectedResult));
    }

    [Test]
    public void ThrowsExceptionIfRemoveFromEmptyDatabase()
    {
        Database database = new Database();

        Assert.That(() => database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("Cannot remove element from an empty sequence!"));
    }

    [Test]
    public void ReturnsElementsCorrectlyWhenFetch()
    {
        int[] parameters = { 5, 10, 20, 35, 40 };

        Database database = new Database(parameters);

        Assert.That(() => database.Fetch(), Is.EqualTo(parameters));
    }
    
}