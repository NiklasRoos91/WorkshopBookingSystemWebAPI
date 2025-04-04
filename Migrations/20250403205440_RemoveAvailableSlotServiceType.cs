using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkshopBookingSystemWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAvailableSlotServiceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableSlotServiceTypes");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "AvailableSlotServiceTypes",
                columns: table => new
                {
                    AvailableSlotId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false),
                    AvailableSlotServiceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableSlotServiceTypes", x => new { x.AvailableSlotId, x.ServiceTypeId });
                    table.ForeignKey(
                        name: "FK_AvailableSlotServiceTypes_AvailableSlots_AvailableSlotId",
                        column: x => x.AvailableSlotId,
                        principalTable: "AvailableSlots",
                        principalColumn: "AvailableSlotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableSlotServiceTypes_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSlotServiceTypes_ServiceTypeId",
                table: "AvailableSlotServiceTypes",
                column: "ServiceTypeId");
        }
    }
}
