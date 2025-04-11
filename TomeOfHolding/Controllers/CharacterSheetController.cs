using AutoMapper;
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
		private readonly IMapper _mapper;

		public CharacterSheetController(CharacterSheetService characterSheetService, CharacterService characterService, IMapper mapper) {
			_characterSheetService = characterSheetService;
			_characterService = characterService;
			_mapper = mapper;
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> GetCharacterSheet(int id) {
			CharacterSheet? characterSheet = await _characterSheetService.GetCharacterSheet(id);
			if (characterSheet == null) {
				return NotFound("No character sheet found.");
			}
			return Ok(characterSheet);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCharacterSheet([FromBody] CharSheetCreateDTO sheetDTO) {
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}
			CharacterSheet characterSheet = _mapper.Map<CharacterSheet>(sheetDTO);
			await _characterSheetService.CreateCharacterSheet(characterSheet);
			return Ok("CharacterSheet created successfully.");
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
			CharacterSheet? existingCharacterSheet = await _characterSheetService.GetCharacterSheet(id);
			if (existingCharacterSheet == null) {
				return NotFound("No character sheet found.");
			}
			await _characterSheetService.UpdateCharacterSheet(sheet);
			return Ok("CharacterSheet updated");
		}
	}
}
