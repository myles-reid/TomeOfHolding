using Microsoft.EntityFrameworkCore;
using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class NoteRepo {
		private readonly TomeOfHoldingContext _context;

		public NoteRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public async Task<List<Note>> GetNotes() {
			return await _context.Notes.ToListAsync();
		}

		public async Task<Note> GetNoteById(int id) {
			return await _context.Notes.FindAsync(id);
		}

        public async Task<List<Note>> GetNoteById(List<int> ids) {
            return await _context.Notes.Where(n => ids.Contains(n.NoteId)).ToListAsync();
        }

        public async Task<List<Note>> GetNotesByPlayer(int playerId) {
			return await _context.Notes.Where(n => n.PlayerId == playerId).ToListAsync();
		}

		public async Task CreateNote(Note note) {
			_context.Notes.Add(note);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteNote(int noteId) {
			Note note = await _context.Notes.FindAsync(noteId);
			if (note != null) {
				_context.Notes.Remove(note);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateNote(Note note) {
			_context.Notes.Update(note);
			await _context.SaveChangesAsync();
		}
	}
}
