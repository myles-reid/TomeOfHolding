using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.Models;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class NoteController : ControllerBase {
		private readonly NoteService _noteService;

		public NoteController(NoteService noteService) {
			_noteService = noteService;
		}

		[HttpGet]
		public async Task<IActionResult> GetNotes() {
			// Will need to figure out how to process the NotFound response proplery
			List<Note>? notes = await _noteService.GetNotes();
			if (notes == null || notes.Count == 0) {
				return NotFound("No notes found.");
			}
			return Ok(notes);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetNotesByPlayer(int id) {
			// Will need to figure out how to process the NotFound response proplery
			List<Note>? notes = await _noteService.GetNotesByPlayer(id);
			if (notes == null || notes.Count == 0) {
				return NotFound("No notes found for this player.");
			}
			return Ok(notes);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteNote(int id) {
			Note? note = await _noteService.GetNoteById(id);
			if (note == null) {
				return NotFound("Note not found.");
			}
			await _noteService.DeleteNote(id);
			return Ok("Note deleted successfully.");
		}
	}
}
