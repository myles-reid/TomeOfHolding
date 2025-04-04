using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class NoteController : ControllerBase {
		private readonly NoteService _noteService;

		public NoteController(NoteService noteService) {
			_noteService = noteService;
		}
	}
}
