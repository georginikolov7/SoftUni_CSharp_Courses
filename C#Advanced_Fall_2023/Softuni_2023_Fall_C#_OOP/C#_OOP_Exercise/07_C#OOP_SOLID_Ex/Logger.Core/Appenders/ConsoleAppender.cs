using Log4U.Core.Appenders.Interfaces;
using Log4U.Core.Enums;
using Log4U.Core.Layouts.Interfaces;
using Log4U.Core.Models;


namespace Log4U.Core.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        {
            Layout = layout;
            ReportLevel = reportLevel;
        }
        public ReportLevel ReportLevel { get; set; }

        public ILayout Layout { get; private set; }

        public int MessagesAppended { get; private set; }

        public void AppendMessage(Message message)
        {
            if (message.ReportLevel >= this.ReportLevel)
            {
                MessagesAppended++;
                Console.WriteLine(string.Format(Layout.Format, message.DateTime, message.ReportLevel, message.MessageText));
            }
        }

        public string getAppenderInfo()
        {
            throw new NotImplementedException();
        }

        //public string getAppenderInfo()
        //{
        //    throw new NotImplementedException ();
        //   // StringBuilder sb = new();
        //}
    }
}
