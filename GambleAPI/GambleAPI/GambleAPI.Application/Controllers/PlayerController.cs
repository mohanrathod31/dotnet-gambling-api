using GambleAPI.GambleAPI.Domain.Models;
using GambleAPI.GambleAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GambleAPI.GambleAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpPost]
        public IActionResult AddPlayer([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _playerRepository.Add(player);
            return Ok(player);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlayer(Guid id)
        {
            var player = _playerRepository.GetPlayerById(id);
            if (player == null)
            {
                return NotFound($"Player with ID {id} not found.");
            }
            return Ok(player);
        }

        [HttpGet("username/{username}")]
        public IActionResult GetPlayerByUsername(string username)
        {
            var player = _playerRepository.GetByUsername(username);
            if (player == null)
            {
                return NotFound($"Player with username {username} not found.");
            }
            return Ok(player);
        }

        [HttpGet]
        public IActionResult GetAllPlayers()
        {
            var players = _playerRepository.GetAll();
            return Ok(players);
        }

        [HttpPut]
        public IActionResult UpdatePlayer([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingPlayer = _playerRepository.GetPlayerById(player.Id);
            if (existingPlayer == null)
            {
                return NotFound($"Player with ID {player.Id} not found.");
            }

            _playerRepository.UpdatePlayer(player);
            return Ok(player);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(Guid id)
        {
            var player = _playerRepository.GetPlayerById(id);
            if (player == null)
            {
                return NotFound($"Player with ID {id} not found.");
            }

            _playerRepository.Delete(id);
            return Ok();
        }


    }
}
