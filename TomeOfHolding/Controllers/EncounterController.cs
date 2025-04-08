using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.BLL.Exceptions;
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
			try {
				List<Encounter>? encounters = await _encounterService.GetEncounters();
				return Ok(encounters);
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetEncountersBySession(int id) {
			try {
				List<Encounter>? encounters = await _encounterService.GetEncountersBySession(id);
				return Ok(encounters);
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateEncounter(Encounter encounter) {
			if (!ModelState.IsValid) return BadRequest("Invalid encounter data.");
			await _encounterService.CreateEncounter(encounter);
			return CreatedAtAction(nameof(GetEncounters), new { id = encounter.EncounterId }, encounter);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEncounter(int id) {
			try {
				await _encounterService.DeleteEncounter(id);
				return Ok("Encounter deleted successfully.");
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateEncounter(int id, Encounter encounter) {
			try {
				if (id != encounter.EncounterId) return BadRequest("Encounter ID mismatch.");
				await _encounterService.UpdateEncounter(encounter);
				return Ok("Encounter Updated");
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}
	}
}
