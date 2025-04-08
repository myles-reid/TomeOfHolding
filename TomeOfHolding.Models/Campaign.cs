namespace TomeOfHolding.Models {
	public class Campaign {
		public int CampaignId { get; set; }
		public ICollection<Player> Players { get; set; } = new List<Player>();
		public int GM_ID { get; set; }
		public Player GM { get; set; }
		public string Title { get; set; }
		public ICollection<Session> Sessions { get; set; } = new List<Session>();
		public string Description { get; set; }
		public ICollection<Character> Characters { get; set; } = new List<Character>();
	}
}
