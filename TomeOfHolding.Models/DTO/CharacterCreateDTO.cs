using System.ComponentModel.DataAnnotations;

namespace TomeOfHolding.Models.DTO {
    public class CharacterCreateDTO {
        [Required]
        public int CharacterSheetId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        public int CampaignId { get; set; }

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

        [StringLength(300)]
        public string? Description { get; set; }
    }
}
