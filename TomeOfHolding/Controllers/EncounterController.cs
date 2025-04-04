using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class EncounterController : ControllerBase {
		private readonly EncounterService _encounterService;

		public EncounterController(EncounterService encounterService) {
			_encounterService = encounterService;
		}
	}
}
