﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TomeOfHolding.DAL.Migrations {
	/// <inheritdoc />
	public partial class init : Migration {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.CreateTable(
				name: "Campaigns",
				columns: table => new {
					CampaignId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					GM_ID = table.Column<int>(type: "int", nullable: false),
					Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Campaigns", x => x.CampaignId);
				});

			migrationBuilder.CreateTable(
				name: "Players",
				columns: table => new {
					PlayerId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					AvailableDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
					CampaignId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Players", x => x.PlayerId);
					table.ForeignKey(
						name: "FK_Players_Campaigns_CampaignId",
						column: x => x.CampaignId,
						principalTable: "Campaigns",
						principalColumn: "CampaignId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Sessions",
				columns: table => new {
					SessionId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Date = table.Column<DateOnly>(type: "date", nullable: false),
					Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
					CampaignId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Sessions", x => x.SessionId);
					table.ForeignKey(
						name: "FK_Sessions_Campaigns_CampaignId",
						column: x => x.CampaignId,
						principalTable: "Campaigns",
						principalColumn: "CampaignId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Characters",
				columns: table => new {
					CharacterId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Level = table.Column<int>(type: "int", nullable: false),
					Race = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
					CampaignId = table.Column<int>(type: "int", nullable: false),
					CharacterSheetId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Characters", x => x.CharacterId);
					table.ForeignKey(
						name: "FK_Characters_Campaigns_CampaignId",
						column: x => x.CampaignId,
						principalTable: "Campaigns",
						principalColumn: "CampaignId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Characters_Players_CampaignId",
						column: x => x.CampaignId,
						principalTable: "Players",
						principalColumn: "PlayerId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Encounters",
				columns: table => new {
					EncounterId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Difficulty = table.Column<int>(type: "int", nullable: false),
					Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Reward = table.Column<string>(type: "nvarchar(max)", nullable: false),
					SessionId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Encounters", x => x.EncounterId);
					table.ForeignKey(
						name: "FK_Encounters_Sessions_SessionId",
						column: x => x.SessionId,
						principalTable: "Sessions",
						principalColumn: "SessionId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Notes",
				columns: table => new {
					NoteId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					SessionId = table.Column<int>(type: "int", nullable: false),
					PlayerId = table.Column<int>(type: "int", nullable: false),
					Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Notes", x => x.NoteId);
					table.ForeignKey(
						name: "FK_Notes_Players_PlayerId",
						column: x => x.PlayerId,
						principalTable: "Players",
						principalColumn: "PlayerId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Notes_Sessions_SessionId",
						column: x => x.SessionId,
						principalTable: "Sessions",
						principalColumn: "SessionId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "CharacterSheets",
				columns: table => new {
					CharacterSheetID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					CharacterId = table.Column<int>(type: "int", nullable: false),
					Charisma = table.Column<int>(type: "int", nullable: false),
					Dexterity = table.Column<int>(type: "int", nullable: false),
					Constitution = table.Column<int>(type: "int", nullable: false),
					Intelligence = table.Column<int>(type: "int", nullable: false),
					Strength = table.Column<int>(type: "int", nullable: false),
					Wisdom = table.Column<int>(type: "int", nullable: false),
					Currency = table.Column<int>(type: "int", nullable: false),
					Spells = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_CharacterSheets", x => x.CharacterSheetID);
					table.ForeignKey(
						name: "FK_CharacterSheets_Characters_CharacterId",
						column: x => x.CharacterId,
						principalTable: "Characters",
						principalColumn: "CharacterId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Campaigns_GM_ID",
				table: "Campaigns",
				column: "GM_ID");

			migrationBuilder.CreateIndex(
				name: "IX_Characters_CampaignId",
				table: "Characters",
				column: "CampaignId");

			migrationBuilder.CreateIndex(
				name: "IX_CharacterSheets_CharacterId",
				table: "CharacterSheets",
				column: "CharacterId",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Encounters_SessionId",
				table: "Encounters",
				column: "SessionId");

			migrationBuilder.CreateIndex(
				name: "IX_Notes_PlayerId",
				table: "Notes",
				column: "PlayerId");

			migrationBuilder.CreateIndex(
				name: "IX_Notes_SessionId",
				table: "Notes",
				column: "SessionId");

			migrationBuilder.CreateIndex(
				name: "IX_Players_CampaignId",
				table: "Players",
				column: "CampaignId");

			migrationBuilder.CreateIndex(
				name: "IX_Sessions_CampaignId",
				table: "Sessions",
				column: "CampaignId");

			migrationBuilder.AddForeignKey(
				name: "FK_Campaigns_Players_GM_ID",
				table: "Campaigns",
				column: "GM_ID",
				principalTable: "Players",
				principalColumn: "PlayerId",
				onDelete: ReferentialAction.Restrict);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropForeignKey(
				name: "FK_Campaigns_Players_GM_ID",
				table: "Campaigns");

			migrationBuilder.DropTable(
				name: "CharacterSheets");

			migrationBuilder.DropTable(
				name: "Encounters");

			migrationBuilder.DropTable(
				name: "Notes");

			migrationBuilder.DropTable(
				name: "Characters");

			migrationBuilder.DropTable(
				name: "Sessions");

			migrationBuilder.DropTable(
				name: "Players");

			migrationBuilder.DropTable(
				name: "Campaigns");
		}
	}
}
