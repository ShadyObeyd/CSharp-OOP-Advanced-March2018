using System;

public class Client : IClient
{
    private ITweet tweet;

    public Client(ITweet tweet)
    {
        this.tweet = tweet ?? throw new ArgumentException("Tweet cannot be null!");
    }

    public void PrintMessage()
    {
        string message = this.tweet.RetrieveMessage();

        Console.WriteLine(message);
    }
}