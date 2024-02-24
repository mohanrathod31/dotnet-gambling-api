namespace GambleAPI.Exceptions
{
    public class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException() { }
        public PlayerNotFoundException(string message) : base(message) { }
        public PlayerNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() { }
        public InsufficientFundsException(string message) : base(message) { }
        public InsufficientFundsException(string message, Exception innerException) : base(message, innerException) { }
    }
}

