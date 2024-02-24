using GambleAPI.GambleAPI.Domain.Models;
using GambleAPI.GambleAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await _playerRepository.GetAllPlayers();
        }

        [HttpPost]
        public IActionResult AddPlayer([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _playerRepository.AddPlayer(player);

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



        [HttpPut]
        public IActionResult UpdatePlayer([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _playerRepository.UpdatePlayer(player);
            return Ok(player);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(Guid id)
        {
            _playerRepository.DeletePlayer(id);
            return Ok();
        }
    }
}
