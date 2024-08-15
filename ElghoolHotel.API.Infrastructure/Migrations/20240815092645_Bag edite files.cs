using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElghoolHotel.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Bageditefiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bags");

            migrationBuilder.AddColumn<DateTime>(
                name: "checkInDate",
                table: "Bags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "checkOutDate",
                table: "Bags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "checkInDate",
                table: "Bags");

            migrationBuilder.DropColumn(
                name: "checkOutDate",
                table: "Bags");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
