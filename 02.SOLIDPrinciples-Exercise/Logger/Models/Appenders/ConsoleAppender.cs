using System;

internal class ConsoleAppender : Appender
{
    public ConsoleAppender(ILayout layout) : base(layout)
    {

    }

    public override void Append(string datetime, string message)
    {
        base.Append(datetime, message);
    }
}