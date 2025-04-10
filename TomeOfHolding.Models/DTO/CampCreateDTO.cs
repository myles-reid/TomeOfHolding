using System.ComponentModel.DataAnnotations;

namespace TomeOfHolding.Models.DTO {
    public class CampCreateDTO {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public int GM_ID { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public List<int> PlayerIds { get; set; }

        [Required]
        public List<int> CharacterIds { get; set; }
    }
}
