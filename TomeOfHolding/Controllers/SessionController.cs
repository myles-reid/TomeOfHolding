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
			List<Session>? sessions = await _sessionService.GetSessions();
			if (sessions == null || sessions.Count == 0) {
				return NotFound("No sessions found.");
			}
			return Ok(sessions);
		}

		[HttpPost]
		public async Task<IActionResult> CreateSession(Session session) {
			await _sessionService.CreateSession(session);
			return CreatedAtAction(nameof(GetSessions), new { id = session.SessionId }, session);
		}
	}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(int id) {
            Session? session = await _sessionService.GetSessionById(id);
            if (session == null) {
                return NotFound($"Session with ID {id} not found.");
            }
            await _sessionService.DeleteSession(id);
            return Ok("Session deleted successfully.");
        }
    }
}
