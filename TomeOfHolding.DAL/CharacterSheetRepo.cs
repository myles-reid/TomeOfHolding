namespace TomeOfHolding.DAL {
	public class CharacterSheetRepo {
		private readonly TomeOfHoldingContext _context;

		public CharacterSheetRepo(TomeOfHoldingContext context) {
			_context = context;
		}
	}
}
