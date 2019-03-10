using Microsoft.EntityFrameworkCore.Migrations;

namespace NewYearMusic.Migrations
{
    public partial class ChangeSongUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_AspNetUsers_AppUserId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Songs",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_AppUserId",
                table: "Songs",
                newName: "IX_Songs_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_AspNetUsers_UserId",
                table: "Songs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_AspNetUsers_UserId",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Songs",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_UserId",
                table: "Songs",
                newName: "IX_Songs_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

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
