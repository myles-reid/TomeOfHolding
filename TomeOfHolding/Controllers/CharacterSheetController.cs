using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.BLL.Exceptions;
using TomeOfHolding.Models;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CharacterSheetController : ControllerBase {
		private readonly CharacterSheetService _characterSheetService;

		public CharacterSheetController(CharacterSheetService characterSheetService) {
			_characterSheetService = characterSheetService;
		}

		// Do we want to have a "Get All" here? Maybe for the GM only? IDK how we would implement that
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCharacterSheet(int id) {
			try {
				CharacterSheet? characterSheet = await _characterSheetService.GetCharacterSheet(id);
				return Ok(characterSheet);
			} catch (NotFoundException) {
				return NotFound("No character Sheet found with that Character");
			}

		}

		[HttpPost]
		public async Task<IActionResult> CreateCharacterSheet(CharacterSheet sheet) {
			if (!ModelState.IsValid) return BadRequest("Invalid Character Sheet");
			await _characterSheetService.CreateCharacterSheet(sheet);
			return CreatedAtAction(nameof(GetCharacterSheet), new { id = sheet.CharacterId }, sheet);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCharacterSheet(int id) {
			try {
				await _characterSheetService.DeleteCharacterSheet(id);
				return NoContent();
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}

		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCharacterSheet(int id, CharacterSheet sheet) {
			try {
				if (id != sheet.CharacterId) return BadRequest("CharacterID mismatch.");
				await _characterSheetService.UpdateCharacterSheet(sheet);
				return Ok("CharacterSheet updated");
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}
	}
}
