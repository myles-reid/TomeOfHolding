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

			// Seed Players
			modelBuilder.Entity<Player>().HasData(
				new Player { PlayerId = 1, Name = "Alice", Role = "Player", AvailableDays = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Wednesday } },
				new Player { PlayerId = 2, Name = "Bob", Role = "Player", AvailableDays = new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Thursday } },
				new Player { PlayerId = 3, Name = "Charlie", Role = "GM", AvailableDays = new List<DayOfWeek> { DayOfWeek.Friday } },
				new Player { PlayerId = 4, Name = "Diana", Role = "GM", AvailableDays = new List<DayOfWeek> { DayOfWeek.Saturday } }
			);

			// Seed Campaigns
			modelBuilder.Entity<Campaign>().HasData(
				new Campaign { CampaignId = 1, Title = "Dragon's Quest", Description = "A thrilling adventure to slay a dragon.", GM_ID = 3 },
				new Campaign { CampaignId = 2, Title = "Mystic Realms", Description = "Explore the magical realms and uncover secrets.", GM_ID = 4 }
			);

			// Seed Characters
			modelBuilder.Entity<Character>().HasData(
				new Character { CharacterId = 1, Name = "Thorin", Class = "Warrior", Role = "Tank", Level = 10, Race = "Dwarf", Description = "A brave dwarf warrior.", PlayerId = 1, CampaignId = 1, CharacterSheetId = 1 },
				new Character { CharacterId = 2, Name = "Elandra", Class = "Mage", Role = "DPS", Level = 12, Race = "Elf", Description = "A skilled elven mage.", PlayerId = 2, CampaignId = 1, CharacterSheetId = 2 },
				new Character { CharacterId = 3, Name = "Gorath", Class = "Rogue", Role = "DPS", Level = 8, Race = "Human", Description = "A cunning human rogue.", PlayerId = 1, CampaignId = 2, CharacterSheetId = 3 },
				new Character { CharacterId = 4, Name = "Lyra", Class = "Cleric", Role = "Healer", Level = 9, Race = "Halfling", Description = "A devoted halfling cleric.", PlayerId = 2, CampaignId = 2, CharacterSheetId = 4 }
			);

			// Seed CharacterSheets
			modelBuilder.Entity<CharacterSheet>().HasData(
				new CharacterSheet { CharacterSheetID = 1, CharacterId = 1, Charisma = 10, Dexterity = 12, Constitution = 15, Intelligence = 8, Strength = 18, Wisdom = 10, Currency = 100, Spells = new List<string> { "Shield Bash", "Battle Cry" } },
				new CharacterSheet { CharacterSheetID = 2, CharacterId = 2, Charisma = 14, Dexterity = 10, Constitution = 8, Intelligence = 18, Strength = 8, Wisdom = 12, Currency = 200, Spells = new List<string> { "Fireball", "Teleport" } },
				new CharacterSheet { CharacterSheetID = 3, CharacterId = 3, Charisma = 12, Dexterity = 18, Constitution = 10, Intelligence = 14, Strength = 10, Wisdom = 8, Currency = 150, Spells = new List<string> { "Backstab", "Shadow Step" } },
				new CharacterSheet { CharacterSheetID = 4, CharacterId = 4, Charisma = 16, Dexterity = 10, Constitution = 12, Intelligence = 10, Strength = 8, Wisdom = 18, Currency = 120, Spells = new List<string> { "Heal", "Bless" } }
			);

			//// Seed CampaignPlayer relationships
			//modelBuilder.Entity<CampaignPlayer>().HasData(
			//	new { CampaignId = 1, PlayerId = 1 },
			//	new { CampaignId = 1, PlayerId = 2 },
			//	new { CampaignId = 2, PlayerId = 1 },
			//	new { CampaignId = 2, PlayerId = 2 }
			//);
		}
	}
}
