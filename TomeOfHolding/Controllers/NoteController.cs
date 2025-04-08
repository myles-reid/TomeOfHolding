using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.BLL.Exceptions;
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
			try {
				List<Note> notes = await _noteService.GetNotes();
				return Ok(notes);
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetNotesByPlayer(int id) {
			try {
				List<Note> notes = await _noteService.GetNotesByPlayer(id);
				return Ok(notes);
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateNote(Note note) {
			if (!ModelState.IsValid) return BadRequest("Invalid note data.");
			await _noteService.CreateNote(note);
			return CreatedAtAction(nameof(GetNotes), new { id = note.NoteId }, note);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteNote(int id) {
			try {
				await _noteService.DeleteNote(id);
				return NoContent();
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateNote(int id, Note note) {
			try {
				if (id != note.NoteId) return BadRequest("Note ID mismatch.");
				await _noteService.UpdateNote(note);
				return Ok("Note updated");
			} catch (NotFoundException e) {
				return NotFound(e.Message);
			}
		}
	}
}
