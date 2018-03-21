internal interface IAppender
{
    ReportThreshold Report { get; set; }
    int MessagesCount { get; set; }

    void Append(string datetime, string message);
}