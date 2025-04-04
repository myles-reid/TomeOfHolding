namespace TomeOfHolding.Models {
	public class Player {
		public int PlayerId { get; set; }
		public string Name { get; set; }
		public List<DayOfWeek> AvailableDays { get; set; } = new List<DayOfWeek>();
		public string Role { get; set; }
		public ICollection<Campaign> Campaigns { get; set; }
		public ICollection<Character> Characters { get; set; } = new List<Character>();
		public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
