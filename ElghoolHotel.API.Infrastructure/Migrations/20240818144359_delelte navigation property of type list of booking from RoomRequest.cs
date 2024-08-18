using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElghoolHotel.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleltenavigationpropertyoftypelistofbookingfromRoomRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingRoomRequest");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "RoomRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomRequests_BookingId",
                table: "RoomRequests",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomRequests_Bookings_BookingId",
                table: "RoomRequests",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomRequests_Bookings_BookingId",
                table: "RoomRequests");

            migrationBuilder.DropIndex(
                name: "IX_RoomRequests_BookingId",
                table: "RoomRequests");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "RoomRequests");

            migrationBuilder.CreateTable(
                name: "BookingRoomRequest",
                columns: table => new
                {
                    BagsBookingId = table.Column<int>(type: "int", nullable: false),
                    RoomRequestsRoomRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRoomRequest", x => new { x.BagsBookingId, x.RoomRequestsRoomRequestId });
                    table.ForeignKey(
                        name: "FK_BookingRoomRequest_Bookings_BagsBookingId",
                        column: x => x.BagsBookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRoomRequest_RoomRequests_RoomRequestsRoomRequestId",
                        column: x => x.RoomRequestsRoomRequestId,
                        principalTable: "RoomRequests",
                        principalColumn: "RoomRequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingRoomRequest_RoomRequestsRoomRequestId",
                table: "BookingRoomRequest",
                column: "RoomRequestsRoomRequestId");
        }
    }
}
