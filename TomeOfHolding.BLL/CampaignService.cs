using TomeOfHolding.DAL;

namespace TomeOfHolding.BLL {
	public class CampaignService {
		private readonly CampaignRepo _campaignRepo;

		public CampaignService(CampaignRepo campaignRepo) {
			_campaignRepo = campaignRepo;
		}
	}
}
