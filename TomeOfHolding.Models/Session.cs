namespace TomeOfHolding.Models {
	public class Session {
		public int SessionId { get; set; }
		public DateOnly Date { get; set; }
		public string Summary { get; set; }
		public ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();
		public ICollection<Note> Notes { get; set; } = new List<Note>();
		public int CampaignId { get; set; }
		public Campaign Campaign { get; set; } = new Campaign();

	}
}
