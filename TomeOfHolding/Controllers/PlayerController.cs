using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.Models;
using TomeOfHolding.Models.DTO;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class PlayerController : ControllerBase {
		private readonly PlayerService _playerService;
		private readonly CampaignService _campaignService;
		private readonly CharacterService _characterService;
		private readonly IMapper _mapper;

		public PlayerController(PlayerService playerService, CampaignService campaignService, CharacterService characterService, IMapper mapper) {
			_playerService = playerService;
			_campaignService = campaignService;
			_characterService = characterService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetPlayers() {
			List<Player>? players = await _playerService.GetPlayers();
			if (players == null || players.Count == 0) {
				return NotFound("No players found.");
			}
			return Ok(players);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetPlayerById(int id) {
			Player? player = await _playerService.GetPlayerById(id);
			if (player == null) {
				return NotFound($"Player with ID {id} not found.");
			}
			return Ok(player);
		}

		[HttpPost]
		public async Task<IActionResult> CreatePlayer([FromBody] PlayerCreateDTO playerDTO) {
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			List<Campaign> campaigns = await _campaignService.GetCampaignById(playerDTO.CampaignIDs);

			List<Character> characters = await _characterService.GetCharacterById(playerDTO.CharacterIDs);

			Player player = _mapper.Map<Player>(playerDTO);
			player.Campaigns = campaigns;
			player.Characters = characters;

			await _playerService.CreatePlayer(player);
			return Ok("Player created successfully.");
		}



		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePlayer(int id) {
			Player? player = await _playerService.GetPlayerById(id);
			if (player == null) {
				return NotFound($"Player with ID {id} not found.");
			}
			await _playerService.DeletePlayer(id);
			return Ok("Player deleted successfully.");
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdatePlayer(int id, Player player) {
			if (id != player.PlayerId) {
				return BadRequest("Player ID mismatch.");
			}
			Player? existingPlayer = await _playerService.GetPlayerById(id);
			if (existingPlayer == null) {
				return NotFound($"Player with ID {id} not found.");
			}
			await _playerService.UpdatePlayer(player);
			return Ok("Player updated");
		}
	}
}
