namespace TomeOfHolding.Models.DTO {
	public class EncounterCreateDTO {
		public string Description { get; set; }
		public int Difficulty { get; set; }
		public string Type { get; set; }
		public string Reward { get; set; }
		public int SessionId { get; set; }
	}
}
