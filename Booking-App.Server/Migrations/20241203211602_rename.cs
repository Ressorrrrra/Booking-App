using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_App.Server.Migrations
{
    /// <inheritdoc />
    public partial class rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdultResidentAmount",
                table: "Orders",
                newName: "AdultsAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdultsAmount",
                table: "Orders",
                newName: "AdultResidentAmount");
        }
    }
}
