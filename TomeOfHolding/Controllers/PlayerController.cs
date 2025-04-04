using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class PlayerController : ControllerBase {
		private readonly PlayerService _playerService;

		public PlayerController(PlayerService playerService) {
			_playerService = playerService;
		}
	}
}
