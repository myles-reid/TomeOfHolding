﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TomeOfHolding.DAL;

#nullable disable

namespace TomeOfHolding.DAL.Migrations
{
    [DbContext(typeof(TomeOfHoldingContext))]
    partial class TomeOfHoldingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CampaignPlayer", b =>
                {
                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("CampaignId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("CampaignPlayer", (string)null);
                });

            modelBuilder.Entity("TomeOfHolding.Models.Campaign", b =>
                {
                    b.Property<int>("CampaignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("GM_ID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CampaignId");

                    b.HasIndex("GM_ID");

                    b.ToTable("Campaigns");

                    b.HasData(
                        new
                        {
                            CampaignId = 1,
                            Description = "A thrilling adventure to slay a dragon.",
                            GM_ID = 3,
                            Title = "Dragon's Quest"
                        },
                        new
                        {
                            CampaignId = 2,
                            Description = "Explore the magical realms and uncover secrets.",
                            GM_ID = 4,
                            Title = "Mystic Realms"
                        });
                });

            modelBuilder.Entity("TomeOfHolding.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"));

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterSheetId")
                        .HasColumnType("int");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CharacterId");

                    b.HasIndex("CampaignId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            CampaignId = 1,
                            CharacterSheetId = 1,
                            Class = "Warrior",
                            Description = "A brave dwarf warrior.",
                            Level = 10,
                            Name = "Thorin",
                            PlayerId = 1,
                            Race = "Dwarf",
                            Role = "Tank"
                        },
                        new
                        {
                            CharacterId = 2,
                            CampaignId = 1,
                            CharacterSheetId = 2,
                            Class = "Mage",
                            Description = "A skilled elven mage.",
                            Level = 12,
                            Name = "Elandra",
                            PlayerId = 2,
                            Race = "Elf",
                            Role = "DPS"
                        },
                        new
                        {
                            CharacterId = 3,
                            CampaignId = 2,
                            CharacterSheetId = 3,
                            Class = "Rogue",
                            Description = "A cunning human rogue.",
                            Level = 8,
                            Name = "Gorath",
                            PlayerId = 1,
                            Race = "Human",
                            Role = "DPS"
                        },
                        new
                        {
                            CharacterId = 4,
                            CampaignId = 2,
                            CharacterSheetId = 4,
                            Class = "Cleric",
                            Description = "A devoted halfling cleric.",
                            Level = 9,
                            Name = "Lyra",
                            PlayerId = 2,
                            Race = "Halfling",
                            Role = "Healer"
                        });
                });

            modelBuilder.Entity("TomeOfHolding.Models.CharacterSheet", b =>
                {
                    b.Property<int>("CharacterSheetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterSheetID"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("Charisma")
                        .HasColumnType("int");

                    b.Property<int>("Constitution")
                        .HasColumnType("int");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Spells")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("Wisdom")
                        .HasColumnType("int");

                    b.HasKey("CharacterSheetID");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("CharacterSheets");

                    b.HasData(
                        new
                        {
                            CharacterSheetID = 1,
                            CharacterId = 1,
                            Charisma = 10,
                            Constitution = 15,
                            Currency = 100,
                            Dexterity = 12,
                            Intelligence = 8,
                            Spells = "[\"Shield Bash\",\"Battle Cry\"]",
                            Strength = 18,
                            Wisdom = 10
                        },
                        new
                        {
                            CharacterSheetID = 2,
                            CharacterId = 2,
                            Charisma = 14,
                            Constitution = 8,
                            Currency = 200,
                            Dexterity = 10,
                            Intelligence = 18,
                            Spells = "[\"Fireball\",\"Teleport\"]",
                            Strength = 8,
                            Wisdom = 12
                        },
                        new
                        {
                            CharacterSheetID = 3,
                            CharacterId = 3,
                            Charisma = 12,
                            Constitution = 10,
                            Currency = 150,
                            Dexterity = 18,
                            Intelligence = 14,
                            Spells = "[\"Backstab\",\"Shadow Step\"]",
                            Strength = 10,
                            Wisdom = 8
                        },
                        new
                        {
                            CharacterSheetID = 4,
                            CharacterId = 4,
                            Charisma = 16,
                            Constitution = 12,
                            Currency = 120,
                            Dexterity = 10,
                            Intelligence = 10,
                            Spells = "[\"Heal\",\"Bless\"]",
                            Strength = 8,
                            Wisdom = 18
                        });
                });

            modelBuilder.Entity("TomeOfHolding.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<string>("AvailableDays")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            PlayerId = 1,
                            AvailableDays = "[1,3]",
                            Name = "Alice",
                            Role = "Player"
                        },
                        new
                        {
                            PlayerId = 2,
                            AvailableDays = "[2,4]",
                            Name = "Bob",
                            Role = "Player"
                        },
                        new
                        {
                            PlayerId = 3,
                            AvailableDays = "[5]",
                            Name = "Charlie",
                            Role = "GM"
                        },
                        new
                        {
                            PlayerId = 4,
                            AvailableDays = "[6]",
                            Name = "Diana",
                            Role = "GM"
                        });
                });

            modelBuilder.Entity("CampaignPlayer", b =>
                {
                    b.HasOne("TomeOfHolding.Models.Campaign", null)
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TomeOfHolding.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TomeOfHolding.Models.Campaign", b =>
                {
                    b.HasOne("TomeOfHolding.Models.Player", "GM")
                        .WithMany()
                        .HasForeignKey("GM_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GM");
                });

            modelBuilder.Entity("TomeOfHolding.Models.Character", b =>
                {
                    b.HasOne("TomeOfHolding.Models.Campaign", "Campaign")
                        .WithMany("Characters")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TomeOfHolding.Models.Player", "Player")
                        .WithMany("Characters")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("TomeOfHolding.Models.CharacterSheet", b =>
                {
                    b.HasOne("TomeOfHolding.Models.Character", "Character")
                        .WithOne("CharacterSheet")
                        .HasForeignKey("TomeOfHolding.Models.CharacterSheet", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("TomeOfHolding.Models.Campaign", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("TomeOfHolding.Models.Character", b =>
                {
                    b.Navigation("CharacterSheet")
                        .IsRequired();
                });

            modelBuilder.Entity("TomeOfHolding.Models.Player", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
