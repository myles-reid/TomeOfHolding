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

        public PlayerController(PlayerService playerService, CampaignService campaignService, CharacterService characterService) {
            _playerService = playerService;
            _campaignService = campaignService;
            _characterService = characterService;
        }

        [HttpGet]
		public async Task<IActionResult> GetPlayers() {
			// Will need to figure out how to process the NotFound response proplery
			List<Player>? players = await _playerService.GetPlayers();
			if (players == null || players.Count == 0) {
				return NotFound("No players found.");
			}
			return Ok(players);
		}

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] PlayerCreateDTO playerDTO) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            List<Campaign> campaigns = await _campaignService.GetCampaignById(playerDTO.CampaignIDs);

            List<Character> characters = await _characterService.GetCharacterById(playerDTO.CharacterIDs);

            Player player = new Player {
                Name = playerDTO.Name,
                AvailableDays = playerDTO.AvailableDays,
                Role = playerDTO.Role,
                Campaigns = campaigns,
                Characters = characters
            };

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
