using TomeOfHolding.BLL.Exceptions;
using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class CampaignService {
		private readonly CampaignRepo _campaignRepo;

		public CampaignService(CampaignRepo campaignRepo) {
			_campaignRepo = campaignRepo;
		}

		public async Task<List<Campaign>> GetCampaigns() {
			List<Campaign>? campaigns = await _campaignRepo.GetCampaigns();
			if (campaigns == null || campaigns.Count == 0) {
				throw new NotFoundException("No campaigns found.");
			} else {
				return campaigns;
			}

		}

		public async Task<Campaign> GetCampaignById(int id) {
			Campaign campaign = await _campaignRepo.GetCampaignById(id);
			return campaign ?? throw new NotFoundException("No campaign with that ID found.");
		}

		public async Task CreateCampaign(Campaign campaign) {
			//add validation here, currently unsure how
			await _campaignRepo.CreateCampaign(campaign);
		}

		public async Task DeleteCampaign(int id) {
			Campaign? campaign = await _campaignRepo.GetCampaignById(id);
			if (campaign == null) throw new NotFoundException("No campaign with that ID found."); 
			await _campaignRepo.DeleteCampain(id);
		}

		public async Task UpdateCampaign(Campaign campaign) {
			Campaign? existingCampaign = await _campaignRepo.GetCampaignById(campaign.CampaignId);
			if (existingCampaign == null) { throw new NotFoundException("No campaign with that ID found."); }
			await _campaignRepo.UpdateCampain(campaign);
		}
	}
}
