namespace Log4U.Core.Exceptions
{
    public class InvalidDateTimeFormatException : Exception
    {
        private const string defaultMessage = "DataTime format is invalid";
        public override string Message { get; }
        public InvalidDateTimeFormatException(string message = defaultMessage)
            : base(message)
        {

        }
    }
}
