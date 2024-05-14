using Log4U.Core.Appenders.Interfaces;


namespace Log4U.Core.Loggers.Interfaces
{
    public interface ILogger
    {
        ICollection<IAppender> Appenders { get; }

        void Info(string dateTime, string message);
        void Warning(string dateTime, string message);
        void Error(string dateTime, string message);
        void Critical(string dateTime, string message);
        void Fatal(string dateTime, string message);

    }
}
