using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.Models;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class PlayerController : ControllerBase {
		private readonly PlayerService _playerService;

		public PlayerController(PlayerService playerService) {
			_playerService = playerService;
		}

		public async Task<IActionResult> GetPlayers() {
			// Will need to figure out how to process the NotFound response proplery
			List<Player>? players = await _playerService.GetPlayers();
			if (players == null || players.Count == 0) {
				return NotFound("No players found.");
			}
			return Ok(players);
		}
	}
}
