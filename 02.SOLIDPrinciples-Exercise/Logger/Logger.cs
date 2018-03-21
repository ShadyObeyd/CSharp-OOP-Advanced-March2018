using System.Text;

internal class Logger : ILogger
{
    private IAppender[] appenders;
    private ReportThreshold report;

    public Logger(params IAppender[] appenders)
    {
        this.appenders = appenders;
    }

    public void Info(string datetime, string message)
    {
        this.report = ReportThreshold.INFO;
        this.SetAppenderReports(datetime, message);
    }

    public void Warn(string datetime, string message)
    {
        this.report = ReportThreshold.WARNING;
        this.SetAppenderReports(datetime, message);
    }

    public void Error(string datetime, string message)
    {
        this.report = ReportThreshold.ERROR;
        this.SetAppenderReports(datetime, message);
    }

    public void Critical(string datetime, string message)
    {
        this.report = ReportThreshold.CRITICAL;
        this.SetAppenderReports(datetime, message);
    }

    public void Fatal(string datetime, string message)
    {
        this.report = ReportThreshold.FATAL;
        this.SetAppenderReports(datetime, message);
    }

    private void SetAppenderReports(string datetime, string message)
    {
        foreach (IAppender appender in this.appenders)
        {
            if (this.report >= appender.Report)
            {
                ReportThreshold appenderReport = appender.Report;
                appender.Report = this.report;
                appender.MessagesCount++;
                appender.Append(datetime, message);
                appender.Report = appenderReport;
            }
        }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine("Logger info");

        foreach (IAppender appender in this.appenders)
        {
            builder.AppendLine(appender.ToString());
        }

        return builder.ToString().TrimEnd();
    }
}