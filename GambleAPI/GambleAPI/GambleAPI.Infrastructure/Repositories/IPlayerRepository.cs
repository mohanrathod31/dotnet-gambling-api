using GambleAPI.GambleAPI.Domain.Models;

namespace GambleAPI.GambleAPI.Infrastructure.Repositories
{
    public interface IPlayerRepository
    {
        Player GetPlayerById(Guid id);
        IEnumerable<Player> GetAllPlayers();
        void AddPlayer(Player player);
        void UpdatePlayer(Player player);
        void DeletePlayer(Guid id);
    }
}
