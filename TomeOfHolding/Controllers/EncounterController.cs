using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.Models;
using TomeOfHolding.Models.DTO;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class EncounterController : ControllerBase {
		private readonly EncounterService _encounterService;
		private readonly SessionService _sessionService;

		public EncounterController(EncounterService encounterService, SessionService sessionService) {
			_encounterService = encounterService;
			_sessionService = sessionService;
		}

		[HttpGet]
		public async Task<IActionResult> GetEncounters() {
			// Will need to figure out how to process the NotFound response proplery
			List<Encounter>? encounters = await _encounterService.GetEncounters();
			if (encounters == null || encounters.Count == 0) {
				return NotFound("No encounters found.");
			}
			return Ok(encounters);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetEncountersBySession(int id) {
			// Will need to figure out how to process the NotFound response proplery
			List<Encounter>? encounters = await _encounterService.GetEncountersBySession(id);
			if (encounters == null || encounters.Count == 0) {
				return NotFound("No encounters found for this session.");
			}
			return Ok(encounters);
		}

		[HttpPost]
		public async Task<IActionResult> CreateEncounter(EncounterCreateDTO encounterDTO) {
			if (encounterDTO != null) {
				Session session = await _sessionService.GetSessionById(encounterDTO.SessionId);
				if (session == null) {
					return NotFound("No session found with the provided ID.");
				}

                Encounter encounter = new Encounter {
                    SessionId = encounterDTO.SessionId,
                    Session = session,
                    Description = encounterDTO.Description,
					Difficulty = encounterDTO.Difficulty,
					Type = encounterDTO.Type,
                    Reward = encounterDTO.Reward
                };

                await _encounterService.CreateEncounter(encounter);
                return Ok("Encounter created successfully.");
            }
            return BadRequest("Invalid encounter data.");
        }

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEncounter(int id) {
			Encounter encounter = await _encounterService.GetEncounterById(id);
			if (encounter == null) {
				return NotFound("Encounter not found.");
			}
			await _encounterService.DeleteEncounter(id);
			return Ok("Encounter deleted successfully.");
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateEncounter(int id, Encounter encounter) {
			if (id != encounter.EncounterId) {
				return BadRequest("Encounter ID mismatch.");
			}
			Encounter existingEncounter = await _encounterService.GetEncounterById(id);
			if (existingEncounter == null) {
				return NotFound("Encounter not found.");
			}
			await _encounterService.UpdateEncounter(encounter);
			return Ok("Encounter Updated");

		}
	}
}
