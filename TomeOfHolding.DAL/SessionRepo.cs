namespace TomeOfHolding.DAL {
	public class SessionRepo {
		private readonly TomeOfHoldingContext _context;

		public SessionRepo(TomeOfHoldingContext context) {
			_context = context;
		}
	}
}
