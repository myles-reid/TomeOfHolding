using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class NoteService {
		private readonly NoteRepo _noteRepo;

		public NoteService(NoteRepo noteRepo) {
			_noteRepo = noteRepo;
		}

		public async Task<List<Note>> GetNotes() {
			return await _noteRepo.GetNotes();
		}

		public async Task<List<Note>> GetNotesByPlayer(int playerId) {
			return await _noteRepo.GetNotesByPlayer(playerId);
		}
	}
}
