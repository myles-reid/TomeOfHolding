namespace TomeOfHolding.DAL {
	public class NoteRepo {
		private readonly TomeOfHoldingContext _context;

		public NoteRepo(TomeOfHoldingContext context) {
			_context = context;
		}
	}
}
