namespace TomeOfHolding.DAL {
	public class PlayerRepo {
		private readonly TomeOfHoldingContext _context;

		public PlayerRepo(TomeOfHoldingContext context) {
			_context = context;
		}
	}
}
