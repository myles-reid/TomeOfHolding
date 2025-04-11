using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.Models;
using TomeOfHolding.Models.DTO;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CharacterController : ControllerBase {
		private readonly CharacterService _characterService;
		private readonly PlayerService _playerService;
		private readonly CampaignService _campaignService;
		private readonly CharacterSheetService _charSheetService;
		private readonly IMapper _mapper;
		public CharacterController(CharacterService characterService, PlayerService playerService, CampaignService campaignService, CharacterSheetService characterSheetService, IMapper mapper) {
			_characterService = characterService;
			_playerService = playerService;
			_campaignService = campaignService;
			_charSheetService = characterSheetService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetCharacters() {
			List<Character>? characters = await _characterService.GetCharacters();
			if (characters == null || characters.Count == 0) {
				return NotFound("No characters found.");
			}
			return Ok(characters);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCharacter(int id) {
			Character? character = await _characterService.GetCharacterById(id);
			if (character == null) {
				return NotFound("No character found.");
			}
			return Ok(character);
		}


		[HttpPost]
		public async Task<IActionResult> CreateCharacter([FromBody] CharacterCreateDTO characterDTO) {
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			Player player = await _playerService.GetPlayerById(characterDTO.PlayerId);
			if (player == null) {
				return NotFound("No player found with the provided ID.");
			}

			CharacterSheet characterSheet = await _charSheetService.GetCharacterSheet(characterDTO.CharacterSheetId);
			if (characterSheet == null) {
				return NotFound("No character sheet found with the provided ID.");
			}

			Character character = _mapper.Map<Character>(characterDTO);
			character.Player = player;
			character.CharacterSheet = characterSheet;

			await _characterService.CreateCharacter(character);
			return Ok("Character created successfully.");
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
