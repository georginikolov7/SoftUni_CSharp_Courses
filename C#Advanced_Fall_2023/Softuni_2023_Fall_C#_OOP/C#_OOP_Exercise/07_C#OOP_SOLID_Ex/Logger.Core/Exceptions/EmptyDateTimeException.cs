namespace Log4U.Core.Exceptions
{
    public class EmptyDateTimeException : Exception
    {
        private const string defaultMessage = "DataTime cannot be null, empty or whitespace";
        public override string Message { get; }
        public EmptyDateTimeException(string message = defaultMessage)
            : base(message)
        {

        }
    }
}
