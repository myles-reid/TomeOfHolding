namespace TomeOfHolding.DAL {
	public class CampaignRepo {
		private readonly TomeOfHoldingContext _context;

		public CampaignRepo(TomeOfHoldingContext context) {
			_context = context;
		}
	}
}
