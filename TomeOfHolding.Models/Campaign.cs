using System.ComponentModel.DataAnnotations;

namespace TomeOfHolding.Models {
    public class Campaign {
        public int CampaignId { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();

        [Required]
        public int GM_ID { get; set; }

        public Player GM { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}
