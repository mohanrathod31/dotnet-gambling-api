namespace GambleAPI.Exceptions
{
    public class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException() : base("Player not found.")
        {
        }

        public PlayerNotFoundException(string message) : base(message)
        {
        }

        public PlayerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

