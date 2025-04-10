using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.Models;
using TomeOfHolding.Models.DTO;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CampaignController : ControllerBase {
		private readonly CampaignService _campaignService;
        private readonly PlayerService _playerService;
        private readonly CharacterService _characterService;

        public CampaignController(CampaignService campaignService, PlayerService playerService, CharacterService characterService) {
            _campaignService = campaignService;
            _playerService = playerService;
            _characterService = characterService;
        }

        [HttpGet]
		public async Task<IActionResult> GetCampaigns() {
			// Will need to figure out how to process the NotFound response properly
			List<Campaign>? campaigns = await _campaignService.GetCampaigns();
			if (campaigns == null || campaigns.Count == 0) {
				return NotFound("No campaigns found.");
			}
			return Ok(campaigns);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCampaignById(int id) {
			// Will need to figure out how to process the NotFound response properly
			Campaign? campaign = await _campaignService.GetCampaignById(id);
			if (campaign == null) {
				return NotFound("No campaign with that ID found.");
			}
			return Ok(campaign);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCampaign(CampCreateDTO campaignDTO) {
			if (campaignDTO != null) {
                List<Player> players = new List<Player>();
                players = await _playerService.GetPlayerbyId(campaignDTO.PlayerIds);

                List<Character> characters = new List<Character>();
                characters = await _characterService.GetCharacterById(campaignDTO.PlayerIds);

                if (players == null || players.Count == 0) {
                    return NotFound("No players found with the provided IDs.");
                }

                if (characters == null || characters.Count == 0) {
                    return NotFound("No characters found with the provided IDs.");
                }

                Campaign campaign = new Campaign {
                    Title = campaignDTO.Title,
                    Players = players,
                    GM_ID = campaignDTO.GM_ID,
                    GM = players.FirstOrDefault(p => p.PlayerId == campaignDTO.GM_ID),
                    Description = campaignDTO.Description,
                    Characters = characters
                };

                await _campaignService.CreateCampaign(campaign);
                return Ok("Campaign created successfully.");
            }
            return BadRequest("Invalid campaign data.");
        }


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCampaign(int id) {
			Campaign? campaign = await _campaignService.GetCampaignById(id);
			if (campaign == null) {
				return NotFound("No campaign with that ID found.");
			}
			await _campaignService.DeleteCampaign(id);
			return Ok("Campaign deleted successfully.");
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCampaign(int id, Campaign campaign) {
			if (id != campaign.CampaignId) {
				return BadRequest("Campaign ID mismatch.");
			}
			Campaign? existingCampaign = await _campaignService.GetCampaignById(id);
			if (existingCampaign == null) {
				return NotFound("No campaign with that ID found.");
			}
			await _campaignService.UpdateCampaign(campaign);
			return Ok("Campaign Updated");
		}
	}
}
