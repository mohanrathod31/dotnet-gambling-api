namespace GambleAPI.GambleAPI.Domain.Models
{
    public class PlayResponse
    {
        public int Account { get; set; }
        public string Status { get; set; } = string.Empty;
        public int Points { get; set; }
    }
}
