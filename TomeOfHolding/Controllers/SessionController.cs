using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.BLL.Exceptions;
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
			try {
				List<Session> sessions = await _sessionService.GetSessions();
				return Ok(sessions);
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateSession(Session session) {
			if (!ModelState.IsValid) return BadRequest("Invalid session data.");
			await _sessionService.CreateSession(session);
			return CreatedAtAction(nameof(GetSessions), new { id = session.SessionId }, session);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSession(int id) {
			try {
				await _sessionService.DeleteSession(id);
				return NoContent();
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateSession(int id, Session session) {
			try {
				if (id != session.SessionId) return BadRequest("Session ID mismatch.");
				await _sessionService.UpdateSession(session);
				return Ok("Session updated");
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}
	}
}
