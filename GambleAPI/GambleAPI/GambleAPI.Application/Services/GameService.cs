using GambleAPI.Exceptions;
using GambleAPI.GambleAPI.Domain.Models;
using GambleAPI.GambleAPI.Infrastructure.Repositories;
using System.Numerics;

namespace GambleAPI.GambleAPI.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public GameService(IPlayerRepository playerRepository, IRandomNumberGenerator randomNumberGenerator)
        {
            _playerRepository = playerRepository;
            _randomNumberGenerator = randomNumberGenerator;
        }

        public GameResult Play(Bet bet)
        {
            var player = _playerRepository.GetPlayerById(bet.PlayerId);
            if (player == null)
            {
                throw new PlayerNotFoundException("Player not found.");
            }

            if (player.Points < bet.Points)
            {
                throw new InsufficientFundsException("Player has insufficient funds.");
            }

            int randomNumber = _randomNumberGenerator.Next(10);
            if (randomNumber == bet.Number)
            {
                player.Points += bet.Points * 9;
                _playerRepository.UpdatePlayer(player);
                return new GameResult { Account = player.Points, Status = "won", Points = bet.Points * 9 };
            }
            else
            {
                player.Points -= bet.Points;
                _playerRepository.UpdatePlayer(player);
                return new GameResult { Account = player.Points, Status = "lost", Points = -bet.Points };
            }
        }
    }

}
