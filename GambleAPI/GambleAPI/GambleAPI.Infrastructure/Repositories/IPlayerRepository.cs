using GambleAPI.GambleAPI.Domain.Models;

namespace GambleAPI.GambleAPI.Infrastructure.Repositories
{
    public interface IPlayerRepository
    {
        Player GetPlayerById(Guid id);
        Task<IEnumerable<Player>> GetAllPlayers();
        Player AddPlayer(Player player);
        void UpdatePlayer(Player player);
        void DeletePlayer(Guid id);
    }
}
