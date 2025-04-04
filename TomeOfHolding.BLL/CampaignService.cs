using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class CampaignService {
		private readonly CampaignRepo _campaignRepo;

		public CampaignService(CampaignRepo campaignRepo) {
			_campaignRepo = campaignRepo;
		}

		public List<Campaign> GetCampaigns() {
			return _campaignRepo.GetCampaigns();
		}
	}
}
