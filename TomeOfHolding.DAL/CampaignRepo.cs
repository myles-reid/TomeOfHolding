using Microsoft.EntityFrameworkCore;
using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class CampaignRepo {
		private readonly TomeOfHoldingContext _context;

		public CampaignRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public async Task<List<Campaign>> GetCampaigns() {
			return await _context.Campaigns.ToListAsync();
		}

		public async Task<Campaign> GetCampaignById(int id) {
			return await _context.Campaigns.FindAsync(id);
		}

		public async Task CreateCampaign(Campaign campaign) {
			_context.Campaigns.Add(campaign);
			await _context.SaveChangesAsync();
		}
	

		public async Task DeleteCampain(int id) {
            Campaign campaign = await _context.Campaigns.FindAsync(id);
            if (campaign != null) {
                _context.Campaigns.Remove(campaign);
                await _context.SaveChangesAsync();
            }
        }
    }
}
