namespace TomeOfHolding.DAL {
	public class EncounterRepo {
		private readonly TomeOfHoldingContext _context;

		public EncounterRepo(TomeOfHoldingContext context) {
			_context = context;
		}
	}
}
