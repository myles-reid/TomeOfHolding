namespace TomeOfHolding.Models {
	public class Note {
		public int NoteId { get; set; }
		public int SessionId { get; set; }
		public Session Session { get; set; }
		public int PlayerId { get; set; }
		public Player Player { get; set; }
		public string Notes { get; set; }
	}
}
