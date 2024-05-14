namespace Log4U.Core.Exceptions
{
    internal class EmptyMessageTextException : Exception
    {

        private const string defaultMessage = "Message cannot be null, empty or whitespace";
        public override string Message { get; }
        public EmptyMessageTextException(string message = defaultMessage)
            : base(message)
        {
        }

    }
}
