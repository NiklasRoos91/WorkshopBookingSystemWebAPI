using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkshopBookingSystemWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceTypeRelationToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableSlots_ServiceTypes_ServiceTypeId",
                table: "AvailableSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_ServiceTypes_ServiceTypeId",
                table: "Bookings");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableSlots_ServiceTypes_ServiceTypeId",
                table: "AvailableSlots",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_ServiceTypes_ServiceTypeId",
                table: "Bookings",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableSlots_ServiceTypes_ServiceTypeId",
                table: "AvailableSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_ServiceTypes_ServiceTypeId",
                table: "Bookings");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableSlots_ServiceTypes_ServiceTypeId",
                table: "AvailableSlots",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_ServiceTypes_ServiceTypeId",
                table: "Bookings",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
