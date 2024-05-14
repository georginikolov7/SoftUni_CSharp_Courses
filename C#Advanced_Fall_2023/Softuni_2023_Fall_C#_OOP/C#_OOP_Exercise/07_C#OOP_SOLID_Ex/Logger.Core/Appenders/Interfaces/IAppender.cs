using Log4U.Core.Enums;
using Log4U.Core.Layouts.Interfaces;
using Log4U.Core.Models;

namespace Log4U.Core.Appenders.Interfaces
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }
        ILayout Layout { get; }
        public int MessagesAppended { get; }
        void AppendMessage(Message message);
        //string getAppenderInfo();
    }
}
