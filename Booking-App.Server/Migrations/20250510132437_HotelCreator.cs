using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_App.Server.Migrations
{
    /// <inheritdoc />
    public partial class HotelCreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Hotels",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CreatorId",
                table: "Hotels",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_AspNetUsers_CreatorId",
                table: "Hotels",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_AspNetUsers_CreatorId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_CreatorId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Hotels");
        }
    }
}
