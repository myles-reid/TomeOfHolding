using Microsoft.EntityFrameworkCore;
using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class TomeOfHoldingContext : DbContext {
		public TomeOfHoldingContext(DbContextOptions<TomeOfHoldingContext> options) : base(options) { }
		public DbSet<Campaign> Campaigns { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<Character> Characters { get; set; }
		public DbSet<CharacterSheet> CharacterSheets { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Campaign>().HasKey(c => c.CampaignId);
			modelBuilder.Entity<Player>().HasKey(p => p.PlayerId);
			modelBuilder.Entity<Character>().HasKey(c => c.CharacterId);
			modelBuilder.Entity<CharacterSheet>().HasKey(cs => cs.CharacterSheetID);


			modelBuilder.Entity<Campaign>()
				.HasMany(c => c.Players)
				.WithMany(p => p.Campaigns)
				.UsingEntity<Dictionary<object, object>>(
					"CampaignPlayer",
					j => j
						.HasOne<Player>()
						.WithMany()
						.HasForeignKey("PlayerId")
						.OnDelete(DeleteBehavior.Cascade),
					j => j
						.HasOne<Campaign>()
						.WithMany()
						.HasForeignKey("CampaignId")
						.OnDelete(DeleteBehavior.Cascade),
					j => {
						j.HasKey("CampaignId", "PlayerId");
						j.ToTable("CampaignPlayer");
					}
				);

			modelBuilder.Entity<Campaign>()
				.HasOne(c => c.GM)
				.WithMany()
				.HasForeignKey(c => c.GM_ID)
				.OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Player>()
                .HasMany(p => p.Characters)
                .WithOne(c => c.Player)
                .HasForeignKey(c => c.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Character>()
				.HasOne(c => c.Campaign)
				.WithMany(cp => cp.Characters)
				.HasForeignKey(c => c.CampaignId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Character>()
				.HasOne(c => c.CharacterSheet)
				.WithOne(cs => cs.Character)
				.HasForeignKey<CharacterSheet>(cs => cs.CharacterId)
				.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Character>()
                .HasOne(c => c.Player)
                .WithMany(p => p.Characters)
                .HasForeignKey(c => c.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
	}
}
