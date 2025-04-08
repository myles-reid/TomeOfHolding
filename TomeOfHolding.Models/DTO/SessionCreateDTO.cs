namespace TomeOfHolding.Models.DTO {
	public class SessionCreateDTO {
		public DateOnly Date { get; set; }
		public string? Summary { get; set; }
		public List<int>? EncounterIDs { get; set; }
		public List<int>? NoteIDs { get; set; }
		public int CampaignId { get; set; }
	}
}
