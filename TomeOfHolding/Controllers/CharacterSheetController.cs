using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
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
			// Will need to figure out how to process the NotFound response properly
			CharacterSheet? characterSheet = await _characterSheetService.GetCharacterSheet(id);
			if (characterSheet == null) {
				return NotFound("No character sheet found.");
			}
			return Ok(characterSheet);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCharacterSheet(CharacterSheet sheet) {
			await _characterSheetService.CreateCharacterSheet(sheet);
			return CreatedAtAction(nameof(GetCharacterSheet), new { id = sheet.CharacterId }, sheet);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCharacterSheet(int id) {
			CharacterSheet? characterSheet = await _characterSheetService.GetCharacterSheet(id);
			if (characterSheet == null) {
				return NotFound("No character sheet found.");
			}
			await _characterSheetService.DeleteCharacterSheet(id);
			return Ok("CharacterSheet deleted successfully.");
		}
	}
}
