using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.Models;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CharacterController : ControllerBase {
		private readonly CharacterService _characterService;

		public CharacterController(CharacterService characterService) {
			_characterService = characterService;
		}

		[HttpGet]
		public async Task<IActionResult> GetCharacters() {
			// Will need to figure out how to process the NotFound response properly
			List<Character>? characters = await _characterService.GetCharacters();
			if (characters == null || characters.Count == 0) {
				return NotFound("No characters found.");
			}
			return Ok(characters);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCharacter(int id) {
			// Will need to figure out how to process the NotFound response properly
			Character? character = await _characterService.GetCharacterById(id);
			if (character == null) {
				return NotFound("No character found.");
			}
			return Ok(character);
		}

		//Will need to add get by player

		[HttpPost]
		public async Task<IActionResult> CreateCharacter(Character character) {
			await _characterService.CreateCharacter(character);
			return CreatedAtAction(nameof(GetCharacter), new { id = character.CharacterId }, character);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCharacter(int id) {
			Character? character = await _characterService.GetCharacterById(id);
			if (character == null) {
				return NotFound("No character found.");
			}
			await _characterService.DeleteCharacter(id);
			return Ok("Character deleted successfully.");
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCharacter(int id, Character character) {
			if (id != character.CharacterId) {
				return BadRequest("Character ID mismatch.");
			}
			Character? existingCharacter = await _characterService.GetCharacterById(id);
			if (existingCharacter == null) {
				return NotFound("No character found.");
			}
			await _characterService.UpdateCharacter(character);
			return Ok("Character Updated");
		}
	}
}
