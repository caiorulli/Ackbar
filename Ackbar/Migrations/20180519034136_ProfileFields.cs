using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ackbar.Migrations
{
    public partial class ProfileFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Actions",
                table: "Rules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Components",
                table: "Rules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Conditions",
                table: "Rules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdealNumberOfPlayers",
                table: "Rules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Randomness",
                table: "Rules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RealNumberOfPlayers",
                table: "Rules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Resources",
                table: "Rules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Variance",
                table: "Rules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VictoryConditions",
                table: "Rules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Investment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Monetary",
                table: "Investment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Setup",
                table: "Investment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Space",
                table: "Investment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CognitiveAbility",
                table: "Conflict",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Competitivity",
                table: "Conflict",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Economy",
                table: "Conflict",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Feedback",
                table: "Conflict",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Interaction",
                table: "Conflict",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MentalAbility",
                table: "Conflict",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhysicalAbility",
                table: "Conflict",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SocialAbility",
                table: "Conflict",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Structure",
                table: "Conflict",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Symmetry",
                table: "Conflict",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quality",
                table: "Appearance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Theme",
                table: "Appearance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Transmediality",
                table: "Appearance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VisualIdentity",
                table: "Appearance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gradation",
                table: "Agency",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Participation",
                table: "Agency",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Result",
                table: "Agency",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actions",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "Components",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "Conditions",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "IdealNumberOfPlayers",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "Randomness",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "RealNumberOfPlayers",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "Resources",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "Variance",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "VictoryConditions",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Investment");

            migrationBuilder.DropColumn(
                name: "Monetary",
                table: "Investment");

            migrationBuilder.DropColumn(
                name: "Setup",
                table: "Investment");

            migrationBuilder.DropColumn(
                name: "Space",
                table: "Investment");

            migrationBuilder.DropColumn(
                name: "CognitiveAbility",
                table: "Conflict");

            migrationBuilder.DropColumn(
                name: "Competitivity",
                table: "Conflict");

            migrationBuilder.DropColumn(
                name: "Economy",
                table: "Conflict");

            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "Conflict");

            migrationBuilder.DropColumn(
                name: "Interaction",
                table: "Conflict");

            migrationBuilder.DropColumn(
                name: "MentalAbility",
                table: "Conflict");

            migrationBuilder.DropColumn(
                name: "PhysicalAbility",
                table: "Conflict");

            migrationBuilder.DropColumn(
                name: "SocialAbility",
                table: "Conflict");

            migrationBuilder.DropColumn(
                name: "Structure",
                table: "Conflict");

            migrationBuilder.DropColumn(
                name: "Symmetry",
                table: "Conflict");

            migrationBuilder.DropColumn(
                name: "Quality",
                table: "Appearance");

            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Appearance");

            migrationBuilder.DropColumn(
                name: "Transmediality",
                table: "Appearance");

            migrationBuilder.DropColumn(
                name: "VisualIdentity",
                table: "Appearance");

            migrationBuilder.DropColumn(
                name: "Gradation",
                table: "Agency");

            migrationBuilder.DropColumn(
                name: "Participation",
                table: "Agency");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Agency");
        }
    }
}
