using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class CampaignRepo {
		private readonly TomeOfHoldingContext _context;

		public CampaignRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public List<Campaign> GetCampaigns() {
			return _context.Campaigns.ToList();
		}
	}
}
