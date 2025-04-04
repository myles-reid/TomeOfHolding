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

		public async Task<List<Note>> GetNotesByPlayer(int playerId) {
			return await _context.Notes.Where(n => n.PlayerId == playerId).ToListAsync();
		}
	}
}
