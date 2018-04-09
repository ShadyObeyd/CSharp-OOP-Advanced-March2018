using Moq;
using NUnit.Framework;
using System.Reflection;

public class ClientTests
{
    [Test]
    public void InitializesClientCorrectly()
    {
        Tweet tweet = new Tweet("This is a message.");

        Client client = new Client(tweet);

        FieldInfo field = typeof(Client).GetField("tweet", BindingFlags.NonPublic | BindingFlags.Instance);

        Tweet expectedTweet = (Tweet)field.GetValue(client);

        Assert.That(expectedTweet, Is.EqualTo(tweet));
    }

    [Test]
    public void ThrowsExceptionIfParameterIsNull()
    {
        Assert.That(() => new Client(null), Throws.ArgumentException.With.Message.EqualTo("Tweet cannot be null!"));
    }

    [Test]
    public void PrintMessageReturnsTheCorrectMessage()
    {
        Mock<ITweet> fakeTweet = new Mock<ITweet>();

        fakeTweet.Setup(m => m.RetrieveMessage()).Returns("This is a message.");

        Client client = new Client(fakeTweet.Object);

        client.PrintMessage(); // When using the Test's output window we can see it works correctly.
    }
}