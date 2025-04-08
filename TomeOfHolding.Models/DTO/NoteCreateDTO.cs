namespace TomeOfHolding.Models.DTO {
	public class NoteCreateDTO {
		public int SessionId { get; set; }
		public int PlayerId { get; set; }
		public string Notes { get; set; }
	}
}
