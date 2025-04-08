using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.BLL.Exceptions;
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
			// This seems to work okay? I havent tried with campaigns available in the database yet
			try {
				List<Campaign>? campaigns = await _campaignService.GetCampaigns();
				return Ok(campaigns);
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCampaignById(int id) {
			try {
				Campaign? campaign = await _campaignService.GetCampaignById(id);
				return Ok(campaign);
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateCampaign(Campaign campaign) {
			if (!ModelState.IsValid) return BadRequest("Invalid campaign data.");
			await _campaignService.CreateCampaign(campaign);
			return CreatedAtAction(nameof(GetCampaignById), new { id = campaign.CampaignId }, campaign);
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCampaign(int id) {
			try {
				await _campaignService.DeleteCampaign(id);
				return NoContent();
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCampaign(int id, Campaign campaign) {
			try {
				if (id != campaign.CampaignId) return BadRequest("Campaign ID mismatch.");
				await _campaignService.UpdateCampaign(campaign);
				return Ok("Campaign Updated");
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}
	}
}
