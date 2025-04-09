using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class CampaignService {
		private readonly CampaignRepo _campaignRepo;

		public CampaignService(CampaignRepo campaignRepo) {
			_campaignRepo = campaignRepo;
		}

		public async Task<List<Campaign>> GetCampaigns() {
			return await _campaignRepo.GetCampaigns();
		}

		public async Task<Campaign> GetCampaignById(int id) {
			return await _campaignRepo.GetCampaignById(id);
		}

        public async Task<List<Campaign>> GetCampaignById(List<int> ids) {
            return await _campaignRepo.GetCampaignById(ids);
        }

        public async Task CreateCampaign(Campaign campaign) {
            await _campaignRepo.CreateCampaign(campaign);
        }

        public async Task DeleteCampaign(int id) {
			await _campaignRepo.DeleteCampain(id);
		}

		public async Task UpdateCampaign(Campaign campaign) {
			await _campaignRepo.UpdateCampain(campaign);
		}
	}
}
