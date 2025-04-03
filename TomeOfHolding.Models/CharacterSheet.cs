namespace TomeOfHolding.Models {
	public class CharacterSheet {
		public int CharacterSheetID { get; set; }
		public int CharacterId { get; set; }
		public Character Character { get; set; }
		public int Charisma { get; set; }
		public int Dexterity { get; set; }
		public int Constitution { get; set; }
		public int Intelligence { get; set; }
		public int Strength { get; set; }
		public int Wisdom { get; set; }
		public int Currency { get; set; }
		public List<string> Spells { get; set; } = new List<string>();

	}
}
