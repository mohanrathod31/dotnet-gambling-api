namespace GambleAPI.GambleAPI.Domain.Models
{
    public class GameResult
    {
        public int Account { get; set; }
        public string Status { get; set; } = string.Empty;
        public int Points { get; set; }
    }
}
