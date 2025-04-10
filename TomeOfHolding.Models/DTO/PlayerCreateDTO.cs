using System.ComponentModel.DataAnnotations;

namespace TomeOfHolding.Models.DTO {
    public class PlayerCreateDTO {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public List<DayOfWeek> AvailableDays { get; set; } = new List<DayOfWeek>();

        [Required]
        [StringLength(30)]
        public string Role { get; set; }

        [Required]
        public List<int> CampaignIDs { get; set; }

        [Required]
        public List<int> CharacterIDs { get; set; }
    }
}
