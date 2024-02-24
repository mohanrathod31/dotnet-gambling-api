using GambleAPI.Exceptions;
using GambleAPI.GambleAPI.Domain.Models;
using GambleAPI.GambleAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GambleAPI.GambleAPI.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public readonly GambleDbContext _dbContext;
        private readonly List<Player> _players = new List<Player>();

        public PlayerRepository(GambleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await _dbContext.players.ToListAsync();
        }

        public Player GetPlayerById(Guid id)
        {
            return _dbContext.players.FirstOrDefault(p => p.Id == id);
        }

        public Player AddPlayer(Player player)
        {
            var playerObj = new Player()
            {
                Id = player.Id,
                Username = player.Username,
                Points = player.Points,
            };

            _dbContext.players.Add(playerObj);
            _dbContext.SaveChanges();
            return playerObj;
 
        }

        public void UpdatePlayer(Player player)
        {
            var existingPlayer = _dbContext.players.FirstOrDefault(p => p.Id == player.Id);
            if (existingPlayer != null)
            {
                existingPlayer.Username = player.Username;
                existingPlayer.Points = player.Points;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new PlayerNotFoundException("Player not found.");
            }
        }

        public void DeletePlayer(Guid id)
        {
            var player = _dbContext.players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                throw new PlayerNotFoundException("Player not found.");
            }

            _dbContext.Remove(player);
            _dbContext.SaveChanges();

        }
    }
}
