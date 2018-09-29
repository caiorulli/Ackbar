using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ackbar.Migrations
{
    public partial class LucasScrewup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Profiles_ProfileId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Agency_AgencyId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Appearance_AppearanceId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Conflict_ConflictId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Investment_InvestmentId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Rules_RulesId",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "Profile");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_RulesId",
                table: "Profile",
                newName: "IX_Profile_RulesId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_InvestmentId",
                table: "Profile",
                newName: "IX_Profile_InvestmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_ConflictId",
                table: "Profile",
                newName: "IX_Profile_ConflictId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_AppearanceId",
                table: "Profile",
                newName: "IX_Profile_AppearanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_AgencyId",
                table: "Profile",
                newName: "IX_Profile_AgencyId");

            migrationBuilder.RenameColumn(
                name: "ReportUrl",
                table: "Customers",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile",
                table: "Profile",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<long>(nullable: true),
                    ReportUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Report_CustomerId",
                table: "Report",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Profile_ProfileId",
                table: "Games",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Agency_AgencyId",
                table: "Profile",
                column: "AgencyId",
                principalTable: "Agency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Appearance_AppearanceId",
                table: "Profile",
                column: "AppearanceId",
                principalTable: "Appearance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Conflict_ConflictId",
                table: "Profile",
                column: "ConflictId",
                principalTable: "Conflict",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Investment_InvestmentId",
                table: "Profile",
                column: "InvestmentId",
                principalTable: "Investment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Rules_RulesId",
                table: "Profile",
                column: "RulesId",
                principalTable: "Rules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Profile_ProfileId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Agency_AgencyId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Appearance_AppearanceId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Conflict_ConflictId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Investment_InvestmentId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Rules_RulesId",
                table: "Profile");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "Profiles");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_RulesId",
                table: "Profiles",
                newName: "IX_Profiles_RulesId");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_InvestmentId",
                table: "Profiles",
                newName: "IX_Profiles_InvestmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_ConflictId",
                table: "Profiles",
                newName: "IX_Profiles_ConflictId");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_AppearanceId",
                table: "Profiles",
                newName: "IX_Profiles_AppearanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_AgencyId",
                table: "Profiles",
                newName: "IX_Profiles_AgencyId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "ReportUrl");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Profiles_ProfileId",
                table: "Games",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Agency_AgencyId",
                table: "Profiles",
                column: "AgencyId",
                principalTable: "Agency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Appearance_AppearanceId",
                table: "Profiles",
                column: "AppearanceId",
                principalTable: "Appearance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Conflict_ConflictId",
                table: "Profiles",
                column: "ConflictId",
                principalTable: "Conflict",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Investment_InvestmentId",
                table: "Profiles",
                column: "InvestmentId",
                principalTable: "Investment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Rules_RulesId",
                table: "Profiles",
                column: "RulesId",
                principalTable: "Rules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
