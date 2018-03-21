using System;

class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        
        IAppender[] appenders = CreateAppenders(n);
        
        string input = Console.ReadLine();
        
        ILogger logger = new Logger(appenders);
        
        while (input != "END")
        {
            string[] inputTokens = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
        
            string reportLevel = inputTokens[0];
            string datetime = inputTokens[1];
            string message = inputTokens[2];
        
            switch (reportLevel)
            {
                case "INFO":
                    logger.Info(datetime, message);
                    break;
                case "WARNING":
                    logger.Warn(datetime, message);
                    break;
                case "ERROR":
                    logger.Error(datetime, message);
                    break;
                case "CRITICAL":
                    logger.Critical(datetime, message);
                    break;
                case "FATAL":
                    logger.Fatal(datetime, message);
                    break;
            }
        
            input = Console.ReadLine();
        }
        
        Console.WriteLine(logger);
    }

    private static IAppender[] CreateAppenders(int n)
    {
        IAppender[] appenders = new IAppender[n];

        for (int i = 0; i < n; i++)
        {
            string[] appenderTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string appenderType = appenderTokens[0];
            string layoutType = appenderTokens[1];

            ILayout layout = null;

            if (layoutType == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (layoutType == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            else
            {
                Console.WriteLine("Invalid layout type!");
            }

            IAppender appender = null;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout);
            }
            else if (appenderType == "FileAppender")
            {
                appender = new FileAppender(layout);
            }
            else
            {
                Console.WriteLine("Invalid appender type!");
            }

            if (appenderTokens.Length > 2)
            {
                string reportLevel = appenderTokens[2];
                appender.Report = Enum.Parse<ReportThreshold>(reportLevel);
            }

            appenders[i] = appender;
        }

        return appenders;
    }
}