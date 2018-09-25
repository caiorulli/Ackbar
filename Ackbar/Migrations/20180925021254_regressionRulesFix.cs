using Microsoft.EntityFrameworkCore.Migrations;

namespace Ackbar.Migrations
{
    public partial class regressionRulesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Space",
                table: "RegressionRules",
                newName: "VictoryConditions");

            migrationBuilder.RenameColumn(
                name: "Setup",
                table: "RegressionRules",
                newName: "Variance");

            migrationBuilder.RenameColumn(
                name: "Monetary",
                table: "RegressionRules",
                newName: "Resources");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "RegressionRules",
                newName: "RealNumberOfPlayers");

            migrationBuilder.AddColumn<float>(
                name: "Actions",
                table: "RegressionRules",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Components",
                table: "RegressionRules",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Conditions",
                table: "RegressionRules",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "IdealNumberOfPlayers",
                table: "RegressionRules",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Randomness",
                table: "RegressionRules",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actions",
                table: "RegressionRules");

            migrationBuilder.DropColumn(
                name: "Components",
                table: "RegressionRules");

            migrationBuilder.DropColumn(
                name: "Conditions",
                table: "RegressionRules");

            migrationBuilder.DropColumn(
                name: "IdealNumberOfPlayers",
                table: "RegressionRules");

            migrationBuilder.DropColumn(
                name: "Randomness",
                table: "RegressionRules");

            migrationBuilder.RenameColumn(
                name: "VictoryConditions",
                table: "RegressionRules",
                newName: "Space");

            migrationBuilder.RenameColumn(
                name: "Variance",
                table: "RegressionRules",
                newName: "Setup");

            migrationBuilder.RenameColumn(
                name: "Resources",
                table: "RegressionRules",
                newName: "Monetary");

            migrationBuilder.RenameColumn(
                name: "RealNumberOfPlayers",
                table: "RegressionRules",
                newName: "Duration");
        }
    }
}
