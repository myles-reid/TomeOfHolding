using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.BLL.Exceptions;
using TomeOfHolding.Models;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class PlayerController : ControllerBase {
		private readonly PlayerService _playerService;

		public PlayerController(PlayerService playerService) {
			_playerService = playerService;
		}

		[HttpGet]
		public async Task<IActionResult> GetPlayers() {
			try {
				List<Player> players = await _playerService.GetPlayers();
				return Ok(players);
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetPlayer(int id) {
			try {
				Player? player = await _playerService.GetPlayerById(id);
				return Ok(player);
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreatePlayer(Player player) {
			if (!ModelState.IsValid) return BadRequest("Invalid player data.");
			await _playerService.CreatePlayer(player);
			return CreatedAtAction(nameof(GetPlayers), new { id = player.PlayerId }, player);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePlayer(int id) {
			try {
				await _playerService.DeletePlayer(id);
				return NoContent();
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdatePlayer(int id, Player player) {
			try {
				if (id != player.PlayerId) return BadRequest("Player ID mismatch.");
				await _playerService.UpdatePlayer(player);
				return Ok("Player updated");
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}
	}
}
