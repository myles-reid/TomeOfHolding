using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.Models;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CampaignController : ControllerBase {
		private readonly CampaignService _campaignService;

		public CampaignController(CampaignService campaignService) {
			_campaignService = campaignService;
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
		public async Task<IActionResult> CreateCampaign(Campaign campaign) {
			await _campaignService.CreateCampaign(campaign);
			return CreatedAtAction(nameof(GetCampaignById), new { id = campaign.CampaignId }, campaign);
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
