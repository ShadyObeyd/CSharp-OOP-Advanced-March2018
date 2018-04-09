using NUnit.Framework;
using System;
using System.Reflection;

public class ListIteratorTests
{
    [Test]
    public void InitializesTheCollectionCorrectlyWithArguments()
    {
        string[] parameters = new string[] { "Pesho", "Gosho", "Sasho", "Stamat", "Balkan" };

        ListIterator iterator = new ListIterator(parameters);

        Assert.That(iterator.Collection, Is.EqualTo(parameters));
    }

    [Test]
    public void ThrowsExceptionIfNoArgumentsArePassed()
    {
        Assert.That(() => new ListIterator(null), Throws.ArgumentException.With.Message.EqualTo("Collection cannot be null!"));
    }

    [Test]
    public void SetsInternalIndexToZero()
    {
        string[] parameters = new string[] { "Pesho", "Gosho", "Sasho", "Stamat", "Balkan" };

        FieldInfo field = typeof(ListIterator).GetField("index", BindingFlags.NonPublic | BindingFlags.Instance);

        ListIterator iterator = new ListIterator(parameters);

        int wantedValue = (int)field.GetValue(iterator);

        Assert.That(wantedValue, Is.EqualTo(0));
    }

    [Test]
    public void MoveIncrementsInternalIndexIfInRange()
    {
        string[] parameters = new string[] { "Pesho", "Gosho", "Sasho", "Stamat", "Balkan" };

        FieldInfo field = typeof(ListIterator).GetField("index", BindingFlags.NonPublic | BindingFlags.Instance);

        ListIterator iterator = new ListIterator(parameters);

        iterator.Move();

        int wantedValue = (int)field.GetValue(iterator);

        int expectedValue = 1;

        Assert.That(wantedValue, Is.EqualTo(expectedValue));
    }

    [Test]
    public void MoveReturnsTrueIfIndexWithinRange()
    {
        string[] parameters = new string[] { "Pesho", "Gosho", "Sasho", "Stamat", "Balkan" };

        ListIterator iterator = new ListIterator(parameters);

        Assert.That(iterator.Move(), Is.EqualTo(true));
    }

    [Test]
    public void MoveDoesNotIncrementIndexIfNotInRange()
    {
        string[] parameters = new string[] { "Pesho" };

        FieldInfo field = typeof(ListIterator).GetField("index", BindingFlags.NonPublic | BindingFlags.Instance);

        ListIterator iterator = new ListIterator(parameters);

        iterator.Move();

        int wantedValue = (int)field.GetValue(iterator);

        int expectedValue = 0;

        Assert.That(wantedValue, Is.EqualTo(expectedValue));
    }

    [Test]
    public void MoveReturnsFalseIfIndexIsNotInRange()
    {
        string[] parameters = new string[] { "Pesho" };

        ListIterator iterator = new ListIterator(parameters);

        Assert.That(iterator.Move(), Is.EqualTo(false));
    }

    [Test]
    public void HasNextReturnsTrueIfIndexInRange()
    {
        string[] parameters = new string[] { "Pesho", "Gosho", "Sasho", "Stamat", "Balkan" };

        ListIterator iterator = new ListIterator(parameters);

        Assert.That(iterator.HasNext(), Is.EqualTo(true));
    }

    [Test]
    public void HasNextReturnsFalseIfIndexNotInRange()
    {
        string[] parameters = new string[] { "Pesho" };

        ListIterator iterator = new ListIterator(parameters);

        Assert.That(iterator.HasNext(), Is.EqualTo(false));
    }

    [Test]
    public void PrintReturnsTheCorrectElement()
    {
        string[] parameters = new string[] { "Pesho", "Gosho", "Sasho", "Stamat", "Balkan" };

        ListIterator iterator = new ListIterator(parameters);

        iterator.Move();

        string expectedValue = "Gosho";

        Assert.That(iterator.Print(), Is.EqualTo(expectedValue));
    }

    [Test]
    public void PrintThrowsExceptionIfCollectionEmpty()
    {
        ListIterator iterator = new ListIterator();
        
        Assert.That(() => iterator.Print(), Throws.InvalidOperationException.With.Message.EqualTo("Invalid Operation!"));
    }
}