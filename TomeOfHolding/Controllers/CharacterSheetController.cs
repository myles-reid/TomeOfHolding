using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.Models;
using TomeOfHolding.Models.DTO;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CharacterSheetController : ControllerBase {
		private readonly CharacterSheetService _characterSheetService;
		private readonly CharacterService _characterService;

        public CharacterSheetController(CharacterSheetService characterSheetService, CharacterService characterService) {
			_characterSheetService = characterSheetService;
            _characterService = characterService;
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
		public async Task<IActionResult> CreateCharacterSheet(CharSheetCreateDTO sheetDTO) {
            if (sheetDTO != null) {
				Character character = await _characterService.GetCharacterById(sheetDTO.CharacterId);
				if (character == null) {
					return NotFound("No character found with the provided ID.");
				}

                CharacterSheet characterSheet = new CharacterSheet {
					CharacterId = sheetDTO.CharacterId,
					Character = character,
					Charisma = sheetDTO.Charisma,
					Dexterity = sheetDTO.Dexterity,
					Constitution = sheetDTO.Constitution,
					Intelligence = sheetDTO.Intelligence,
					Strength = sheetDTO.Strength,
					Wisdom = sheetDTO.Wisdom,
					Currency = sheetDTO.Currency,
					Spells = sheetDTO.Spells
                };
                await _characterSheetService.CreateCharacterSheet(characterSheet);
                return Ok("CharacterSheet created successfully.");
            }
            return BadRequest("Invalid character sheet data.");
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

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCharacterSheet(int id, CharacterSheet sheet) {
			if (id != sheet.CharacterId) {
				return BadRequest("CharacterSheet ID mismatch.");
			}
			CharacterSheet? existingCharacterSheet = await _characterSheetService.GetCharacterSheet(id);
			if (existingCharacterSheet == null) {
				return NotFound("No character sheet found.");
			}
			await _characterSheetService.UpdateCharacterSheet(sheet);
			return Ok("CharacterSheet updated");
		}
	}
}
