using GambleAPI.GambleAPI.Domain.Models;

namespace GambleAPI.GambleAPI.Application.Services
{
    public interface IGameService
    {
        GameResult Play(Bet bet);
    }

}
