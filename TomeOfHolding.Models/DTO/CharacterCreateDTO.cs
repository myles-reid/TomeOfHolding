namespace TomeOfHolding.Models.DTO {
	public class CharacterCreateDTO {
		public string Name { get; set; }
		public string Class { get; set; }
		public string Role { get; set; }
		public int Level { get; set; }
		public string Race { get; set; }
		public string Description { get; set; }
		public int PlayerId { get; set; }
		public int CampaignId { get; set; }
		public int CharacterSheetId { get; set; }

	}
}
