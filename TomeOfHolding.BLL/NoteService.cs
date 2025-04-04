using TomeOfHolding.DAL;

namespace TomeOfHolding.BLL {
	public class NoteService {
		private readonly NoteRepo _noteRepo;

		public NoteService(NoteRepo noteRepo) {
			_noteRepo = noteRepo;
		}
	}
}
