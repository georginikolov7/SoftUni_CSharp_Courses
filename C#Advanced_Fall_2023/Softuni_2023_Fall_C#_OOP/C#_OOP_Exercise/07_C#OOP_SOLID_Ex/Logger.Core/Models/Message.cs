using Log4U.Core.Enums;
using Log4U.Core.Exceptions;
using Log4U.Core.Utils;

namespace Log4U.Core.Models
{
    public class Message
    {
        private string dateTime;
        private string messageText;
        public Message(string dateTime, string message, ReportLevel reportLevel)
        {
            DateTime = dateTime;
            MessageText = message;
            ReportLevel = reportLevel;
        }

        public ReportLevel ReportLevel { get; private set; }
        public string DateTime
        {
            get => dateTime;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyDateTimeException();
                }

                if (!DateTimeValidator.ValidateDateTime(value))
                {
                    throw new InvalidDateTimeFormatException();
                }
                dateTime = value;
            }
        }
        public string MessageText
        {
            get => messageText;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyMessageTextException();
                }
                messageText = value;
            }
        }
    }
}
