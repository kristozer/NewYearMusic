using Microsoft.EntityFrameworkCore.Migrations;

namespace NewYearMusic.Migrations
{
    public partial class MovedSong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_AspNetUsers_AppUserId",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "Songs",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_AspNetUsers_AppUserId",
                table: "Songs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_AspNetUsers_AppUserId",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Songs",
                newName: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_AspNetUsers_AppUserId",
                table: "Songs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
