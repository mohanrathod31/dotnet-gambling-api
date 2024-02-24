namespace GambleAPI.GambleAPI.Domain.Models
{
    public class Bet
    {
        public Guid PlayerId { get; set; }
        public int Points { get; set; }
        public int Number { get; set; }
    }
}
