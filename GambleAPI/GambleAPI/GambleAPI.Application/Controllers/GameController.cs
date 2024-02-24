using GambleAPI.Exceptions;
using GambleAPI.GambleAPI.Application.Services;
using GambleAPI.GambleAPI.Domain.Models;
using GambleAPI.GambleAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GambleAPI.GambleAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IPlayerRepository _playerRepository;

        public GameController(IGameService gameService, IPlayerRepository playerRepository)
        {
            _gameService = gameService;
            _playerRepository = playerRepository;
        }

        [HttpPost]
        public IActionResult Play([FromBody] Bet betRequest)
        {
            try
            {
                var result = _gameService.Play(betRequest);

                return Ok(result);
            }
            catch (PlayerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InsufficientFundsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
