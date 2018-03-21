using System;

internal abstract class Appender : IAppender
{
    protected ILayout layout;

    protected Appender(ILayout layout)
    {
        this.layout = layout;
        this.Report = ReportThreshold.INFO;
        this.MessagesCount = 0;
    }

    public ReportThreshold Report { get; set; }
    public int MessagesCount { get; set; }

    public virtual void Append(string datetime, string message)
    {
        string result = string.Format(this.layout.ToString(), datetime, this.Report, message);

        Console.WriteLine(result);
    }

    public override string ToString()
    {
        return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.Report}, Messages appended: {this.MessagesCount}";
    }
}