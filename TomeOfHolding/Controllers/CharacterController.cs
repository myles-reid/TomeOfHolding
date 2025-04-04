using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CharacterController : ControllerBase {
		private readonly CharacterService _characterService;

		public CharacterController(CharacterService characterService) {
			_characterService = characterService;
		}
	}
}
