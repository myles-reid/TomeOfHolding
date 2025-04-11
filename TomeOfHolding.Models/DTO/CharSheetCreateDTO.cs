using System.ComponentModel.DataAnnotations;

namespace TomeOfHolding.Models.DTO {
    public class CharSheetCreateDTO {
        [Range(1, 30)]
        public int Strength { get; set; }

        [Range(1, 30)]
        public int Dexterity { get; set; }

        [Range(1, 30)]
        public int Constitution { get; set; }

        [Range(1, 30)]
        public int Intelligence { get; set; }

        [Range(1, 30)]
        public int Wisdom { get; set; }

        [Range(1, 30)]
        public int Charisma { get; set; }

        [Range(0, int.MaxValue)]
        public int Currency { get; set; }

        public List<string>? Spells { get; set; }
    }
}
