namespace GambleAPI.GambleAPI.Domain.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public int Points { get; set; }
    }
}
