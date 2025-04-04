using Microsoft.EntityFrameworkCore;
using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {

	public class TomeOfHoldingContext : DbContext {
		public DbSet<Campaign> Campaigns { get; set; }
		public DbSet<Session> Sessions { get; set; }
		public DbSet<Character> Characters { get; set; }
		public DbSet<CharacterSheet> CharacterSheets { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<Note> Notes { get; set; }
		public DbSet<Encounter> Encounters { get; set; }

		public TomeOfHoldingContext(DbContextOptions<TomeOfHoldingContext> options) : base(options) {
		}
	}
}
