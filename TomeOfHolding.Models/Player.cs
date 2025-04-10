using System.ComponentModel.DataAnnotations;

namespace TomeOfHolding.Models {
    public class Player {
        public int PlayerId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public List<DayOfWeek> AvailableDays { get; set; } = new List<DayOfWeek>();

        [Required]
        [StringLength(30)]
        public string Role { get; set; }

        public ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>();
        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}
