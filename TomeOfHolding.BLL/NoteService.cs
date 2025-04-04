using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class NoteService {
		private readonly NoteRepo _noteRepo;

		public NoteService(NoteRepo noteRepo) {
			_noteRepo = noteRepo;
		}

		public List<Note> GetNotes() {
			return _noteRepo.GetNotes();
		}

		public List<Note> GetNotesByPlayer(int playerId) {
			return _noteRepo.GetNotesByPlayer(playerId);
		}
	}
}
