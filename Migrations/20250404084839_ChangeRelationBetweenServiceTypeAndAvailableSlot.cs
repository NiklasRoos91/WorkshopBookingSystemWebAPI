using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkshopBookingSystemWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationBetweenServiceTypeAndAvailableSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTypes_AvailableSlots_AvailableSlotId",
                table: "ServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTypes_AvailableSlotId",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "AvailableSlotId",
                table: "ServiceTypes");

            migrationBuilder.AddColumn<int>(
                name: "ServiceTypeId",
                table: "AvailableSlots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSlots_ServiceTypeId",
                table: "AvailableSlots",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableSlots_ServiceTypes_ServiceTypeId",
                table: "AvailableSlots",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableSlots_ServiceTypes_ServiceTypeId",
                table: "AvailableSlots");

            migrationBuilder.DropIndex(
                name: "IX_AvailableSlots_ServiceTypeId",
                table: "AvailableSlots");

            migrationBuilder.DropColumn(
                name: "ServiceTypeId",
                table: "AvailableSlots");

            migrationBuilder.AddColumn<int>(
                name: "AvailableSlotId",
                table: "ServiceTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_AvailableSlotId",
                table: "ServiceTypes",
                column: "AvailableSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTypes_AvailableSlots_AvailableSlotId",
                table: "ServiceTypes",
                column: "AvailableSlotId",
                principalTable: "AvailableSlots",
                principalColumn: "AvailableSlotId");
        }
    }
}
