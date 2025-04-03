using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkshopBookingSystemWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookingTimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingDateTime",
                table: "Bookings",
                newName: "StartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Bookings",
                newName: "BookingDateTime");
        }
    }
}
