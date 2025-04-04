namespace TomeOfHolding.DAL {
	public class CharacterRepo {
		private readonly TomeOfHoldingContext _context;

		public CharacterRepo(TomeOfHoldingContext context) {
			_context = context;
		}
	}
}
