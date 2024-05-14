using Log4U.Core.Appenders.Interfaces;
using Log4U.Core.Enums;
using Log4U.Core.IO;
using Log4U.Core.Layouts.Interfaces;
using Log4U.Core.Models;

namespace Log4U.Core.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ILogFile file, ReportLevel reportLevel = ReportLevel.Info)
        {
            Layout = layout;
            LogFile = file;
            ReportLevel = reportLevel;
        }
        public ILogFile LogFile { get; private set; }
        public ReportLevel ReportLevel { get; set; }

        public ILayout Layout { get; private set; }

        public int MessagesAppended { get; private set; }

        public void AppendMessage(Message message)
        {
            string content = string.Format(Layout.Format, message.DateTime, message.ReportLevel, message.MessageText);
            using StreamWriter writer =new StreamWriter(LogFile.FullPath, true);
            {
                writer.WriteLine(content);
            }
        }
    }
}
