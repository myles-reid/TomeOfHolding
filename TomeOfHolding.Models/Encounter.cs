namespace TomeOfHolding.Models {
	public class Encounter {
		public int EncounterId { get; set; }
		public string Description { get; set; }
		public int Difficulty { get; set; }
		public string Type { get; set; }
		public string Reward { get; set; }
		public int SessionId { get; set; }
		public Session Session { get; set; }
	}
}
