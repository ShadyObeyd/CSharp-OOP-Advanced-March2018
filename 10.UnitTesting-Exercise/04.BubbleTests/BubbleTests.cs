using NUnit.Framework;
using System.Reflection;

public class BubbleTests
{
    [Test]
    public void ConstructorThrowsExceptionIfParameterIsNull()
    {
        Assert.That(() => new Bubble(null), Throws.ArgumentException.With.Message.EqualTo("Input cannot be null!"));
    }

    [Test]
    public void ConstructorInitializesClassCorrectly()
    {
        int[] parameters = { 5, 10, 28, 33, 7, 3 };
    
        Bubble bubble = new Bubble(parameters);

        FieldInfo field = typeof(Bubble).GetField("arr", BindingFlags.NonPublic | BindingFlags.Instance);

        int[] value = (int[])field.GetValue(bubble);

        Assert.That(value, Is.EqualTo(parameters));
    }

    [Test]
    public void SortedArrReturnsSortedCollection()
    {
        int[] parameters = { 8, 5, 6, 4, 1, 3, 2, 10, 0, 9, 7 };

        Bubble bubble = new Bubble(parameters);

        int[] expectedResult = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Assert.That(bubble.SortArr(), Is.EqualTo(expectedResult));
    }

    [Test]
    public void SortArrThrowsExceptionIfArrayIsEmpty()
    {
        Bubble bubble = new Bubble();
        Assert.That(() => bubble.SortArr(), Throws.InvalidOperationException.With.Message.EqualTo("Cannot sort an empty collection!"));
    }

    [Test]
    public void InitialParametersAndSortedArrAreNotEqual()
    {
        int[] parameters = { 8, 5, 6, 4, 1, 3, 2, 10, 0, 9, 7 };

        Bubble bubble = new Bubble(parameters);

        int[] expectedResult = { 8, 5, 6, 4, 1, 3, 2, 10, 0, 9, 7 };

        Assert.That(bubble.SortArr(), Is.Not.EqualTo(expectedResult));
    }
}