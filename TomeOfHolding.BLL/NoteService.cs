using TomeOfHolding.BLL.Exceptions;
using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class NoteService {
		private readonly NoteRepo _noteRepo;

		public NoteService(NoteRepo noteRepo) {
			_noteRepo = noteRepo;
		}

		public async Task<List<Note>> GetNotes() {
			List<Note>? notes = await _noteRepo.GetNotes();
			if (notes == null || notes.Count == 0) {
				throw new NotFoundException("No notes found.");
			} else {
				return notes;
			}
		}

		public async Task<Note> GetNoteById(int id) {
			Note? note = await _noteRepo.GetNoteById(id);
			return note ?? throw new NotFoundException("No note with that ID found.");
		}

		public async Task<List<Note>> GetNotesByPlayer(int playerId) {
			List<Note>? notes = await _noteRepo.GetNotesByPlayer(playerId);
			if (notes == null || notes.Count == 0) {
				throw new NotFoundException("No notes found for that player.");
			} else {
				return notes;
			}
		}

		public async Task CreateNote(Note note) {
			// Add validation here, currently unsure how
			await _noteRepo.CreateNote(note);
		}


		public async Task DeleteNote(int noteId) {
			Note note = await _noteRepo.GetNoteById(noteId) ??
				throw new NotFoundException("No note with that ID found.");
			await _noteRepo.DeleteNote(noteId);
		}

		public async Task UpdateNote(Note note) {
			Note? existingNote = await _noteRepo.GetNoteById(note.NoteId) ??
				throw new NotFoundException("No note with that ID found.");
			await _noteRepo.UpdateNote(note);
		}
	}
}
