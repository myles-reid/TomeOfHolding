namespace TomeOfHolding.Models.DTO {
	public class CampCreateDTO {
		public string Title { get; set; }
		public int GM_ID { get; set; }
		public string Description { get; set; }
		public List<int> SessionIds { get; set; }
		public List<int> PlayerIds { get; set; }
		public List<int> CharacterIds { get; set; }

	}
}
