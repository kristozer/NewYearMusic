using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewYearMusic.Migrations
{
    public partial class AddTwoPropertiesToSong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Songs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditionDate",
                table: "Songs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "EditionDate",
                table: "Songs");
        }
    }
}
