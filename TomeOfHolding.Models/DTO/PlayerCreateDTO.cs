namespace TomeOfHolding.Models.DTO {
	public class PlayerCreateDTO {
		public string Name { get; set; }
		public List<DayOfWeek> AvailableDays { get; set; } = new List<DayOfWeek>();
		public string Role { get; set; }
		public List<int> CampaignIDs { get; set; }
		public List<int> CharacterIDs { get; set; }
		public List<int> NoteIDs { get; set; }
	}
}
