using NUnit.Framework;
using System.Reflection;

public class TweetTests
{
    [Test]
    public void InitializeTweetCorrectly()
    {
        string message = "This is a message.";

        Tweet tweet = new Tweet(message);

        FieldInfo field = typeof(Tweet).GetField("message", BindingFlags.NonPublic | BindingFlags.Instance);

        string value = (string)field.GetValue(tweet);

        Assert.That(value, Is.EqualTo(message));
    }

    [Test]
    public void TweetThrowsExceptionIfInitializedWithEmpyParameter()
    {
        Assert.That(() => new Tweet(""), Throws.ArgumentException.With.Message.EqualTo("Invalid message!"));
    }

    [Test]
    public void TweetThrowsExceptionIfInitializedWithNull()
    {
        Assert.That(() => new Tweet(null), Throws.ArgumentException.With.Message.EqualTo("Invalid message!"));
    }

    [Test]
    public void RetrieveMessageReturnsTheCorrectValue()
    {
        string message = "This is a message.";

        Tweet tweet = new Tweet(message);

        Assert.That(tweet.RetrieveMessage(), Is.EqualTo(message));
    }
}