using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.Models;
using TomeOfHolding.Models.DTO;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class SessionController : ControllerBase {
		private readonly SessionService _sessionService;
        private readonly EncounterService _encounterService;
        private readonly NoteService _noteService;
		private readonly CampaignService _campaignService;

        public SessionController(SessionService sessionService, EncounterService encounterService, NoteService noteService, CampaignService campaignService) {
			_sessionService = sessionService;
			_encounterService = encounterService;
			_noteService = noteService;
            _campaignService = campaignService;
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
        public async Task<IActionResult> CreateSession(SessionCreateDTO sessionDTO) {
            if (sessionDTO != null) {
                List<Note> Notes = await _noteService.GetNoteById(sessionDTO.NoteIDs);
                List<Encounter> Encounters = await _encounterService.GetEncountersById(sessionDTO.EncounterIDs);
                Campaign campaign = await _campaignService.GetCampaignById(sessionDTO.CampaignId);

                Session session = new Session {
                    Date = sessionDTO.Date,
                    Summary = sessionDTO.Summary,
                    CampaignId = sessionDTO.CampaignId,
                    Campaign = campaign,
                    Notes = Notes,
                    Encounters = Encounters
                };

                await _sessionService.CreateSession(session);
                return Ok("Session created successfully.");
            }
            return BadRequest("Invalid session data.");
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

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateSession(int id, Session session) {
			if (id != session.SessionId) {
				return BadRequest("Session ID mismatch.");
			}
			Session? existingSession = await _sessionService.GetSessionById(id);
			if (existingSession == null) {
				return NotFound($"Session with ID {id} not found.");
			}
			await _sessionService.UpdateSession(session);
			return Ok("Session updated");
		}
	}
}
