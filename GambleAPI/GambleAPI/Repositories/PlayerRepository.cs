using GambleAPI.Models;

namespace GambleAPI.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<Player> _players = new List<Player>();
        private int _nextId = 1; // Assuming an auto-incrementing ID for simplicity

        public void Add(Player player)
        {
            player.Id = Guid.NewGuid();
            _players.Add(player);
        }

        public void Delete(Guid id)
        {
            _players.RemoveAll(p => p.Id == id);
        }

        public IEnumerable<Player> GetAll()
        {
            return _players;
        }

        public Player GetById(Guid id)
        {
            return _players.FirstOrDefault(p => p.Id == id);
        }

        public Player GetByUsername(string username)
        {
            return _players.FirstOrDefault(p => p.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public void Update(Player player)
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
    }
}
