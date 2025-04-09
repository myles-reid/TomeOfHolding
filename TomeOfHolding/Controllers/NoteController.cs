using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;
using TomeOfHolding.Models;
using TomeOfHolding.Models.DTO;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class NoteController : ControllerBase {
		private readonly NoteService _noteService;
        private readonly SessionService _sessionService;
        private readonly PlayerService _playerService;

        public NoteController(NoteService noteService, SessionService sessionService, PlayerService playerService) {
			_noteService = noteService;
            _sessionService = sessionService;
            _playerService = playerService;
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

		[HttpPost]
		public async Task<IActionResult> CreateNote(NoteCreateDTO noteDTO) {
			if (noteDTO != null) {
				Session session = await _sessionService.GetSessionById(noteDTO.SessionId);
				if (session == null) {
					return NotFound("No session found with the provided ID.");
				}

				Player player = await _playerService.GetPlayerById(noteDTO.PlayerId);
				if (player == null) {
					return NotFound("No player found with the provided ID.");
				}

				Note note = new Note {
                    SessionId = noteDTO.SessionId,
                    PlayerId = noteDTO.PlayerId,
                    Session = session,
                    Player = player,
					Notes = noteDTO.Notes
                };

                await _noteService.CreateNote(note);
                return Ok("Note created successfully.");
            }
            return BadRequest("Invalid note data.");
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

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateNote(int id, Note note) {
			if (id != note.NoteId) {
				return BadRequest("Note ID mismatch.");
			}
			Note? existingNote = await _noteService.GetNoteById(id);
			if (existingNote == null) {
				return NotFound("Note not found.");
			}
			await _noteService.UpdateNote(note);
			return Ok("Note updated");
		}
	}
}
