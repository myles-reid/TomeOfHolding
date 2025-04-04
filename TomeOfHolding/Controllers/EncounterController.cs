using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.Models;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class EncounterController : ControllerBase {
		private readonly EncounterService _encounterService;

		public EncounterController(EncounterService encounterService) {
			_encounterService = encounterService;
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
		public async Task<IActionResult> CreateEncounter(Encounter encounter) {
			await _encounterService.CreateEncounter(encounter);
			return CreatedAtAction(nameof(GetEncounters), new { id = encounter.EncounterId }, encounter);
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
