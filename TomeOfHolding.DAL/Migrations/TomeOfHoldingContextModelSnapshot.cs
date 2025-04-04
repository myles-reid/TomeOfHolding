﻿// <auto-generated />
using System;
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GM_ID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CampaignId");

                    b.HasIndex("GM_ID");

                    b.ToTable("Campaigns");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CharacterId");

                    b.HasIndex("CampaignId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Characters");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("Wisdom")
                        .HasColumnType("int");

                    b.HasKey("CharacterSheetID");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("CharacterSheets");
                });

            modelBuilder.Entity("TomeOfHolding.Models.Encounter", b =>
                {
                    b.Property<int>("EncounterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EncounterId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<string>("Reward")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EncounterId");

                    b.HasIndex("SessionId");

                    b.ToTable("Encounters");
                });

            modelBuilder.Entity("TomeOfHolding.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoteId"));

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("NoteId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SessionId");

                    b.ToTable("Notes");
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

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.HasIndex("CampaignId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TomeOfHolding.Models.Session", b =>
                {
                    b.Property<int>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SessionId"));

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SessionId");

                    b.HasIndex("CampaignId");

                    b.ToTable("Sessions");
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

            modelBuilder.Entity("TomeOfHolding.Models.Encounter", b =>
                {
                    b.HasOne("TomeOfHolding.Models.Session", "Session")
                        .WithMany("Encounters")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("TomeOfHolding.Models.Note", b =>
                {
                    b.HasOne("TomeOfHolding.Models.Player", "Player")
                        .WithMany("Notes")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TomeOfHolding.Models.Session", "Session")
                        .WithMany("Notes")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("TomeOfHolding.Models.Player", b =>
                {
                    b.HasOne("TomeOfHolding.Models.Campaign", "Campaign")
                        .WithMany("Players")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("TomeOfHolding.Models.Session", b =>
                {
                    b.HasOne("TomeOfHolding.Models.Campaign", "Campaign")
                        .WithMany("Sessions")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("TomeOfHolding.Models.Campaign", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Players");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("TomeOfHolding.Models.Character", b =>
                {
                    b.Navigation("CharacterSheet")
                        .IsRequired();
                });

            modelBuilder.Entity("TomeOfHolding.Models.Player", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Notes");
                });

            modelBuilder.Entity("TomeOfHolding.Models.Session", b =>
                {
                    b.Navigation("Encounters");

                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
