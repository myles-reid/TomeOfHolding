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

		public async Task<Note> GetNoteById(int id) {
            return await _noteRepo.GetNoteById(id);
        }

        public async Task<List<Note>> GetNotesByPlayer(int playerId) {
			return await _noteRepo.GetNotesByPlayer(playerId);
		}

		public async Task DeleteNote(int noteId) {
            await _noteRepo.DeleteNote(noteId);
        }
    }
}
