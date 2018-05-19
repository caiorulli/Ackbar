using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ackbar.Migrations
{
    public partial class DescriptionAndCoverImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Games");
        }
    }
}
