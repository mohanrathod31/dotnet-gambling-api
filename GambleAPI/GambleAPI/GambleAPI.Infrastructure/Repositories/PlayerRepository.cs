using GambleAPI.GambleAPI.Domain.Models;

namespace GambleAPI.GambleAPI.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<Player> _players = new List<Player>();
        private int _nextId = 1; // Assuming an auto-incrementing ID for simplicity

        public PlayerRepository()
        {
            // Adding sample player records during initialization
            AddPlayer(new Player { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Username = "player1", Points = 10000 });
            AddPlayer(new Player { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Username = "player2", Points = 50 });
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _players;
        }

        public Player GetPlayerById(Guid id)
        {
            return _players.FirstOrDefault(p => p.Id == id && p.Points >= 1 && p.Points <= 10000);
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public void UpdatePlayer(Player player)
        {
            var existingPlayer = _players.FirstOrDefault(p => p.Id == player.Id);
            if (existingPlayer != null)
            {
                existingPlayer.Username = player.Username;
                existingPlayer.Points = player.Points;
            }
            else
            {
                throw new ArgumentException("Player not found");
            }
        }

        public void DeletePlayer(Guid id)
        {
            _players.RemoveAll(p => p.Id == id);
        }
    }
}
