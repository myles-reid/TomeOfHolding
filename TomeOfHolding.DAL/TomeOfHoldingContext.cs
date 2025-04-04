using Microsoft.EntityFrameworkCore;
using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
    public class TomeOfHoldingContext : DbContext {
        public TomeOfHoldingContext(DbContextOptions<TomeOfHoldingContext> options) : base(options) { }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterSheet> CharacterSheets { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Campaign>().HasKey(c => c.CampaignId);
            modelBuilder.Entity<Player>().HasKey(p => p.PlayerId);
            modelBuilder.Entity<Character>().HasKey(c => c.CharacterId);
            modelBuilder.Entity<CharacterSheet>().HasKey(cs => cs.CharacterSheetID);
            modelBuilder.Entity<Session>().HasKey(s => s.SessionId);
            modelBuilder.Entity<Encounter>().HasKey(e => e.EncounterId);
            modelBuilder.Entity<Note>().HasKey(n => n.NoteId);

            modelBuilder.Entity<Campaign>()
                .HasMany(c => c.Players)
                .WithOne(p => p.Campaign)
                .HasForeignKey(p => p.CampaignId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Campaign>()
                .HasOne(c => c.GM)
                .WithMany()
                .HasForeignKey(c => c.GM_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Campaign>()
                .HasMany(c => c.Sessions)
                .WithOne(s => s.Campaign)
                .HasForeignKey(s => s.CampaignId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Session>()
                .HasMany(s => s.Encounters)
                .WithOne(e => e.Session)
                .HasForeignKey(e => e.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Session>()
                .HasMany(s => s.Notes)
                .WithOne(n => n.Session)
                .HasForeignKey(n => n.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Player>()
                .HasMany(p => p.Characters)
                .WithOne()
                .HasForeignKey(c => c.CampaignId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Player>()
                .HasMany(p => p.Notes)
                .WithOne(n => n.Player)
                .HasForeignKey(n => n.PlayerId)
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
        }
    }
}
