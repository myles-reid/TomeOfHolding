using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.BLL.Exceptions;
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
			try {
				List<Character>? characters = await _characterService.GetCharacters();
				return Ok(characters);
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCharacter(int id) {
			try {
				Character? character = await _characterService.GetCharacterById(id);
				return Ok(character);
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		//Will need to add get by player

		[HttpPost]
		public async Task<IActionResult> CreateCharacter(Character character) {
			if (!ModelState.IsValid) return BadRequest("Invalid character data.");
			await _characterService.CreateCharacter(character);
			return CreatedAtAction(nameof(GetCharacter), new { id = character.CharacterId }, character);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCharacter(int id) {
			try {
				Character? character = await _characterService.GetCharacterById(id);
				await _characterService.DeleteCharacter(id);
				return Ok("Character deleted successfully.");
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCharacter(int id, Character character) {
			try {
				if (id != character.CharacterId) {
					return BadRequest("Character ID mismatch.");
				}
				Character? existingCharacter = await _characterService.GetCharacterById(id);
				await _characterService.UpdateCharacter(character);
				return Ok("Character Updated");
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}
	}
}
