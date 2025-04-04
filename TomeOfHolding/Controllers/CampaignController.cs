using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CampaignController : ControllerBase {
		private readonly CampaignService _campaignService;

		public CampaignController(CampaignService campaignService) {
			_campaignService = campaignService;
		}
	}
}
