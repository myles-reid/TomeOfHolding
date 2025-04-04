using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CharacterSheetController : ControllerBase {
		private readonly CharacterSheetService _characterSheetService;

		public CharacterSheetController(CharacterSheetService characterSheetService) {
			_characterSheetService = characterSheetService;
		}
	}
}
