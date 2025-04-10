using System.ComponentModel.DataAnnotations;

namespace TomeOfHolding.Models {
    public class Character {
        public int CharacterId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Class { get; set; }

        [Required]
        [StringLength(30)]
        public string Role { get; set; }

        [Required]
        [Range(1, 20)]
        public int Level { get; set; }

        [Required]
        [StringLength(30)]
        public string Race { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public int PlayerId { get; set; }

        public Player Player { get; set; }

        [Required]
        public int CampaignId { get; set; }

        public Campaign Campaign { get; set; }

        [Required]
        public int CharacterSheetId { get; set; }

        public CharacterSheet CharacterSheet { get; set; }
    }
}
