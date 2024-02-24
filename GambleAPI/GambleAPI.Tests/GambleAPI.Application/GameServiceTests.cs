using GambleAPI.GambleAPI.Application.Controllers;
using GambleAPI.GambleAPI.Application.Services;
using GambleAPI.GambleAPI.Infrastructure.Repositories;
using GambleAPI.GambleAPI.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GambleAPI.Exceptions;

namespace GambleAPI.Tests.GambleAPI.Application
{
    public class GameServiceTests
    {
        Mock<IPlayerRepository> playerRepositoryMock = new Mock<IPlayerRepository>();


        [Fact]
        public void Play_ReturnsCorrectWinningsAndStatus_WhenPlayerWins()
        {
            // Arrange
            var playerRepositoryMock = new Mock<IPlayerRepository>();
            var player = new Player { Points = 10000 };
            playerRepositoryMock.Setup(repo => repo.GetPlayerById(It.IsAny<Guid>())).Returns(player);

            var randomNumberGeneratorMock = new Mock<IRandomNumberGenerator>();
            randomNumberGeneratorMock.Setup(rng => rng.Next(10)).Returns(3); // Mocking the random number generator to return 3

            var gameService = new GameService(playerRepositoryMock.Object, randomNumberGeneratorMock.Object);
            var bet = new Bet { PlayerId = Guid.NewGuid(), Points = 100, Number = 3 };

            // Act
            var result = gameService.Play(bet);

            // Assert
            Assert.Equal(900, result.Points);
            Assert.Equal("won", result.Status);
        }

        [Fact]
        public void Play_ReturnsCorrectWinningsAndStatus_WhenPlayerLoses()
        {
            // Arrange
            var playerRepositoryMock = new Mock<IPlayerRepository>();
            var player = new Player { Points = 10000 };
            playerRepositoryMock.Setup(repo => repo.GetPlayerById(It.IsAny<Guid>())).Returns(player);

            var randomNumberGeneratorMock = new Mock<IRandomNumberGenerator>();
            randomNumberGeneratorMock.Setup(rng => rng.Next(10)).Returns(3); // Mocking the random number generator to return 3

            var gameService = new GameService(playerRepositoryMock.Object, randomNumberGeneratorMock.Object);
            var bet = new Bet { PlayerId = Guid.NewGuid(), Points = 100, Number = 5 };

            // Act
            var result = gameService.Play(bet);

            // Assert
            Assert.Equal(-100, result.Points);
            Assert.Equal("lost", result.Status);
        }

        [Fact]
        public void Play_ThrowsPlayerNotFoundException_WhenPlayerNotFound()
        {
            // Arrange
            var playerRepositoryMock = new Mock<IPlayerRepository>();
            playerRepositoryMock.Setup(repo => repo.GetPlayerById(It.IsAny<Guid>())).Returns((Player)null); // Returning null to simulate player not found

            var randomNumberGeneratorMock = new Mock<IRandomNumberGenerator>();

            var gameService = new GameService(playerRepositoryMock.Object, randomNumberGeneratorMock.Object);
            var bet = new Bet { PlayerId = Guid.NewGuid(), Points = 100, Number = 3 };

            // Act & Assert
            Assert.Throws<PlayerNotFoundException>(() => gameService.Play(bet));
        }

        [Fact]
        public void Play_ThrowsInsufficientFundsException_WhenPlayerHasInsufficientFunds()
        {
            // Arrange
            var playerRepositoryMock = new Mock<IPlayerRepository>();
            var player = new Player { Points = 50 }; // Simulating player with insufficient funds
            playerRepositoryMock.Setup(repo => repo.GetPlayerById(It.IsAny<Guid>())).Returns(player);

            var randomNumberGeneratorMock = new Mock<IRandomNumberGenerator>();

            var gameService = new GameService(playerRepositoryMock.Object, randomNumberGeneratorMock.Object);
            var bet = new Bet { PlayerId = Guid.NewGuid(), Points = 100, Number = 3 };

            // Act & Assert
            Assert.Throws<InsufficientFundsException>(() => gameService.Play(bet));
        }
    }
}
