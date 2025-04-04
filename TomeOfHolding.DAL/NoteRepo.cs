using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class NoteRepo {
		private readonly TomeOfHoldingContext _context;

		public NoteRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public List<Note> GetNotes() {
			return _context.Notes.ToList();
		}

		public List<Note> GetNotesByPlayer(int playerId) {
			return _context.Notes.Where(n => n.PlayerId == playerId).ToList();
		}
	}
}
