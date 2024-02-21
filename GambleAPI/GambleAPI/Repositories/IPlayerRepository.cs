using GambleAPI.Models;

namespace GambleAPI.Repositories
{
    public interface IPlayerRepository
    {
        Player GetById(Guid id);
        Player GetByUsername(string username);
        IEnumerable<Player> GetAll();
        void Add(Player player);
        void Update(Player player);
        void Delete(Guid id);
    }
}
