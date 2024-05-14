using Log4U.Core.Appenders.Interfaces;
using Log4U.Core.Enums;
using Log4U.Core.Loggers.Interfaces;
using Log4U.Core.Models;

namespace Log4U.Core.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders;
        }
        public ICollection<IAppender> Appenders { get; }

        public void Info(string dateTime, string message)
        {
            AppendAll(dateTime, message, ReportLevel.Info);
        }
        public void Warning(string dateTime, string message)
        {
            AppendAll(dateTime, message, ReportLevel.Warning);
        }
        public void Error(string dateTime, string message)
        {
            AppendAll(dateTime, message, ReportLevel.Error);
        }

        public void Critical(string dateTime, string message)
        {
            AppendAll(dateTime, message, ReportLevel.Critical);
        }

        public void Fatal(string dateTime, string message)
        {
            AppendAll(dateTime, message, ReportLevel.Fatal);
        }



        private void AppendAll(string dateTime, string messageText, ReportLevel reportLevel)
        {
            Message message = new(dateTime, messageText, reportLevel);
            foreach (var appender in Appenders)
            {
                appender.AppendMessage(message);
            }
        }
    }
}
