using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.Models;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class SessionController : ControllerBase {
		private readonly SessionService _sessionService;

		public SessionController(SessionService sessionService) {
			_sessionService = sessionService;
		}

		[HttpGet]
		public async Task<IActionResult> GetSessions() {
			// Will need to figure out how to process the NotFound response proplery
			List<Session> sessions = await _sessionService.GetSessions();
			if (sessions == null || sessions.Count == 0) {
				return NotFound("No sessions found.");
			}
			return Ok(sessions);
		}
	}
}
