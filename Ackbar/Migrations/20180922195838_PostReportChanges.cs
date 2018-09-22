using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ackbar.Migrations
{
    public partial class PostReportChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Views",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollectionSize",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ProfileId",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "RegressionAlpha",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "WeeklyPlayTime",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Likes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SellingPrice",
                table: "Games",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Ownerships",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<long>(nullable: true),
                    PlayerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ownerships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ownerships_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ownerships_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegressionAgency",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gradation = table.Column<float>(nullable: false),
                    Participation = table.Column<float>(nullable: false),
                    Result = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegressionAgency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegressionAppearance",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quality = table.Column<float>(nullable: false),
                    Theme = table.Column<float>(nullable: false),
                    Transmediality = table.Column<float>(nullable: false),
                    VisualIdentity = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegressionAppearance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegressionConflict",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CognitiveAbility = table.Column<float>(nullable: false),
                    Competitivity = table.Column<float>(nullable: false),
                    Economy = table.Column<float>(nullable: false),
                    Feedback = table.Column<float>(nullable: false),
                    Interaction = table.Column<float>(nullable: false),
                    MentalAbility = table.Column<float>(nullable: false),
                    PhysicalAbility = table.Column<float>(nullable: false),
                    SocialAbility = table.Column<float>(nullable: false),
                    Structure = table.Column<float>(nullable: false),
                    Symmetry = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegressionConflict", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegressionInvestment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Duration = table.Column<float>(nullable: false),
                    Monetary = table.Column<float>(nullable: false),
                    Setup = table.Column<float>(nullable: false),
                    Space = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegressionInvestment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegressionRules",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Duration = table.Column<float>(nullable: false),
                    Monetary = table.Column<float>(nullable: false),
                    Setup = table.Column<float>(nullable: false),
                    Space = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegressionRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegressionProfile",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgencyId = table.Column<long>(nullable: true),
                    AppearanceId = table.Column<long>(nullable: true),
                    ConflictId = table.Column<long>(nullable: true),
                    InvestmentId = table.Column<long>(nullable: true),
                    RulesId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegressionProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegressionProfile_RegressionAgency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "RegressionAgency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegressionProfile_RegressionAppearance_AppearanceId",
                        column: x => x.AppearanceId,
                        principalTable: "RegressionAppearance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegressionProfile_RegressionConflict_ConflictId",
                        column: x => x.ConflictId,
                        principalTable: "RegressionConflict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegressionProfile_RegressionInvestment_InvestmentId",
                        column: x => x.InvestmentId,
                        principalTable: "RegressionInvestment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegressionProfile_RegressionRules_RulesId",
                        column: x => x.RulesId,
                        principalTable: "RegressionRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_ProfileId",
                table: "Players",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Ownerships_GameId",
                table: "Ownerships",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Ownerships_PlayerId",
                table: "Ownerships",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RegressionProfile_AgencyId",
                table: "RegressionProfile",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_RegressionProfile_AppearanceId",
                table: "RegressionProfile",
                column: "AppearanceId");

            migrationBuilder.CreateIndex(
                name: "IX_RegressionProfile_ConflictId",
                table: "RegressionProfile",
                column: "ConflictId");

            migrationBuilder.CreateIndex(
                name: "IX_RegressionProfile_InvestmentId",
                table: "RegressionProfile",
                column: "InvestmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegressionProfile_RulesId",
                table: "RegressionProfile",
                column: "RulesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_RegressionProfile_ProfileId",
                table: "Players",
                column: "ProfileId",
                principalTable: "RegressionProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_RegressionProfile_ProfileId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Ownerships");

            migrationBuilder.DropTable(
                name: "RegressionProfile");

            migrationBuilder.DropTable(
                name: "RegressionAgency");

            migrationBuilder.DropTable(
                name: "RegressionAppearance");

            migrationBuilder.DropTable(
                name: "RegressionConflict");

            migrationBuilder.DropTable(
                name: "RegressionInvestment");

            migrationBuilder.DropTable(
                name: "RegressionRules");

            migrationBuilder.DropIndex(
                name: "IX_Players_ProfileId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Views");

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CollectionSize",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RegressionAlpha",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "WeeklyPlayTime",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "SellingPrice",
                table: "Games");
        }
    }
}
